namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    partial class CharacterMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterMaker));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serverSubmissionButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rankLabel = new System.Windows.Forms.Label();
            this.alignmentLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.saveExcelButton = new System.Windows.Forms.Button();
            this.loadExcelButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.libraryView = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rankColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alignmentColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schoolColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.masteryComboBox = new System.Windows.Forms.ComboBox();
            this.abilityDescriptionBox = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.googleDriveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.companionButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.characterDetailsButton = new System.Windows.Forms.Button();
            this.clearSheetButton = new System.Windows.Forms.Button();
            this.characterAbilitiesView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openCharacterDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveExcel = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hardcorePointsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.08581F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.91419F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1515, 648);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serverSubmissionButton);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 639);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // serverSubmissionButton
            // 
            this.serverSubmissionButton.Enabled = false;
            this.serverSubmissionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverSubmissionButton.Location = new System.Drawing.Point(6, 582);
            this.serverSubmissionButton.Name = "serverSubmissionButton";
            this.serverSubmissionButton.Size = new System.Drawing.Size(251, 51);
            this.serverSubmissionButton.TabIndex = 1;
            this.serverSubmissionButton.Text = "Send Sheet to Server";
            this.serverSubmissionButton.UseVisualStyleBackColor = true;
            this.serverSubmissionButton.Click += new System.EventHandler(this.serverSubmissionButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.76353F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.23647F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(251, 557);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rankLabel);
            this.groupBox2.Controls.Add(this.alignmentLabel);
            this.groupBox2.Controls.Add(this.nameLabel);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 102);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Character Info";
            // 
            // rankLabel
            // 
            this.rankLabel.AutoSize = true;
            this.rankLabel.Location = new System.Drawing.Point(7, 72);
            this.rankLabel.Name = "rankLabel";
            this.rankLabel.Size = new System.Drawing.Size(39, 13);
            this.rankLabel.TabIndex = 2;
            this.rankLabel.Text = "Rank :";
            // 
            // alignmentLabel
            // 
            this.alignmentLabel.AutoSize = true;
            this.alignmentLabel.Location = new System.Drawing.Point(7, 43);
            this.alignmentLabel.Name = "alignmentLabel";
            this.alignmentLabel.Size = new System.Drawing.Size(59, 13);
            this.alignmentLabel.TabIndex = 1;
            this.alignmentLabel.Text = "Alignment :";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(7, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(41, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(3, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 228);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.saveExcelButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.loadExcelButton, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(233, 93);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // saveExcelButton
            // 
            this.saveExcelButton.Location = new System.Drawing.Point(3, 3);
            this.saveExcelButton.Name = "saveExcelButton";
            this.saveExcelButton.Size = new System.Drawing.Size(110, 87);
            this.saveExcelButton.TabIndex = 4;
            this.saveExcelButton.Text = "Save As Excel";
            this.saveExcelButton.UseVisualStyleBackColor = true;
            this.saveExcelButton.Click += new System.EventHandler(this.saveExcelButton_Click);
            // 
            // loadExcelButton
            // 
            this.loadExcelButton.Location = new System.Drawing.Point(119, 3);
            this.loadExcelButton.Name = "loadExcelButton";
            this.loadExcelButton.Size = new System.Drawing.Size(111, 87);
            this.loadExcelButton.TabIndex = 5;
            this.loadExcelButton.Text = "Load Excel";
            this.loadExcelButton.UseVisualStyleBackColor = true;
            this.loadExcelButton.Click += new System.EventHandler(this.loadExcelButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.logTextBox);
            this.groupBox4.Location = new System.Drawing.Point(3, 351);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(243, 117);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Log";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(6, 19);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(230, 94);
            this.logTextBox.TabIndex = 0;
            this.logTextBox.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(3, 474);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(243, 80);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 55);
            this.button1.TabIndex = 0;
            this.button1.Text = "Filters";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.libraryView, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.characterAbilitiesView, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(277, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1235, 642);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // libraryView
            // 
            this.libraryView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.rankColumn,
            this.alignmentColumn,
            this.schoolColumn});
            this.libraryView.HideSelection = false;
            this.libraryView.Location = new System.Drawing.Point(3, 3);
            this.libraryView.Name = "libraryView";
            this.libraryView.Size = new System.Drawing.Size(405, 636);
            this.libraryView.TabIndex = 0;
            this.libraryView.UseCompatibleStateImageBehavior = false;
            this.libraryView.View = System.Windows.Forms.View.Details;
            this.libraryView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.libraryView_ColumnClick);
            this.libraryView.Click += new System.EventHandler(this.libraryView_Click);
            this.libraryView.DoubleClick += new System.EventHandler(this.libraryView_DoubleClick);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 159;
            // 
            // rankColumn
            // 
            this.rankColumn.Text = "Rank";
            this.rankColumn.Width = 75;
            // 
            // alignmentColumn
            // 
            this.alignmentColumn.Text = "Alignment";
            this.alignmentColumn.Width = 67;
            // 
            // schoolColumn
            // 
            this.schoolColumn.Text = "School";
            this.schoolColumn.Width = 97;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox7, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(414, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.92453F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.07547F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(405, 636);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.searchBox);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.masteryComboBox);
            this.groupBox6.Controls.Add(this.abilityDescriptionBox);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(399, 422);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ability Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(9, 383);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(118, 20);
            this.searchBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ability Mastery";
            // 
            // masteryComboBox
            // 
            this.masteryComboBox.FormattingEnabled = true;
            this.masteryComboBox.Items.AddRange(new object[] {
            "Not learned",
            "Learned",
            "Master",
            "Head Master"});
            this.masteryComboBox.Location = new System.Drawing.Point(264, 383);
            this.masteryComboBox.Name = "masteryComboBox";
            this.masteryComboBox.Size = new System.Drawing.Size(121, 21);
            this.masteryComboBox.TabIndex = 2;
            this.masteryComboBox.SelectedIndexChanged += new System.EventHandler(this.masteryComboBox_SelectedIndexChanged);
            // 
            // abilityDescriptionBox
            // 
            this.abilityDescriptionBox.Location = new System.Drawing.Point(6, 19);
            this.abilityDescriptionBox.Name = "abilityDescriptionBox";
            this.abilityDescriptionBox.ReadOnly = true;
            this.abilityDescriptionBox.Size = new System.Drawing.Size(388, 331);
            this.abilityDescriptionBox.TabIndex = 1;
            this.abilityDescriptionBox.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.googleDriveButton);
            this.groupBox7.Controls.Add(this.tableLayoutPanel6);
            this.groupBox7.Location = new System.Drawing.Point(3, 435);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(394, 195);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // googleDriveButton
            // 
            this.googleDriveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.googleDriveButton.Location = new System.Drawing.Point(9, 135);
            this.googleDriveButton.Name = "googleDriveButton";
            this.googleDriveButton.Size = new System.Drawing.Size(376, 54);
            this.googleDriveButton.TabIndex = 1;
            this.googleDriveButton.Text = "Send Sheet to Google Drive";
            this.googleDriveButton.UseVisualStyleBackColor = true;
            this.googleDriveButton.Click += new System.EventHandler(this.googleDriveButton_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.companionButton, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.calculateButton, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.characterDetailsButton, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.clearSheetButton, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 12);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(382, 117);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // companionButton
            // 
            this.companionButton.Location = new System.Drawing.Point(3, 3);
            this.companionButton.Name = "companionButton";
            this.companionButton.Size = new System.Drawing.Size(185, 52);
            this.companionButton.TabIndex = 0;
            this.companionButton.Text = "Setup Companion";
            this.companionButton.UseVisualStyleBackColor = true;
            this.companionButton.Click += new System.EventHandler(this.companionButton_Click);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(194, 3);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(185, 52);
            this.calculateButton.TabIndex = 1;
            this.calculateButton.Text = "Calculate Sheet";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // characterDetailsButton
            // 
            this.characterDetailsButton.Location = new System.Drawing.Point(3, 61);
            this.characterDetailsButton.Name = "characterDetailsButton";
            this.characterDetailsButton.Size = new System.Drawing.Size(185, 53);
            this.characterDetailsButton.TabIndex = 2;
            this.characterDetailsButton.Text = "Character Details";
            this.characterDetailsButton.UseVisualStyleBackColor = true;
            this.characterDetailsButton.Click += new System.EventHandler(this.characterDetailsButton_Click);
            // 
            // clearSheetButton
            // 
            this.clearSheetButton.Location = new System.Drawing.Point(194, 61);
            this.clearSheetButton.Name = "clearSheetButton";
            this.clearSheetButton.Size = new System.Drawing.Size(185, 53);
            this.clearSheetButton.TabIndex = 3;
            this.clearSheetButton.Text = "Clear Sheet";
            this.clearSheetButton.UseVisualStyleBackColor = true;
            this.clearSheetButton.Click += new System.EventHandler(this.clearSheetButton_Click);
            // 
            // characterAbilitiesView
            // 
            this.characterAbilitiesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.characterAbilitiesView.HideSelection = false;
            this.characterAbilitiesView.Location = new System.Drawing.Point(825, 3);
            this.characterAbilitiesView.Name = "characterAbilitiesView";
            this.characterAbilitiesView.Size = new System.Drawing.Size(406, 636);
            this.characterAbilitiesView.TabIndex = 2;
            this.characterAbilitiesView.UseCompatibleStateImageBehavior = false;
            this.characterAbilitiesView.View = System.Windows.Forms.View.Details;
            this.characterAbilitiesView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.characterAbilitiesView_ColumnClick);
            this.characterAbilitiesView.Click += new System.EventHandler(this.characterAbilitiesView_Click);
            this.characterAbilitiesView.DoubleClick += new System.EventHandler(this.characterAbilitiesView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 159;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rank";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alignment";
            this.columnHeader3.Width = 67;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "School";
            this.columnHeader4.Width = 97;
            // 
            // openCharacterDialog
            // 
            this.openCharacterDialog.FileName = "openFileDialog1";
            // 
            // saveExcel
            // 
            this.saveExcel.DefaultExt = "xlsx";
            this.saveExcel.FileOk += new System.ComponentModel.CancelEventHandler(this.saveExcel_FileOk);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hardcorePointsButton);
            this.panel1.Location = new System.Drawing.Point(6, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 61);
            this.panel1.TabIndex = 1;
            // 
            // hardcorePointsButton
            // 
            this.hardcorePointsButton.Location = new System.Drawing.Point(4, 0);
            this.hardcorePointsButton.Name = "hardcorePointsButton";
            this.hardcorePointsButton.Size = new System.Drawing.Size(226, 58);
            this.hardcorePointsButton.TabIndex = 0;
            this.hardcorePointsButton.Text = "Hardcore Points";
            this.hardcorePointsButton.UseVisualStyleBackColor = true;
            this.hardcorePointsButton.Click += new System.EventHandler(this.hardcorePointsButton_Click);
            // 
            // CharacterMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1539, 672);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CharacterMaker";
            this.Text = "CharacterMaker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterMaker_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label rankLabel;
        private System.Windows.Forms.Label alignmentLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListView libraryView;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader rankColumn;
        private System.Windows.Forms.ColumnHeader alignmentColumn;
        private System.Windows.Forms.ColumnHeader schoolColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox abilityDescriptionBox;
        private System.Windows.Forms.ListView characterAbilitiesView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.OpenFileDialog openCharacterDialog;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button companionButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.SaveFileDialog saveExcel;
        private System.Windows.Forms.Button characterDetailsButton;
        private System.Windows.Forms.Button clearSheetButton;
        private System.Windows.Forms.Button serverSubmissionButton;
        private System.Windows.Forms.Button googleDriveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox masteryComboBox;
        private System.Windows.Forms.Button saveExcelButton;
        private System.Windows.Forms.Button loadExcelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button hardcorePointsButton;
    }
}