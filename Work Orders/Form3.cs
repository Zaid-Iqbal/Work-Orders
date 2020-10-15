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
    public partial class DueDateEditForm : Form
    {
        public DueDateEditForm()
        {
            InitializeComponent();
            OKButton.DialogResult = DialogResult.OK;
            CancelButton.DialogResult = DialogResult.Cancel;

            DueDatePicker.Format = DateTimePickerFormat.Custom;
            DueDatePicker.CustomFormat = "MM/d/yyyy h:m:s tt";
        }

        public string getDueDate
        {
            get
            {
                return DueDatePicker.Value.ToString();
            }
        }
    }
}
