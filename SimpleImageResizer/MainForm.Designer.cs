namespace SimpleImageResizer
{
	partial class MainForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.changeDirButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.subDirsCheckBox = new System.Windows.Forms.CheckBox();
            this.resizeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.maskTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.progressInfoLabel = new System.Windows.Forms.Label();
            this.interpolationTypeLabel = new System.Windows.Forms.Label();
            this.interpolationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.qualityLabel = new System.Windows.Forms.Label();
            this.qualityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.outputFormatComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dirTextBox
            // 
            this.dirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirTextBox.Location = new System.Drawing.Point(12, 25);
            this.dirTextBox.Name = "dirTextBox";
            this.dirTextBox.Size = new System.Drawing.Size(490, 20);
            this.dirTextBox.TabIndex = 0;
            this.dirTextBox.TextChanged += new System.EventHandler(this.dirTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Каталог:";
            // 
            // changeDirButton
            // 
            this.changeDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeDirButton.Location = new System.Drawing.Point(508, 23);
            this.changeDirButton.Name = "changeDirButton";
            this.changeDirButton.Size = new System.Drawing.Size(24, 23);
            this.changeDirButton.TabIndex = 1;
            this.changeDirButton.Text = "...";
            this.changeDirButton.UseVisualStyleBackColor = true;
            this.changeDirButton.Click += new System.EventHandler(this.changeDirButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Выберите папку с графическими файлами, которые необходимо преобразовать:";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // subDirsCheckBox
            // 
            this.subDirsCheckBox.AutoSize = true;
            this.subDirsCheckBox.Checked = true;
            this.subDirsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.subDirsCheckBox.Location = new System.Drawing.Point(236, 53);
            this.subDirsCheckBox.Name = "subDirsCheckBox";
            this.subDirsCheckBox.Size = new System.Drawing.Size(137, 17);
            this.subDirsCheckBox.TabIndex = 3;
            this.subDirsCheckBox.Text = "Включая подкаталоги";
            this.subDirsCheckBox.UseVisualStyleBackColor = true;
            // 
            // resizeButton
            // 
            this.resizeButton.Enabled = false;
            this.resizeButton.Location = new System.Drawing.Point(12, 181);
            this.resizeButton.Name = "resizeButton";
            this.resizeButton.Size = new System.Drawing.Size(143, 23);
            this.resizeButton.TabIndex = 5;
            this.resizeButton.Text = "Изменить размер";
            this.resizeButton.UseVisualStyleBackColor = true;
            this.resizeButton.Click += new System.EventHandler(this.resizeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Результат работы:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 210);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(520, 23);
            this.progressBar.TabIndex = 6;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Location = new System.Drawing.Point(12, 265);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(520, 140);
            this.logTextBox.TabIndex = 7;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(161, 181);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Входной формат:";
            // 
            // maskTextBox
            // 
            this.maskTextBox.Location = new System.Drawing.Point(120, 51);
            this.maskTextBox.Name = "maskTextBox";
            this.maskTextBox.Size = new System.Drawing.Size(74, 20);
            this.maskTextBox.TabIndex = 2;
            this.maskTextBox.Text = "*.jpg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ширина:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Высота:";
            // 
            // maxWidthNumericUpDown
            // 
            this.maxWidthNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxWidthNumericUpDown.Location = new System.Drawing.Point(61, 19);
            this.maxWidthNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxWidthNumericUpDown.Name = "maxWidthNumericUpDown";
            this.maxWidthNumericUpDown.Size = new System.Drawing.Size(74, 20);
            this.maxWidthNumericUpDown.TabIndex = 0;
            this.maxWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxWidthNumericUpDown.ThousandsSeparator = true;
            this.maxWidthNumericUpDown.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // maxHeightNumericUpDown
            // 
            this.maxHeightNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxHeightNumericUpDown.Location = new System.Drawing.Point(61, 45);
            this.maxHeightNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxHeightNumericUpDown.Name = "maxHeightNumericUpDown";
            this.maxHeightNumericUpDown.Size = new System.Drawing.Size(74, 20);
            this.maxHeightNumericUpDown.TabIndex = 2;
            this.maxHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxHeightNumericUpDown.ThousandsSeparator = true;
            this.maxHeightNumericUpDown.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // progressInfoLabel
            // 
            this.progressInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressInfoLabel.Location = new System.Drawing.Point(330, 236);
            this.progressInfoLabel.Name = "progressInfoLabel";
            this.progressInfoLabel.Size = new System.Drawing.Size(202, 13);
            this.progressInfoLabel.TabIndex = 10;
            this.progressInfoLabel.Text = "0/0";
            this.progressInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // interpolationTypeLabel
            // 
            this.interpolationTypeLabel.AutoSize = true;
            this.interpolationTypeLabel.Location = new System.Drawing.Point(161, 21);
            this.interpolationTypeLabel.Name = "interpolationTypeLabel";
            this.interpolationTypeLabel.Size = new System.Drawing.Size(48, 13);
            this.interpolationTypeLabel.TabIndex = 11;
            this.interpolationTypeLabel.Text = "Сжатие:";
            // 
            // interpolationTypeComboBox
            // 
            this.interpolationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationTypeComboBox.FormattingEnabled = true;
            this.interpolationTypeComboBox.Items.AddRange(new object[] {
            "Бикубическое",
            "Билинейное"});
            this.interpolationTypeComboBox.Location = new System.Drawing.Point(224, 18);
            this.interpolationTypeComboBox.Name = "interpolationTypeComboBox";
            this.interpolationTypeComboBox.Size = new System.Drawing.Size(118, 21);
            this.interpolationTypeComboBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.interpolationTypeComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.qualityLabel);
            this.groupBox1.Controls.Add(this.interpolationTypeLabel);
            this.groupBox1.Controls.Add(this.maxWidthNumericUpDown);
            this.groupBox1.Controls.Add(this.qualityNumericUpDown);
            this.groupBox1.Controls.Add(this.maxHeightNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(12, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 71);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры преобразования";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "%";
            // 
            // qualityLabel
            // 
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.Location = new System.Drawing.Point(161, 47);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Size = new System.Drawing.Size(57, 13);
            this.qualityLabel.TabIndex = 11;
            this.qualityLabel.Text = "Качество:";
            // 
            // qualityNumericUpDown
            // 
            this.qualityNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.qualityNumericUpDown.Location = new System.Drawing.Point(224, 45);
            this.qualityNumericUpDown.Name = "qualityNumericUpDown";
            this.qualityNumericUpDown.Size = new System.Drawing.Size(74, 20);
            this.qualityNumericUpDown.TabIndex = 3;
            this.qualityNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.qualityNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // outputFormatComboBox
            // 
            this.outputFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputFormatComboBox.FormattingEnabled = true;
            this.outputFormatComboBox.Items.AddRange(new object[] {
            "JPEG",
            "PNG",
            "BMP",
            "GIF",
            "TIFF",
            "EMF",
            "EXIF",
            "WMF"});
            this.outputFormatComboBox.Location = new System.Drawing.Point(120, 77);
            this.outputFormatComboBox.Name = "outputFormatComboBox";
            this.outputFormatComboBox.Size = new System.Drawing.Size(74, 21);
            this.outputFormatComboBox.TabIndex = 4;
            this.outputFormatComboBox.SelectedIndexChanged += new System.EventHandler(this.outputFormatComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Выходной формат:";
            // 
            // MainForm
            // 
            this.AcceptButton = this.resizeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(544, 417);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.outputFormatComboBox);
            this.Controls.Add(this.progressInfoLabel);
            this.Controls.Add(this.maskTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resizeButton);
            this.Controls.Add(this.subDirsCheckBox);
            this.Controls.Add(this.changeDirButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(395, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Image Resizer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHeightNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qualityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox dirTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button changeDirButton;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.CheckBox subDirsCheckBox;
		private System.Windows.Forms.Button resizeButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox maskTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown maxWidthNumericUpDown;
		private System.Windows.Forms.NumericUpDown maxHeightNumericUpDown;
		private System.Windows.Forms.Label progressInfoLabel;
		private System.Windows.Forms.Label interpolationTypeLabel;
		private System.Windows.Forms.ComboBox interpolationTypeComboBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label qualityLabel;
		private System.Windows.Forms.NumericUpDown qualityNumericUpDown;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox outputFormatComboBox;
		private System.Windows.Forms.Label label9;
	}
}

