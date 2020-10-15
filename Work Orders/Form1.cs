using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Work_Orders
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Used to access and modify files in BlobStorage
        /// </summary>
        Blob BlobClient = new Blob("zaidtest", "nqYfW0x4i2722B16Az281U373IzHooNtK9MGoJQ0DDdGut33FFr4jHo8nxmFRuk+XPiGu1kw7SqqIaLPTpSOew==");

        /// <summary>
        /// stores values to and from ordersgrid and SQL
        /// </summary>
        public DataTable SourceTable = new DataTable();

        //SQL table to data table population info
        public BindingSource bs = new BindingSource();
        public DataTable dt = new DataTable();
        public SqlDataAdapter da;
        //public DataSet ds ;


        #region Mains

        /// <summary>
        /// Allows JSON to serialize and deserialize images
        /// </summary>
        //public class ImageConverter : JsonConverter
        //{
        //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        //    {
        //        var base64 = (string)reader.Value;
        //        // convert base64 to byte array, put that into memory stream and feed to image
        //        return Image.FromStream(new MemoryStream(Convert.FromBase64String(base64)));
        //    }

        //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        //    {
        //        var image = (Image)value;
        //        // save to memory stream in original format
        //        var ms = new MemoryStream();
        //        image.Save(ms, image.RawFormat);
        //        byte[] imageBytes = ms.ToArray();
        //        // write byte array, will be converted to base64 by JSON.NET
        //        writer.WriteValue(imageBytes);
        //    }

        //    /// <summary>
        //    /// Checks if an object can be serialized into JSON
        //    /// </summary>
        //    /// <param name="objectType"></param>
        //    /// <returns></returns>
        //    public override bool CanConvert(Type objectType)
        //    {
        //        return objectType == typeof(Image);
        //    }
        //}

        //TODO GetData


        /// <summary>
        /// Starts up the form (I think)
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// loads form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //userAddingRow = false;

            DataTable dt = GetData();

            bs = new BindingSource(dt, null);
            //OrdersGrid.Columns.Insert(0, callStatusColumn());
            OrdersGrid.DataSource = bs;

            CompanyFilter.Items.Clear();

            DataTable distinctCompanys = GetCustomData("Select Distinct Company From WorkOrdersSQLTable");
            CompanyFilter.DataSource = distinctCompanys;
            CompanyFilter.DisplayMember = "Company";
            CompanyFilter.ValueMember = "Company";

            // userAddingRow = true;
        }

        //TODO Form Shown
        /// <summary>
        /// Runs after Form1 is initialized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            //Removes Testboxcolumn "status" and changes it to comboboxcolumn
            int statusIndex = OrdersGrid.Columns["Status"].Index;
            // OrdersGrid.Columns.Remove("GUID");

            //OrdersGrid.Columns.Remove("Status");
            //OrdersGrid.Columns.Insert(statusIndex, callStatusColumn());

            OrdersGrid.Columns.Insert(OrdersGrid.Columns["Images"].Index, AddPictureColumn());

            //OrdersGrid.Columns["Due Date"].ReadOnly = true;
            //OrdersGrid.Columns["Timestamp"].ReadOnly = true;
            //OrdersGrid.Columns["Images"].ReadOnly = true;

            OrdersGrid.Columns["GUID"].Visible = false;
            OrdersGrid.Columns["Timestamp"].Visible = false;
            //OrdersGrid.Columns["Due Date"].Visible = false;
            //OrdersGrid.Columns["Images"].Visible = false;

            //TODO Timestamp copy
            //DataGridViewTextBoxColumn Timestamp2 = new DataGridViewTextBoxColumn();
            //Timestamp2.Name = "Timestamp";
            //Timestamp2.HeaderText = "Timestamp";
            //List<string> times = new List<string>();
            //foreach (DataGridViewRow row in OrdersGrid.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        if (cell.ColumnIndex == OrdersGrid.Columns["Timestamp"].Index)
            //        {
            //            try
            //            {
            //                times.Add(cell.Value.ToString());
            //            }
            //            catch (Exception)
            //            {
            //            }
            //        }
            //    }
            //}
            //OrdersGrid.Columns.Insert(OrdersGrid.Columns["Timestamp"].Index, Timestamp2);
            //foreach (DataGridViewRow row in OrdersGrid.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        if (cell.ColumnIndex == OrdersGrid.Columns["Timestamp"].Index)
            //        {
            //            try
            //            {
            //                cell.Value = times[row.Index];
            //            }
            //            catch (Exception)
            //            {
            //            }
            //        }
            //    }
            //}

            //OrdersGrid.Columns["Timestamp"].ReadOnly = true;
            //OrdersGrid.Columns["Due Date"].ReadOnly = true;

            foreach (DataGridViewRow row in OrdersGrid.Rows)
            {
                try
                {
                    //Loads in the image assigned to the GUID
                    Image Loadpic = Bitmap.FromStream(BlobClient.DownloadFileToStream("workorderimages", row.Cells["Images"].Value.ToString()));
                    OrdersGrid.Rows[row.Index].Cells["Picture"].Value = Loadpic;

                }
                catch (Exception)
                {

                }
            }
        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// Grabs all the data in the SQL table and returns a datatable
        /// </summary>
        /// <returns></returns>
        public DataTable GetData(string company = "")
        {
            SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;");
            string sqlQuery = @"Select * from WorkOrdersSQLTable";

            if (company != "")
            {
                sqlQuery += $@" where company = '{company}'";
            }
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
            da = new SqlDataAdapter(cmd);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.UpdateCommand = builder.GetUpdateCommand();
            da.InsertCommand = builder.GetInsertCommand();
            da.DeleteCommand = builder.GetDeleteCommand();
            da.Fill(dt);



            builder.ConflictOption = ConflictOption.OverwriteChanges;

            return dt;
        }

        //Can be used to return data from a select statment
        public DataTable GetCustomData(string sqlQuery)
        {
            DataTable dt2 = new DataTable();
            SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;");
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            da2.Fill(dt2);
            return dt2;
        }

        //Returns result as string
        public string GetScalarStringData(string sqlQuery)
        {
            string result = "";
            SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;");
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
            result = cmd.ExecuteScalar().ToString();
            sqlConn.Close();
            return result;
        }

        //Returns result as int
        public int GetScalarIntData(string sqlQuery)
        {
            int result;
            SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;");
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
            result = (int)cmd.ExecuteScalar();
            sqlConn.Close();
            return result;
        }

        public void UpdateSQL()
        {
            try
            {
                bs.EndEdit();
                da.Update((DataTable)bs.DataSource);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        /// <summary>
        /// status column becomes accessible to any area in Form1
        /// Unable to declare it globally so this is the solution
        /// </summary>
        /// <returns></returns>
        public DataGridViewComboBoxColumn callStatusColumn()
        {
            DataGridViewComboBoxColumn status = new DataGridViewComboBoxColumn();
            {
                //status.Items.Add("New");
                //status.Items.Add("Working");
                //status.Items.Add("Completed");

                //string[] items = new string[] { "New", "Working", "Completed" };

                var newDt = ((DataTable)bs.DataSource).AsEnumerable()
                .GroupBy(x => x.Field<string>("Status"))
                .Select(y => y.First())
                .CopyToDataTable();

                status.DataSource = newDt;
                status.HeaderText = "Status";
                status.Name = "Status";
                status.DataPropertyName = "Status";
                //status.ValueMember = "Status";
                //status.DisplayMember = "Status";
                return status;
            }
        }

        public DataGridViewImageColumn AddPictureColumn()
        {
            DataGridViewImageColumn Picture = new DataGridViewImageColumn();
            {
                Picture.HeaderText = "Picture";
                Picture.DataPropertyName = "Picture";
                Picture.Name = "Picture";

                return Picture;
            }
        }

        #endregion

        #region Buttons
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            UpdateSQL();
            MessageBox.Show("Done saving.");
        }

        //TODO Test Button
        private void Button1_Click(object sender, EventArgs e)
        {
            string a = GetScalarStringData("Select Count(*) from [WorkOrdersSQLTable]");
            MessageBox.Show(a);

            int b = GetScalarIntData("Select Count(*) from [WorkOrdersSQLTable]");
            MessageBox.Show(b.ToString());

            DataTable dt = GetCustomData("Select Count(*) from [WorkOrdersSQLTable]");
            foreach (DataRow row in dt.Rows)
            {
                MessageBox.Show(row[0].ToString());
            }


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("DELETE FROM WorkOrdersSQLTable WHERE [First Name] = 'c'");
            SqlConnection conn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;");
            comm.Connection = conn;
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void OrdersGrid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSQL();

            //DataTable newRow = GetCustomData("SELECT TOP 1 * FROM WorkOrdersSQLTable WHERE WorkOrdersSQLTable.Timestamp < CURRENT_TIMESTAMP ORDER BY WorkOrdersSQLTable.Timestamp DESC");
            ////TODO timestamp
            ////Adds info into Timestamp column if null
            //if (string.IsNullOrEmpty(OrdersGrid.Rows[e.RowIndex].Cells["Timestamp"].Value.ToString()))
            //{
            //    string UTC = newRow.Rows[0].ItemArray[10].ToString();
            //    DateTime UTCDate = DateTime.ParseExact(UTC, "M/d/yyyy h:m:s tt", null);
            //    TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            //    DateTime UTCtoCentral = TimeZoneInfo.ConvertTimeFromUtc(UTCDate, timeInfo);

            //    OrdersGrid.Rows[e.RowIndex].Cells["Timestamp"].Value = UTCtoCentral.ToString();
            //}
        }

        //TODO Cell Click
        /// <summary>
        /// When the user clicks on a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdersGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // userAddingRow = false;
            if (e.ColumnIndex == -1)
            {
                return;
            }
            if (OrdersGrid.Columns[e.ColumnIndex].Name == "Picture" && e.RowIndex >= 0)
            {
                var dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //updateSQL();
                    //bs = new BindingSource(dt, null);
                    //OrdersGrid.DataSource = bs;

                    //TODO Image saving on cell click

                    string uniqueFileName = Guid.NewGuid().ToString().ToUpper().Replace("-", "") + "-" + openFileDialog.FileName.Split('\\').Last();
                    //string uniqueFileName = OrdersGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("-", "") + "-" + openFileDialog.FileName.Split('\\').Last();
                    // Example: 5DD5A8EFE16743E38D5A6AA85667B50D-test.jfif

                    //MessageBox.Show(uniqueFileName + "-" + openFileDialog.FileName.Split('\\').Last());

                    OrdersGrid.Rows[e.RowIndex].Cells["Images"].Value = uniqueFileName;
                    //BlobClient.UploadFile("workorderimages", OrdersGrid.Rows[e.RowIndex].Cells["GUID"].Value.ToString(), openFileDialog.FileName);

                    List<string> BlobNames = BlobClient.ListContainerFiles("workorderimages");
                    string UFNGUID = uniqueFileName.Split('-').First();
                    foreach (string Name in BlobNames)
                    {
                        string BlobGUID = Name.Split('-').First();
                        if (UFNGUID.Equals(BlobGUID))
                        {
                            BlobClient.DeleteFile("workorderimages", Name);
                            BlobClient.UploadFile("workorderimages", uniqueFileName, openFileDialog.FileName);
                        }
                    }
                    BlobClient.UploadFile("workorderimages", uniqueFileName, openFileDialog.FileName);

                    ///WE LEFT OFF HERE TO GET THE IMAGE FROM BLOB SUFF
                    try
                    {
                        //Loads in the image assigned to the order
                        Image Loadpic = Bitmap.FromStream(BlobClient.DownloadFileToStream("workorderimages", uniqueFileName));
                        OrdersGrid.Rows[e.RowIndex].Cells["Picture"].Value = Loadpic;
                    }
                    catch (Exception)
                    {
                    }
                    UpdateSQL();
                }
            }

            if (OrdersGrid.Columns[e.ColumnIndex].Name == "Due Date" && e.RowIndex >= 0)
            {
                using (DueDateEditForm form = new DueDateEditForm())
                {
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        OrdersGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = form.getDueDate;
                    }
                }
            }

            if (OrdersGrid.Columns[e.ColumnIndex].Name == "Status" && e.RowIndex >= 0)
            {
                using (frmStatusChanger formStatus = new frmStatusChanger())
                {
                    formStatus.ShowDialog();
                    if (formStatus.DialogResult == DialogResult.OK)
                    {
                        OrdersGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = formStatus.status;
                    }
                }
            }

            // userAddingRow = false;
        }

        #endregion

        #region Context Menu Strip
        /// <summary>
        /// When the delete button in the contextmenustrip is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    //checks if rows were selected
        //    if (OrdersGrid.SelectedRows.Count > 0)
        //    {
        //        RemoveOrderbyRow();
        //        UpdateSQL();
        //    }
        //    else if (OrdersGrid.SelectedCells.Count > 0)
        //    {
        //        RemoveOrderbyCell();
        //        UpdateSQL();
        //    }
        //}

        /// <summary>
        /// When the user clicks their mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrdersGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(OrdersGrid, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// When the user selects soemthing from the Context Menu Strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = OrdersGrid.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = OrdersGrid.HitTest(e.X, e.Y).ColumnIndex;


        }

        /// <summary>
        /// When the user clicks on the copy option in the Context Menu Strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            foreach (DataGridViewCell cell in OrdersGrid.SelectedCells)
            {
                if (cell.ValueType.ToString() == "System.String")
                {
                    Clipboard.SetText(Clipboard.GetText() + " " + cell.Value.ToString());
                }
                else if (cell.ValueType.ToString() == "System.Drawing.Image")
                {
                    Clipboard.SetImage((Image)OrdersGrid.Rows[cell.RowIndex].Cells["Picture"].Value);
                }
            }

            foreach (DataGridViewColumn column in OrdersGrid.SelectedColumns)
            {
                Clipboard.SetText(column.Name);
            }

        }

        /// <summary>
        /// When the user clicks on the paste option in the Context Menu Strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in OrdersGrid.SelectedCells)
            {
                cell.Value = Clipboard.GetText();
            }
        }
        #endregion

        /// <summary>
        /// When the user clicks on a column header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OrdersGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //}

        /// <summary>
        /// Event Handler for when a key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //Deletes row selected when delete key is pressed
        //    if (e.KeyCode == Keys.Delete && OrdersGrid.SelectedRows.Count > 0)
        //    {
        //        RemoveOrderbyRow();
        //        UpdateSQL();
        //    }
        //}

        /// <summary>
        /// Applies changes to the SQL server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        /// <summary>
        /// removes a work order from the table
        /// </summary>
        /// <param name = "sender" ></ param >
        /// < param name="e"></param>
        //private void RemoveButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //checks if rows were selected
        //        if (OrdersGrid.SelectedRows.Count > 0)
        //        {
        //            RemoveOrderbyRow();
        //            UpdateSQL();
        //        }
        //        else if (OrdersGrid.SelectedCells.Count > 0)
        //        {
        //            RemoveOrderbyCell();
        //            UpdateSQL();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }


        //}

        //TODO Cell End Edit
        /// <summary>
        /// When the user finishes editing a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OrdersGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    //UpdateSQL();
        //    //try
        //    //{
        //    //UpdateSQL();
        //    //if (OrdersGrid.Rows.Count > GetScalarIntData("SELECT count(*) FROM [dbo].[WorkOrdersSQLTable]"))
        //    //{
        //    //    using (SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;"))
        //    //    {
        //    //        sqlConn.Open();
        //    //        using (SqlCommand cmd = new SqlCommand("INSERT INTO WorkOrdersSQLTable DEFAULT VALUES", sqlConn))
        //    //        {
        //    //            cmd.ExecuteNonQuery();
        //    //        }
        //    //        sqlConn.Close();
        //    //    }
        //    //}
        //    //UpdateSQL();

        //    //DataTable newRow = GetCustomData("SELECT TOP 1 * FROM WorkOrdersSQLTable WHERE WorkOrdersSQLTable.Timestamp < CURRENT_TIMESTAMP ORDER BY WorkOrdersSQLTable.Timestamp DESC");


        //    //Adds info into GUID column if null
        //    //if (string.IsNullOrEmpty(OrdersGrid.Rows[e.RowIndex].Cells["GUID"].Value.ToString()))
        //    //{
        //    //    OrdersGrid.Rows[e.RowIndex].Cells["GUID"].Value = newRow.Rows[0].ItemArray[0].ToString();
        //    //}

        //    //    //TODO timestamp
        //    //    //Adds info into Timestamp column if null
        //    //    if (string.IsNullOrEmpty(OrdersGrid.Rows[e.RowIndex].Cells["Timestamp"].Value.ToString()))
        //    //    {
        //    //        string UTC = newRow.Rows[0].ItemArray[10].ToString();
        //    //        DateTime UTCDate = DateTime.ParseExact(UTC, "M/d/yyyy h:m:s tt", null);
        //    //        TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        //    //        DateTime UTCtoCentral = TimeZoneInfo.ConvertTimeFromUtc(UTCDate, timeInfo);

        //    //        OrdersGrid.Rows[e.RowIndex].Cells["Timestamp"].Value = UTCtoCentral.ToString();
        //    //    }

        //    //    if (string.IsNullOrEmpty(OrdersGrid.Rows[e.RowIndex].Cells["Status"].Value.ToString()))
        //    //    {
        //    //        OrdersGrid.Rows[e.RowIndex].Cells["Status"].Value = newRow.Rows[0].ItemArray[8].ToString();
        //    //    }

        //    //    //Adds info into Picture column if null
        //    //    if (OrdersGrid.Rows[e.RowIndex].Cells["Picture"].Value == null)
        //    //    {
        //    //        string uniqueFileName = OrdersGrid.Rows[e.RowIndex].Cells["GUID"].Value.ToString().Replace("-", "") + "-nullImage.jpg";

        //    //        //downloads nullimage and reuploads the image with the order's GUID in the name
        //    //        Stream pic = BlobClient.DownloadFileToStream("workorderimages", "nullImage.jpg");
        //    //        BlobClient.UploadFileFromStream("workorderimages", uniqueFileName, pic, Blob.Tier.Hot);

        //    //        //Adds nullImage to the grid
        //    //        OrdersGrid.Rows[e.RowIndex].Cells["Picture"].Value = Image.FromStream(pic);
        //    //        OrdersGrid.Rows[e.RowIndex].Cells["Images"].Value = uniqueFileName;
        //    //    }
        //    //}   
        //    //catch (Exception ex)
        //    //{
        //    //MessageBox.Show(ex.Message);
        //    //}
        //    //UpdateSQL();

        //    //if (OrdersGrid.Rows.Count > GetScalarIntData("SELECT count(*) FROM[dbo].[WorkOrdersSQLTable]"))
        //    //{
        //    //    OrdersGrid.DataSource = null;
        //    //    if (OrdersGrid.Columns.Contains("Picture") == true)
        //    //    {
        //    //        OrdersGrid.Columns.RemoveAt(OrdersGrid.Columns["Picture"].Index);
        //    //    }

        //    //    DataTable dt = GetData();
        //    //    bs = new BindingSource(dt, null);
        //    //    OrdersGrid.DataSource = bs;

        //    //}
        //}


        /// <summary>
        /// When the user adds in a new row/order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OrdersGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{


        //    //string GUID = NewGUID();

        //    ////Removes row from SQL
        //    //using (SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;"))
        //    //{
        //    //    sqlConn.Open();
        //    //    using (SqlCommand cmd = new SqlCommand("INSERT INTO WorkOrdersSQLTable ([GUID], [Status], ", sqlConn))
        //    //    {
        //    //        cmd.ExecuteNonQuery();
        //    //    }
        //    //    sqlConn.Close();
        //    //}

        //    ////downloads nullimage in the name of the new GUID for later refrence
        //    //Stream pic = BlobClient.DownloadFileToStream("workorderimages", "nullImage.jpg");
        //    //BlobClient.UploadFileFromStream("workorderimages", GUID, pic, Blob.Tier.Hot);

        //    ////Adds nullImage to the grid
        //    //OrdersGrid.Rows[e.RowIndex - 1].Cells["Images"].Value = Image.FromStream(pic);
        //    //updateSQL();


        //    ////if (userAddingRow)
        //    ////{
        //    ////    string GUID = NewGUID();
        //    ////    string timestamp = CurrentDate();

        //    ////    OrdersGrid.Rows[e.RowIndex - 1].Cells["GUID"].Value = GUID;
        //    ////    OrdersGrid.Rows[e.RowIndex - 1].Cells["Timestamp"].Value = timestamp;
        //    ////    setStatusToNew(e.RowIndex - 1);

        //    ////    //downloads nullimage in the name of the new GUID for later refrence
        //    ////    Stream pic = BlobClient.DownloadFileToStream("workorderimages", "nullImage.jpg");
        //    ////    BlobClient.UploadFileFromStream("workorderimages", GUID, pic, Blob.Tier.Hot);

        //    ////    //Adds nullImage to the grid
        //    ////    OrdersGrid.Rows[e.RowIndex - 1].Cells["Images"].Value = Image.FromStream(pic);
        //    ////    updateSQL();
        //    ////}

        //}





        /// <summary>
        /// Set's the value of a cell of the status Column to read "New"
        /// </summary>
        /// <param name="rowIndex"></param>
        //public void setStatusToNew(int rowIndex)
        //{
        //    DataGridViewComboBoxCell status = new DataGridViewComboBoxCell();
        //    {
        //        status.Items.Add("New");
        //        status.Items.Add("Working");
        //        status.Items.Add("Completed");
        //    }
        //    OrdersGrid.Rows[rowIndex].Cells["Status"].Value = status.Items[0];
        //}

        /// <summary>
        /// Returns the index of the Status column since "Cells["Status"]" doesnt work
        /// </summary>
        /// <returns></returns>
        //public int getStatusColIndex()
        //{
        //    foreach (DataGridViewColumn column in OrdersGrid.Columns)
        //    {
        //        if (column.Name == "Status")
        //        {
        //            return column.Index;
        //        }
        //    }
        //    return -1;
        //}

        /// <summary>
        /// returns the file type as a string
        /// </summary>
        /// <param name="save"></param>
        /// <returns></returns>
        //public string getFileType(SaveFileDialog save)
        //{
        //    return (save.FileName.Split('.').Last());
        //}

        //public Image gettestImage()
        //{
        //    Image Loadpic = Bitmap.FromStream(BlobClient.DownloadFileToStream("workorderimages", "test.jfif"));
        //    return Loadpic;
        //}

        //public Image getnullImage()
        //{
        //    Image Loadpic = Bitmap.FromStream(BlobClient.DownloadFileToStream("workorderimages", "nullImage.jpg"));
        //    return Loadpic;
        //}

        //public string NewGUID()
        //{
        //    return Guid.NewGuid().ToString();
        //}

        //public string CurrentDate()
        //{
        //    return DateTime.Now.ToString();
        //}



        //public void RemoveOrderbyCell()
        //{
        //    string cellGUID;
        //    foreach (DataGridViewCell cell in OrdersGrid.SelectedCells)
        //    {
        //        //Grabs the GUID of the row for reference to delete from SQL table
        //        cellGUID = OrdersGrid.Rows[cell.RowIndex].Cells["GUID"].Value.ToString();

        //        //removes the row of the Contact
        //        OrdersGrid.Rows.RemoveAt(cell.RowIndex);

        //        //Removes row from SQL
        //        using (SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;"))
        //        {
        //            sqlConn.Open();
        //            using (SqlCommand cmd = new SqlCommand("DELETE FROM WorkOrdersSQLTable WHERE GUID" + " = " + "'" + cellGUID + "'", sqlConn))
        //            {
        //                cmd.ExecuteNonQuery();
        //            }
        //            sqlConn.Close();
        //        }

        //        //Removes picture from BlobStorage
        //        BlobClient.DeleteFile("workorderimages", cellGUID);
        //    }

        //}

        //public void RemoveOrderbyRow()
        //{
        //    string rowGUID;
        //    //loops through all the user selected rows and deletes them
        //    foreach (DataGridViewRow row in OrdersGrid.SelectedRows)
        //    {
        //        //Grabs the GUID of the row for reference to delete from SQL table
        //        rowGUID = row.Cells["GUID"].Value.ToString();

        //        //removes the row of the Contact
        //        OrdersGrid.Rows.RemoveAt(row.Index);

        //        //Removes row from SQL
        //        using (SqlConnection sqlConn = new SqlConnection("Data Source=14.0.0.30;Initial Catalog=WorkOrdersSQL;User id=sa;Password=Wire81Networking;"))
        //        {
        //            sqlConn.Open();
        //            using (SqlCommand cmd = new SqlCommand("DELETE FROM WorkOrdersSQLTable WHERE GUID = " + "'" + rowGUID + "'", sqlConn))
        //            {
        //                cmd.ExecuteNonQuery();
        //            }
        //            sqlConn.Close();
        //        }

        //        //Removes picture from BlobStorage
        //        BlobClient.DeleteFile("workorderimages", rowGUID);
        //    }
        //}

        //TODO UpdateSQL
        /// <summary>
        /// Updates the SQL table with the data from Ordersgrid
        /// </summary>




        //private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        //{

        //}


    }


}

