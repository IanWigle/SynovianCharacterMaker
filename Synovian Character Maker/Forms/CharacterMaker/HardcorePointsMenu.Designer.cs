namespace Synovian_Character_Maker.Forms.CharacterMaker
{
    partial class HardcorePointsMenu
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
            this.SkillNumericValue = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FeatNumericValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.MasteryNumericValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ExtraDroidNumericValue = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.SpecNumericValue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SkillNumericValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeatNumericValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasteryNumericValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraDroidNumericValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecNumericValue)).BeginInit();
            this.SuspendLayout();
            // 
            // SkillNumericValue
            // 
            this.SkillNumericValue.Location = new System.Drawing.Point(121, 37);
            this.SkillNumericValue.Name = "SkillNumericValue";
            this.SkillNumericValue.Size = new System.Drawing.Size(120, 20);
            this.SkillNumericValue.TabIndex = 0;
            this.SkillNumericValue.Click += new System.EventHandler(this.SkillNumericValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Skillpoints";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Featpoints";
            // 
            // FeatNumericValue
            // 
            this.FeatNumericValue.Location = new System.Drawing.Point(121, 74);
            this.FeatNumericValue.Name = "FeatNumericValue";
            this.FeatNumericValue.Size = new System.Drawing.Size(120, 20);
            this.FeatNumericValue.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mastery Points";
            // 
            // MasteryNumericValue
            // 
            this.MasteryNumericValue.Location = new System.Drawing.Point(121, 114);
            this.MasteryNumericValue.Name = "MasteryNumericValue";
            this.MasteryNumericValue.Size = new System.Drawing.Size(120, 20);
            this.MasteryNumericValue.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Extra Droid";
            // 
            // ExtraDroidNumericValue
            // 
            this.ExtraDroidNumericValue.Location = new System.Drawing.Point(121, 150);
            this.ExtraDroidNumericValue.Name = "ExtraDroidNumericValue";
            this.ExtraDroidNumericValue.Size = new System.Drawing.Size(120, 20);
            this.ExtraDroidNumericValue.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Specialization";
            // 
            // SpecNumericValue
            // 
            this.SpecNumericValue.Location = new System.Drawing.Point(121, 187);
            this.SpecNumericValue.Name = "SpecNumericValue";
            this.SpecNumericValue.Size = new System.Drawing.Size(120, 20);
            this.SpecNumericValue.TabIndex = 8;
            // 
            // HardcorePointsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 219);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SpecNumericValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExtraDroidNumericValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MasteryNumericValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FeatNumericValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SkillNumericValue);
            this.Name = "HardcorePointsMenu";
            this.Text = "Hardcore Points Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HardcorePointsMenu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SkillNumericValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeatNumericValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasteryNumericValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraDroidNumericValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpecNumericValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown SkillNumericValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown FeatNumericValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MasteryNumericValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ExtraDroidNumericValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown SpecNumericValue;
    }
}