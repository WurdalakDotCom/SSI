namespace SSI.UI.UserControls
{
    partial class AuthUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.passwordTE = new DevExpress.XtraEditors.TextEdit();
            this.loginTE = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.passwordTE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginTE.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // passwordTE
            // 
            this.passwordTE.Location = new System.Drawing.Point(54, 55);
            this.passwordTE.Name = "passwordTE";
            this.passwordTE.Properties.NullValuePrompt = "Пароль";
            this.passwordTE.Properties.PasswordChar = '*';
            this.passwordTE.Properties.UseSystemPasswordChar = true;
            this.passwordTE.Size = new System.Drawing.Size(189, 20);
            this.passwordTE.TabIndex = 9;
            // 
            // loginTE
            // 
            this.loginTE.Location = new System.Drawing.Point(54, 12);
            this.loginTE.Name = "loginTE";
            this.loginTE.Properties.NullValuePrompt = "Логин";
            this.loginTE.Size = new System.Drawing.Size(189, 20);
            this.loginTE.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Лоигн";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Пароль";
            // 
            // AuthUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.passwordTE);
            this.Controls.Add(this.loginTE);
            this.Name = "AuthUserControl";
            this.Size = new System.Drawing.Size(254, 89);
            ((System.ComponentModel.ISupportInitialize)(this.passwordTE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginTE.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit passwordTE;
        private DevExpress.XtraEditors.TextEdit loginTE;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
