using System;
using System.Windows.Forms;

namespace Work_Orders
{
    public partial class frmStatusChanger : Form
    {
        public string status { get; set; }

        public frmStatusChanger()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            status = cmboStatus.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            status = "";
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void CmboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = cmboStatus.SelectedItem.ToString();
        }

        private void FrmStatusChanger_Load(object sender, EventArgs e)
        {
            cmboStatus.Items.Clear();
            cmboStatus.Items.Add("New");
            cmboStatus.Items.Add("Working");
            cmboStatus.Items.Add("Completed");
            cmboStatus.SelectedIndex = 0;
        }

    }
}
