namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    partial class CharacterDetailsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterDetailsWindow));
            this.characterImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.speciesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bioTextBox = new System.Windows.Forms.RichTextBox();
            this.loadPictureButton = new System.Windows.Forms.Button();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.characterImage)).BeginInit();
            this.SuspendLayout();
            // 
            // characterImage
            // 
            this.characterImage.Location = new System.Drawing.Point(12, 12);
            this.characterImage.Name = "characterImage";
            this.characterImage.Size = new System.Drawing.Size(349, 426);
            this.characterImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.characterImage.TabIndex = 0;
            this.characterImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(392, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Species";
            // 
            // speciesTextBox
            // 
            this.speciesTextBox.Location = new System.Drawing.Point(395, 30);
            this.speciesTextBox.Name = "speciesTextBox";
            this.speciesTextBox.Size = new System.Drawing.Size(100, 20);
            this.speciesTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Biography";
            // 
            // bioTextBox
            // 
            this.bioTextBox.Location = new System.Drawing.Point(398, 80);
            this.bioTextBox.Name = "bioTextBox";
            this.bioTextBox.Size = new System.Drawing.Size(390, 325);
            this.bioTextBox.TabIndex = 4;
            this.bioTextBox.Text = "";
            // 
            // loadPictureButton
            // 
            this.loadPictureButton.Location = new System.Drawing.Point(398, 415);
            this.loadPictureButton.Name = "loadPictureButton";
            this.loadPictureButton.Size = new System.Drawing.Size(75, 23);
            this.loadPictureButton.TabIndex = 5;
            this.loadPictureButton.Text = "Load Picture";
            this.loadPictureButton.UseVisualStyleBackColor = true;
            this.loadPictureButton.Click += new System.EventHandler(this.loadPictureButton_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openImageDialog_FileOk);
            // 
            // CharacterDetailsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadPictureButton);
            this.Controls.Add(this.bioTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.speciesTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.characterImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CharacterDetailsWindow";
            this.Text = "CharacterDetailsWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CharacterDetailsWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.characterImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox characterImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox speciesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox bioTextBox;
        private System.Windows.Forms.Button loadPictureButton;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
    }
}