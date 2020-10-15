namespace Work_Orders
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.StatusSelector = new System.Windows.Forms.ListBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PictureFileButton = new System.Windows.Forms.Button();
            this.DueDateInput = new System.Windows.Forms.DateTimePicker();
            this.StreetInput = new System.Windows.Forms.TextBox();
            this.CityInput = new System.Windows.Forms.TextBox();
            this.StateInput = new System.Windows.Forms.TextBox();
            this.ZIPInput = new System.Windows.Forms.TextBox();
            this.FirstNameInput = new System.Windows.Forms.TextBox();
            this.LastNameInput = new System.Windows.Forms.TextBox();
            this.CompanyInput = new System.Windows.Forms.TextBox();
            this.CampaignInput = new System.Windows.Forms.TextBox();
            this.OrderNameInput = new System.Windows.Forms.TextBox();
            this.OrderTypeInput = new System.Windows.Forms.TextBox();
            this.DescriptionInput = new System.Windows.Forms.TextBox();
            this.OrderNumberInput = new System.Windows.Forms.TextBox();
            this.StateLabel = new System.Windows.Forms.Label();
            this.ZIPLabel = new System.Windows.Forms.Label();
            this.PictureLabel = new System.Windows.Forms.Label();
            this.DueDateLabel = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.StreetLabel = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.CampaignLabel = new System.Windows.Forms.Label();
            this.OrderNameLabel = new System.Windows.Forms.Label();
            this.OrderTypeLabel = new System.Windows.Forms.Label();
            this.OrderNumberLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(557, 265);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(68, 52);
            this.PictureBox.TabIndex = 72;
            this.PictureBox.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(472, 328);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 71;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(391, 328);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 70;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OKButton_KeyDown);
            // 
            // StatusSelector
            // 
            this.StatusSelector.FormattingEnabled = true;
            this.StatusSelector.Items.AddRange(new object[] {
            "New",
            "Working",
            "Completed"});
            this.StatusSelector.Location = new System.Drawing.Point(177, 324);
            this.StatusSelector.Name = "StatusSelector";
            this.StatusSelector.Size = new System.Drawing.Size(59, 43);
            this.StatusSelector.TabIndex = 69;
            this.StatusSelector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StatusSelector_KeyDown);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 324);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(77, 25);
            this.StatusLabel.TabIndex = 68;
            this.StatusLabel.Text = "Status:";
            // 
            // PictureFileButton
            // 
            this.PictureFileButton.Location = new System.Drawing.Point(442, 283);
            this.PictureFileButton.Name = "PictureFileButton";
            this.PictureFileButton.Size = new System.Drawing.Size(100, 23);
            this.PictureFileButton.TabIndex = 67;
            this.PictureFileButton.Text = "Choose Image...";
            this.PictureFileButton.UseVisualStyleBackColor = true;
            this.PictureFileButton.Click += new System.EventHandler(this.PictureFileButton_Click_1);
            this.PictureFileButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PictureFileButton_KeyDown);
            // 
            // DueDateInput
            // 
            this.DueDateInput.Location = new System.Drawing.Point(442, 15);
            this.DueDateInput.Name = "DueDateInput";
            this.DueDateInput.Size = new System.Drawing.Size(200, 20);
            this.DueDateInput.TabIndex = 66;
            this.DueDateInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DueDateInput_KeyDown);
            // 
            // StreetInput
            // 
            this.StreetInput.Location = new System.Drawing.Point(442, 104);
            this.StreetInput.Name = "StreetInput";
            this.StreetInput.Size = new System.Drawing.Size(100, 20);
            this.StreetInput.TabIndex = 65;
            this.StreetInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StreetInput_KeyDown);
            // 
            // CityInput
            // 
            this.CityInput.Location = new System.Drawing.Point(442, 148);
            this.CityInput.Name = "CityInput";
            this.CityInput.Size = new System.Drawing.Size(100, 20);
            this.CityInput.TabIndex = 64;
            this.CityInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CityInput_KeyDown);
            // 
            // StateInput
            // 
            this.StateInput.Location = new System.Drawing.Point(442, 194);
            this.StateInput.Name = "StateInput";
            this.StateInput.Size = new System.Drawing.Size(100, 20);
            this.StateInput.TabIndex = 63;
            this.StateInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StateInput_KeyDown);
            // 
            // ZIPInput
            // 
            this.ZIPInput.Location = new System.Drawing.Point(442, 239);
            this.ZIPInput.Name = "ZIPInput";
            this.ZIPInput.Size = new System.Drawing.Size(100, 20);
            this.ZIPInput.TabIndex = 62;
            this.ZIPInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZIPInput_KeyDown);
            // 
            // FirstNameInput
            // 
            this.FirstNameInput.Location = new System.Drawing.Point(177, 15);
            this.FirstNameInput.Name = "FirstNameInput";
            this.FirstNameInput.Size = new System.Drawing.Size(100, 20);
            this.FirstNameInput.TabIndex = 61;
            this.FirstNameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FirstNameInput_KeyDown);
            // 
            // LastNameInput
            // 
            this.LastNameInput.Location = new System.Drawing.Point(177, 59);
            this.LastNameInput.Name = "LastNameInput";
            this.LastNameInput.Size = new System.Drawing.Size(100, 20);
            this.LastNameInput.TabIndex = 60;
            this.LastNameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastNameInput_KeyDown);
            // 
            // CompanyInput
            // 
            this.CompanyInput.Location = new System.Drawing.Point(177, 104);
            this.CompanyInput.Name = "CompanyInput";
            this.CompanyInput.Size = new System.Drawing.Size(100, 20);
            this.CompanyInput.TabIndex = 59;
            this.CompanyInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompanyInput_KeyDown);
            // 
            // CampaignInput
            // 
            this.CampaignInput.Location = new System.Drawing.Point(177, 149);
            this.CampaignInput.Name = "CampaignInput";
            this.CampaignInput.Size = new System.Drawing.Size(100, 20);
            this.CampaignInput.TabIndex = 58;
            this.CampaignInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CampaignInput_KeyDown);
            // 
            // OrderNameInput
            // 
            this.OrderNameInput.Location = new System.Drawing.Point(177, 194);
            this.OrderNameInput.Name = "OrderNameInput";
            this.OrderNameInput.Size = new System.Drawing.Size(100, 20);
            this.OrderNameInput.TabIndex = 57;
            this.OrderNameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderNameInput_KeyDown);
            // 
            // OrderTypeInput
            // 
            this.OrderTypeInput.Location = new System.Drawing.Point(177, 239);
            this.OrderTypeInput.Name = "OrderTypeInput";
            this.OrderTypeInput.Size = new System.Drawing.Size(100, 20);
            this.OrderTypeInput.TabIndex = 56;
            this.OrderTypeInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderTypeInput_KeyDown);
            // 
            // DescriptionInput
            // 
            this.DescriptionInput.Location = new System.Drawing.Point(442, 59);
            this.DescriptionInput.Name = "DescriptionInput";
            this.DescriptionInput.Size = new System.Drawing.Size(100, 20);
            this.DescriptionInput.TabIndex = 55;
            this.DescriptionInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DescriptionInput_KeyDown);
            // 
            // OrderNumberInput
            // 
            this.OrderNumberInput.Location = new System.Drawing.Point(177, 283);
            this.OrderNumberInput.Name = "OrderNumberInput";
            this.OrderNumberInput.Size = new System.Drawing.Size(100, 20);
            this.OrderNumberInput.TabIndex = 54;
            this.OrderNumberInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderNumberInput_KeyDown);
            // 
            // StateLabel
            // 
            this.StateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StateLabel.AutoSize = true;
            this.StateLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateLabel.Location = new System.Drawing.Point(309, 188);
            this.StateLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(66, 25);
            this.StateLabel.TabIndex = 53;
            this.StateLabel.Text = "State:";
            // 
            // ZIPLabel
            // 
            this.ZIPLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ZIPLabel.AutoSize = true;
            this.ZIPLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZIPLabel.Location = new System.Drawing.Point(309, 233);
            this.ZIPLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.ZIPLabel.Name = "ZIPLabel";
            this.ZIPLabel.Size = new System.Drawing.Size(53, 25);
            this.ZIPLabel.TabIndex = 52;
            this.ZIPLabel.Text = "ZIP:";
            // 
            // PictureLabel
            // 
            this.PictureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureLabel.AutoSize = true;
            this.PictureLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PictureLabel.Location = new System.Drawing.Point(309, 278);
            this.PictureLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.PictureLabel.Name = "PictureLabel";
            this.PictureLabel.Size = new System.Drawing.Size(87, 25);
            this.PictureLabel.TabIndex = 51;
            this.PictureLabel.Text = "Images:";
            // 
            // DueDateLabel
            // 
            this.DueDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DueDateLabel.AutoSize = true;
            this.DueDateLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DueDateLabel.Location = new System.Drawing.Point(309, 9);
            this.DueDateLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.DueDateLabel.Name = "DueDateLabel";
            this.DueDateLabel.Size = new System.Drawing.Size(106, 25);
            this.DueDateLabel.TabIndex = 50;
            this.DueDateLabel.Text = "Due Date:";
            // 
            // Description
            // 
            this.Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(309, 53);
            this.Description.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(127, 25);
            this.Description.TabIndex = 49;
            this.Description.Text = "Description:";
            // 
            // StreetLabel
            // 
            this.StreetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreetLabel.AutoSize = true;
            this.StreetLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StreetLabel.Location = new System.Drawing.Point(309, 98);
            this.StreetLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.StreetLabel.Name = "StreetLabel";
            this.StreetLabel.Size = new System.Drawing.Size(74, 25);
            this.StreetLabel.TabIndex = 48;
            this.StreetLabel.Text = "Street:";
            // 
            // CityLabel
            // 
            this.CityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CityLabel.AutoSize = true;
            this.CityLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CityLabel.Location = new System.Drawing.Point(309, 143);
            this.CityLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(55, 25);
            this.CityLabel.TabIndex = 47;
            this.CityLabel.Text = "City:";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(12, 54);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(120, 25);
            this.LastNameLabel.TabIndex = 46;
            this.LastNameLabel.Text = "Last Name:";
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyLabel.Location = new System.Drawing.Point(12, 99);
            this.CompanyLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(107, 25);
            this.CompanyLabel.TabIndex = 45;
            this.CompanyLabel.Text = "Company:";
            // 
            // CampaignLabel
            // 
            this.CampaignLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CampaignLabel.AutoSize = true;
            this.CampaignLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampaignLabel.Location = new System.Drawing.Point(12, 144);
            this.CampaignLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.CampaignLabel.Name = "CampaignLabel";
            this.CampaignLabel.Size = new System.Drawing.Size(114, 25);
            this.CampaignLabel.TabIndex = 44;
            this.CampaignLabel.Text = "Campaign:";
            // 
            // OrderNameLabel
            // 
            this.OrderNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderNameLabel.AutoSize = true;
            this.OrderNameLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderNameLabel.Location = new System.Drawing.Point(12, 189);
            this.OrderNameLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.OrderNameLabel.Name = "OrderNameLabel";
            this.OrderNameLabel.Size = new System.Drawing.Size(136, 25);
            this.OrderNameLabel.TabIndex = 43;
            this.OrderNameLabel.Text = "Order Name:";
            // 
            // OrderTypeLabel
            // 
            this.OrderTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderTypeLabel.AutoSize = true;
            this.OrderTypeLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderTypeLabel.Location = new System.Drawing.Point(12, 234);
            this.OrderTypeLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.OrderTypeLabel.Name = "OrderTypeLabel";
            this.OrderTypeLabel.Size = new System.Drawing.Size(125, 25);
            this.OrderTypeLabel.TabIndex = 42;
            this.OrderTypeLabel.Text = "Order Type:";
            // 
            // OrderNumberLabel
            // 
            this.OrderNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderNumberLabel.AutoSize = true;
            this.OrderNumberLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderNumberLabel.Location = new System.Drawing.Point(12, 279);
            this.OrderNumberLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.OrderNumberLabel.Name = "OrderNumberLabel";
            this.OrderNumberLabel.Size = new System.Drawing.Size(158, 25);
            this.OrderNumberLabel.TabIndex = 41;
            this.OrderNumberLabel.Text = "Order Number:";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(12, 9);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(124, 25);
            this.FirstNameLabel.TabIndex = 40;
            this.FirstNameLabel.Text = "First Name:";
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            this.openFile.Filter = "\"bmp files(*.bmp)| *.bmp | JPEG files(*.jpg) | *.jpg | BMP files(*.bmp) | *.bmp |" +
    " JFIF File(*.jfif) | *.jfif| All files (*.*)|*.*\"";
            this.openFile.Title = "Select an Image";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 380);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.StatusSelector);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.PictureFileButton);
            this.Controls.Add(this.DueDateInput);
            this.Controls.Add(this.StreetInput);
            this.Controls.Add(this.CityInput);
            this.Controls.Add(this.StateInput);
            this.Controls.Add(this.ZIPInput);
            this.Controls.Add(this.FirstNameInput);
            this.Controls.Add(this.LastNameInput);
            this.Controls.Add(this.CompanyInput);
            this.Controls.Add(this.CampaignInput);
            this.Controls.Add(this.OrderNameInput);
            this.Controls.Add(this.OrderTypeInput);
            this.Controls.Add(this.DescriptionInput);
            this.Controls.Add(this.OrderNumberInput);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.ZIPLabel);
            this.Controls.Add(this.PictureLabel);
            this.Controls.Add(this.DueDateLabel);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.StreetLabel);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.CompanyLabel);
            this.Controls.Add(this.CampaignLabel);
            this.Controls.Add(this.OrderNameLabel);
            this.Controls.Add(this.OrderTypeLabel);
            this.Controls.Add(this.OrderNumberLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.MaximumSize = new System.Drawing.Size(672, 419);
            this.MinimumSize = new System.Drawing.Size(672, 419);
            this.Name = "AddForm";
            this.Text = "Add ";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.ListBox StatusSelector;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button PictureFileButton;
        private System.Windows.Forms.DateTimePicker DueDateInput;
        private System.Windows.Forms.TextBox StreetInput;
        private System.Windows.Forms.TextBox CityInput;
        private System.Windows.Forms.TextBox StateInput;
        private System.Windows.Forms.TextBox ZIPInput;
        private System.Windows.Forms.TextBox FirstNameInput;
        private System.Windows.Forms.TextBox LastNameInput;
        private System.Windows.Forms.TextBox CompanyInput;
        private System.Windows.Forms.TextBox CampaignInput;
        private System.Windows.Forms.TextBox OrderNameInput;
        private System.Windows.Forms.TextBox OrderTypeInput;
        private System.Windows.Forms.TextBox DescriptionInput;
        private System.Windows.Forms.TextBox OrderNumberInput;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Label ZIPLabel;
        private System.Windows.Forms.Label PictureLabel;
        private System.Windows.Forms.Label DueDateLabel;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label StreetLabel;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.Label CampaignLabel;
        private System.Windows.Forms.Label OrderNameLabel;
        private System.Windows.Forms.Label OrderTypeLabel;
        private System.Windows.Forms.Label OrderNumberLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.OpenFileDialog openFile;
    }
}