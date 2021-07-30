namespace Synovian_Character_Maker.Forms.CharacterMaker.CompanionMaker
{
    partial class Beast_Companion_Maker
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
            this.compNameBox = new System.Windows.Forms.TextBox();
            this.compSpeciesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.companionPicture = new System.Windows.Forms.PictureBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.loadPicture = new System.Windows.Forms.OpenFileDialog();
            this.compHistoryBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.companionPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // compNameBox
            // 
            this.compNameBox.Location = new System.Drawing.Point(12, 30);
            this.compNameBox.Name = "compNameBox";
            this.compNameBox.ReadOnly = true;
            this.compNameBox.Size = new System.Drawing.Size(100, 20);
            this.compNameBox.TabIndex = 0;
            // 
            // compSpeciesBox
            // 
            this.compSpeciesBox.Location = new System.Drawing.Point(12, 91);
            this.compSpeciesBox.Name = "compSpeciesBox";
            this.compSpeciesBox.ReadOnly = true;
            this.compSpeciesBox.Size = new System.Drawing.Size(100, 20);
            this.compSpeciesBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Species";
            // 
            // companionPicture
            // 
            this.companionPicture.Location = new System.Drawing.Point(218, 10);
            this.companionPicture.Name = "companionPicture";
            this.companionPicture.Size = new System.Drawing.Size(393, 427);
            this.companionPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.companionPicture.TabIndex = 4;
            this.companionPicture.TabStop = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 414);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete Character";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(119, 413);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load Picture";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // loadPicture
            // 
            this.loadPicture.FileName = "openFileDialog1";
            this.loadPicture.FileOk += new System.ComponentModel.CancelEventHandler(this.loadPicture_FileOk);
            // 
            // compHistoryBox
            // 
            this.compHistoryBox.Location = new System.Drawing.Point(12, 146);
            this.compHistoryBox.Name = "compHistoryBox";
            this.compHistoryBox.Size = new System.Drawing.Size(182, 261);
            this.compHistoryBox.TabIndex = 7;
            this.compHistoryBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "History";
            // 
            // Beast_Companion_Maker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.compHistoryBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.companionPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compSpeciesBox);
            this.Controls.Add(this.compNameBox);
            this.Name = "Beast_Companion_Maker";
            this.Text = "Beast_Companion_Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Beast_Companion_Maker_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.companionPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox compNameBox;
        private System.Windows.Forms.TextBox compSpeciesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox companionPicture;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog loadPicture;
        private System.Windows.Forms.RichTextBox compHistoryBox;
        private System.Windows.Forms.Label label3;
    }
}