namespace Synovian_Character_Maker.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.characterView = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.alignHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rankColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modifiedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.loadSheetFromGoogle = new System.Windows.Forms.Button();
            this.sheetFolButton = new System.Windows.Forms.Button();
            this.loadCharButton = new System.Windows.Forms.Button();
            this.newCharButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.audioOnLoopCheckBox = new System.Windows.Forms.CheckBox();
            this.custonSongButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.songNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericVolume = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.keepMenuOpenBox = new System.Windows.Forms.CheckBox();
            this.zipsOverTxtBox = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.FAQBox = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tutorialTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.basicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makingYourCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savingYourCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.licenseBox = new System.Windows.Forms.RichTextBox();
            this.openSongFile = new System.Windows.Forms.OpenFileDialog();
            this.openCharacter = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVolume)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1168, 583);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1160, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Characters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 545F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1148, 545);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.previewBox);
            this.groupBox3.Location = new System.Drawing.Point(767, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 539);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // previewBox
            // 
            this.previewBox.InitialImage = null;
            this.previewBox.Location = new System.Drawing.Point(6, 19);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(364, 514);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.characterView);
            this.groupBox2.Location = new System.Drawing.Point(385, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 539);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recent Characters";
            // 
            // characterView
            // 
            this.characterView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.alignHeader,
            this.rankColumn,
            this.modifiedColumn});
            this.characterView.HideSelection = false;
            this.characterView.Location = new System.Drawing.Point(6, 19);
            this.characterView.Name = "characterView";
            this.characterView.Size = new System.Drawing.Size(364, 514);
            this.characterView.TabIndex = 0;
            this.characterView.UseCompatibleStateImageBehavior = false;
            this.characterView.View = System.Windows.Forms.View.Details;
            this.characterView.Click += new System.EventHandler(this.characterView_Click);
            this.characterView.DoubleClick += new System.EventHandler(this.characterView_DoubleClick);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 92;
            // 
            // alignHeader
            // 
            this.alignHeader.Text = "Alignment";
            this.alignHeader.Width = 70;
            // 
            // rankColumn
            // 
            this.rankColumn.Text = "Rank";
            this.rankColumn.Width = 83;
            // 
            // modifiedColumn
            // 
            this.modifiedColumn.Text = "Last Modified";
            this.modifiedColumn.Width = 89;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.loadSheetFromGoogle, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.sheetFolButton, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.loadCharButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.newCharButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.exitButton, 0, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(364, 514);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // loadSheetFromGoogle
            // 
            this.loadSheetFromGoogle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadSheetFromGoogle.Location = new System.Drawing.Point(3, 309);
            this.loadSheetFromGoogle.Name = "loadSheetFromGoogle";
            this.loadSheetFromGoogle.Size = new System.Drawing.Size(358, 96);
            this.loadSheetFromGoogle.TabIndex = 4;
            this.loadSheetFromGoogle.Text = "Load Sheet From Google";
            this.loadSheetFromGoogle.UseVisualStyleBackColor = true;
            this.loadSheetFromGoogle.Click += new System.EventHandler(this.loadSheetFromGoogle_Click);
            // 
            // sheetFolButton
            // 
            this.sheetFolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sheetFolButton.Location = new System.Drawing.Point(3, 207);
            this.sheetFolButton.Name = "sheetFolButton";
            this.sheetFolButton.Size = new System.Drawing.Size(358, 96);
            this.sheetFolButton.TabIndex = 2;
            this.sheetFolButton.Text = "Sheets Folder";
            this.sheetFolButton.UseVisualStyleBackColor = true;
            this.sheetFolButton.Click += new System.EventHandler(this.sheetFolButton_Click);
            // 
            // loadCharButton
            // 
            this.loadCharButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadCharButton.Location = new System.Drawing.Point(3, 105);
            this.loadCharButton.Name = "loadCharButton";
            this.loadCharButton.Size = new System.Drawing.Size(358, 96);
            this.loadCharButton.TabIndex = 1;
            this.loadCharButton.Text = "Load Character";
            this.loadCharButton.UseVisualStyleBackColor = true;
            this.loadCharButton.Click += new System.EventHandler(this.loadCharButton_Click);
            // 
            // newCharButton
            // 
            this.newCharButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCharButton.Location = new System.Drawing.Point(3, 3);
            this.newCharButton.Name = "newCharButton";
            this.newCharButton.Size = new System.Drawing.Size(358, 96);
            this.newCharButton.TabIndex = 0;
            this.newCharButton.Text = "New Character";
            this.newCharButton.UseVisualStyleBackColor = true;
            this.newCharButton.Click += new System.EventHandler(this.newCharButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(3, 411);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(358, 100);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1160, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1148, 545);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel1);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(568, 266);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Audio";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.audioOnLoopCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.custonSongButton);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(556, 241);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // audioOnLoopCheckBox
            // 
            this.audioOnLoopCheckBox.AutoSize = true;
            this.audioOnLoopCheckBox.Location = new System.Drawing.Point(3, 3);
            this.audioOnLoopCheckBox.Name = "audioOnLoopCheckBox";
            this.audioOnLoopCheckBox.Size = new System.Drawing.Size(78, 17);
            this.audioOnLoopCheckBox.TabIndex = 0;
            this.audioOnLoopCheckBox.Text = "Loop Song";
            this.audioOnLoopCheckBox.UseVisualStyleBackColor = true;
            this.audioOnLoopCheckBox.CheckedChanged += new System.EventHandler(this.audioOnLoopCheckBox_CheckedChanged);
            // 
            // custonSongButton
            // 
            this.custonSongButton.Location = new System.Drawing.Point(87, 3);
            this.custonSongButton.Name = "custonSongButton";
            this.custonSongButton.Size = new System.Drawing.Size(89, 23);
            this.custonSongButton.TabIndex = 1;
            this.custonSongButton.Text = "Custom Song";
            this.custonSongButton.UseVisualStyleBackColor = true;
            this.custonSongButton.Click += new System.EventHandler(this.custonSongButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel4);
            this.groupBox5.Location = new System.Drawing.Point(3, 32);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(540, 88);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Current Song";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.songNameLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.03704F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.96296F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 54);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // songNameLabel
            // 
            this.songNameLabel.AutoSize = true;
            this.songNameLabel.Location = new System.Drawing.Point(3, 0);
            this.songNameLabel.Name = "songNameLabel";
            this.songNameLabel.Size = new System.Drawing.Size(35, 13);
            this.songNameLabel.TabIndex = 0;
            this.songNameLabel.Text = "Name";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.98969F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.01031F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.numericVolume, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(194, 28);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volumne :";
            // 
            // numericVolume
            // 
            this.numericVolume.DecimalPlaces = 1;
            this.numericVolume.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericVolume.Location = new System.Drawing.Point(66, 3);
            this.numericVolume.Name = "numericVolume";
            this.numericVolume.Size = new System.Drawing.Size(120, 20);
            this.numericVolume.TabIndex = 1;
            this.numericVolume.ValueChanged += new System.EventHandler(this.numericVolume_ValueChanged);
            this.numericVolume.Click += new System.EventHandler(this.numericVolume_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.flowLayoutPanel2);
            this.groupBox6.Location = new System.Drawing.Point(577, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(563, 260);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Misc";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.keepMenuOpenBox);
            this.flowLayoutPanel2.Controls.Add(this.zipsOverTxtBox);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(551, 235);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // keepMenuOpenBox
            // 
            this.keepMenuOpenBox.AutoSize = true;
            this.keepMenuOpenBox.Location = new System.Drawing.Point(3, 3);
            this.keepMenuOpenBox.Name = "keepMenuOpenBox";
            this.keepMenuOpenBox.Size = new System.Drawing.Size(183, 17);
            this.keepMenuOpenBox.TabIndex = 0;
            this.keepMenuOpenBox.Text = "Keep Menu Open In Background";
            this.keepMenuOpenBox.UseVisualStyleBackColor = true;
            this.keepMenuOpenBox.CheckedChanged += new System.EventHandler(this.keepMenuOpenBox_CheckedChanged);
            // 
            // zipsOverTxtBox
            // 
            this.zipsOverTxtBox.AutoSize = true;
            this.zipsOverTxtBox.Location = new System.Drawing.Point(3, 26);
            this.zipsOverTxtBox.Name = "zipsOverTxtBox";
            this.zipsOverTxtBox.Size = new System.Drawing.Size(180, 17);
            this.zipsOverTxtBox.TabIndex = 1;
            this.zipsOverTxtBox.Text = "Prioritize Opening Zips Over Txts";
            this.zipsOverTxtBox.UseVisualStyleBackColor = true;
            this.zipsOverTxtBox.CheckedChanged += new System.EventHandler(this.zipsOverTxtBox_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.FAQBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1160, 557);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "FAQ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FAQBox
            // 
            this.FAQBox.Location = new System.Drawing.Point(3, 3);
            this.FAQBox.Name = "FAQBox";
            this.FAQBox.ReadOnly = true;
            this.FAQBox.Size = new System.Drawing.Size(1154, 551);
            this.FAQBox.TabIndex = 0;
            this.FAQBox.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tutorialTextBox);
            this.tabPage4.Controls.Add(this.menuStrip1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1160, 557);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tutorial";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tutorialTextBox
            // 
            this.tutorialTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tutorialTextBox.Location = new System.Drawing.Point(0, 24);
            this.tutorialTextBox.Name = "tutorialTextBox";
            this.tutorialTextBox.ReadOnly = true;
            this.tutorialTextBox.Size = new System.Drawing.Size(1160, 533);
            this.tutorialTextBox.TabIndex = 1;
            this.tutorialTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basicsToolStripMenuItem,
            this.companionsToolStripMenuItem,
            this.miscToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1160, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // basicsToolStripMenuItem
            // 
            this.basicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makingYourCharacterToolStripMenuItem,
            this.savingYourCharacterToolStripMenuItem,
            this.calculatorToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.basicsToolStripMenuItem.Name = "basicsToolStripMenuItem";
            this.basicsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.basicsToolStripMenuItem.Text = "Basics";
            // 
            // makingYourCharacterToolStripMenuItem
            // 
            this.makingYourCharacterToolStripMenuItem.Name = "makingYourCharacterToolStripMenuItem";
            this.makingYourCharacterToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.makingYourCharacterToolStripMenuItem.Text = "Making Your Character";
            this.makingYourCharacterToolStripMenuItem.Click += new System.EventHandler(this.makingYourCharacterToolStripMenuItem_Click);
            // 
            // savingYourCharacterToolStripMenuItem
            // 
            this.savingYourCharacterToolStripMenuItem.Name = "savingYourCharacterToolStripMenuItem";
            this.savingYourCharacterToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.savingYourCharacterToolStripMenuItem.Text = "Saving Your Character";
            this.savingYourCharacterToolStripMenuItem.Click += new System.EventHandler(this.savingYourCharacterToolStripMenuItem_Click);
            // 
            // calculatorToolStripMenuItem
            // 
            this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
            this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.calculatorToolStripMenuItem.Text = "Calculator";
            this.calculatorToolStripMenuItem.Click += new System.EventHandler(this.calculatorToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // companionsToolStripMenuItem
            // 
            this.companionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingUpToolStripMenuItem,
            this.abilitiesToolStripMenuItem});
            this.companionsToolStripMenuItem.Name = "companionsToolStripMenuItem";
            this.companionsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.companionsToolStripMenuItem.Text = "Companions";
            // 
            // settingUpToolStripMenuItem
            // 
            this.settingUpToolStripMenuItem.Name = "settingUpToolStripMenuItem";
            this.settingUpToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.settingUpToolStripMenuItem.Text = "Setting Up";
            this.settingUpToolStripMenuItem.Click += new System.EventHandler(this.settingUpToolStripMenuItem_Click);
            // 
            // abilitiesToolStripMenuItem
            // 
            this.abilitiesToolStripMenuItem.Name = "abilitiesToolStripMenuItem";
            this.abilitiesToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.abilitiesToolStripMenuItem.Text = "Abilities";
            this.abilitiesToolStripMenuItem.Click += new System.EventHandler(this.abilitiesToolStripMenuItem_Click);
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musicToolStripMenuItem});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.miscToolStripMenuItem.Text = "Misc";
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.musicToolStripMenuItem.Text = "Music";
            this.musicToolStripMenuItem.Click += new System.EventHandler(this.musicToolStripMenuItem_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.licenseBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1160, 557);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "License";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // licenseBox
            // 
            this.licenseBox.Location = new System.Drawing.Point(3, 3);
            this.licenseBox.Name = "licenseBox";
            this.licenseBox.ReadOnly = true;
            this.licenseBox.Size = new System.Drawing.Size(1154, 551);
            this.licenseBox.TabIndex = 0;
            this.licenseBox.Text = "";
            this.licenseBox.ZoomFactor = 5F;
            // 
            // openSongFile
            // 
            this.openSongFile.FileName = "openFileDialog1";
            this.openSongFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openSongFile_FileOk);
            // 
            // openCharacter
            // 
            this.openCharacter.FileOk += new System.ComponentModel.CancelEventHandler(this.openCharacter_FileOk);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 267);
            this.panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 607);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Main Menu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericVolume)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button sheetFolButton;
        private System.Windows.Forms.Button loadCharButton;
        private System.Windows.Forms.Button newCharButton;
        private System.Windows.Forms.ListView characterView;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader alignHeader;
        private System.Windows.Forms.ColumnHeader rankColumn;
        private System.Windows.Forms.ColumnHeader modifiedColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox audioOnLoopCheckBox;
        private System.Windows.Forms.Button custonSongButton;
        private System.Windows.Forms.OpenFileDialog openSongFile;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label songNameLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericVolume;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox keepMenuOpenBox;
        private System.Windows.Forms.CheckBox zipsOverTxtBox;
        private System.Windows.Forms.OpenFileDialog openCharacter;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox FAQBox;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem basicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makingYourCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savingYourCharacterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.RichTextBox tutorialTextBox;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.RichTextBox licenseBox;
        private System.Windows.Forms.Button loadSheetFromGoogle;
        private System.Windows.Forms.Panel panel1;
    }
}

