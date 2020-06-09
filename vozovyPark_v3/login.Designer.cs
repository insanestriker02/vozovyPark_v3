namespace vozovyPark_v3
{
    partial class login
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jmTxtBx = new System.Windows.Forms.TextBox();
            this.hesTxtBx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.logBtn = new System.Windows.Forms.Button();
            this.prijTxtBx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Přihlášení";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "jméno";
            // 
            // jmTxtBx
            // 
            this.jmTxtBx.Location = new System.Drawing.Point(18, 49);
            this.jmTxtBx.Name = "jmTxtBx";
            this.jmTxtBx.Size = new System.Drawing.Size(155, 20);
            this.jmTxtBx.TabIndex = 2;
            // 
            // hesTxtBx
            // 
            this.hesTxtBx.Location = new System.Drawing.Point(197, 65);
            this.hesTxtBx.Name = "hesTxtBx";
            this.hesTxtBx.Size = new System.Drawing.Size(154, 20);
            this.hesTxtBx.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "heslo";
            // 
            // logBtn
            // 
            this.logBtn.Location = new System.Drawing.Point(276, 104);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(75, 23);
            this.logBtn.TabIndex = 8;
            this.logBtn.Text = "Přihlásit se";
            this.logBtn.UseVisualStyleBackColor = true;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // prijTxtBx
            // 
            this.prijTxtBx.Location = new System.Drawing.Point(18, 91);
            this.prijTxtBx.Name = "prijTxtBx";
            this.prijTxtBx.Size = new System.Drawing.Size(155, 20);
            this.prijTxtBx.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "příjmení";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "label5";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 139);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.prijTxtBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.hesTxtBx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.jmTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "login";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox jmTxtBx;
        private System.Windows.Forms.TextBox hesTxtBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.TextBox prijTxtBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

