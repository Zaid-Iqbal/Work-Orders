using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Work_Orders
{
    public partial class AddForm : Form
    {
        Image pic;
        string pictureName;

        public AddForm()
        {
            InitializeComponent();
            OKButton.DialogResult = DialogResult.OK;
            CancelButton.DialogResult = DialogResult.Cancel;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            StatusSelector.Focus();
        }

        #region gets

        public string getFirstName
        {
            get
            {
                return FirstNameInput.Text;
            }
        }

        public string getLastName
        {
            get
            {
                return LastNameInput.Text;
            }
        }

        public string getCompany
        {
            get
            {
                return CompanyInput.Text;
            }
        }

        public string getCampaign
        {
            get
            {
                return CampaignInput.Text;
            }
        }

        public string getOrderName
        {
            get
            {
                return OrderNameInput.Text;
            }
        }

        public string getOrderType
        {
            get
            {
                return OrderTypeInput.Text;
            }
        }

        public string getOrderNumber
        {
            get
            {
                return OrderNumberInput.Text;
                
            }
        }

        public string getStatus
        {
            get
            {
                return StatusSelector.Text;
            }
        }

        public string getDueDate
        {
            get
            {
                return DueDateInput.Value.ToString();
            }
        }

        public string getTimestamp
        {
            get
            {
                return DateTime.Now.ToString();
            }
        }

        public string getDescription
        {
            get
            {
                return DescriptionInput.Text;
            }
        }

        public string getStreet
        {
            get
            {
                return StreetInput.Text;
            }
        }

        public string getCity
        {
            get
            {
                return CityInput.Text;
            }
        }

        public string getState
        {
            get
            {
                return StateInput.Text;
            }
        }

        public string getZIP
        {
            get
            {
                return ZIPInput.Text;
            }
        }

        public Image getPicture
        {
            get
            {
                return pic;
            }
        }

        public string getPictureFileName
        {
            get
            {
                return pictureName;
            }
        }

        /// <summary>
        /// saves a picture as the "image" datatype 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "bmp files(*.bmp)| *.bmp | JPEG files(*.jpg) | *.jpg | BMP files(*.bmp) | *.bmp | JFIF File(*.jfif) | *.jfif| All files (*.*)|*.*";
            open.Title = "Select an Image";
            open.InitialDirectory = @"C:\";

            if (open.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(open.FileName);
                pictureName = getFileName(open.FileName);
                PictureBox.Image = pic;
            }

        }




        #endregion

        #region keypresses

        private void FirstNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                LastNameInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                OKButton.Focus();
            }
        }

        private void LastNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                CompanyInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                FirstNameInput.Focus();
            }
        }

        private void CompanyInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                CampaignInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                LastNameInput.Focus();
            }
        }

        private void CampaignInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                OrderNameInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                CompanyInput.Focus();
            }
        }

        private void OrderNameInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                OrderTypeInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                CampaignInput.Focus();
            }
        }

        private void OrderTypeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                OrderNumberInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                OrderNameInput.Focus();
            }
        }

        private void OrderNumberInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                StatusSelector.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                OrderTypeInput.Focus();
            }
        }

        private void StatusSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DueDateInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                OrderNumberInput.Focus();
            }
        }

        private void DueDateInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DescriptionInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                StatusSelector.Focus();
            }
        }

        private void DescriptionInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                StreetInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                DueDateInput.Focus();
            }
        }

        private void StreetInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                CityInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                DescriptionInput.Focus();
            }
        }

        private void CityInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                StateInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                StreetInput.Focus();
            }
        }

        private void StateInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ZIPInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                CityInput.Focus();
            }
        }

        private void ZIPInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                PictureFileButton.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                StateInput.Focus();
            }
        }

        private void PictureFileButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                OKButton.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                ZIPInput.Focus();
            }
        }

        private void OKButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                FirstNameInput.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                PictureFileButton.Focus();
            }
        }

        #endregion

        #region buttons
        private void PictureFileButton_Click_1(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pic = Image.FromFile(openFile.FileName);
                    PictureBox.Image = pic;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Unable to opne image. Make sure the image is in bmp, jpg, or jfif format.\nError Message: " + error.Message);
                }
            }
        }
        #endregion

        public string getFileName(string filepath)
        {
            int pos = filepath.LastIndexOf(@"\") + 1;
            return (filepath.Substring(pos, filepath.Length - pos));
        }

        
    }
}
