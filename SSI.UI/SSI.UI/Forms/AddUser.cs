using DevExpress.XtraEditors;
using SSI.Server.ServiceModel.UserModels;
using SSI.UI.Core;
using System;

namespace SSI.UI.Forms
{
    public partial class AddUser : DevExpress.XtraEditors.XtraForm
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text) || string.IsNullOrEmpty(textEdit2.Text))
            {
                XtraMessageBox.Show("Пароль или логин не могут быть пустыми!", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            var user = new UserLocal() { UserName = textEdit1.Text, Password = textEdit2.Text, CreatedDate = DateTime.Now };
            
            if(!Gateway.Call(new CreateUser() { User = user }))
            {
                XtraMessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Close();
            }
        }
    }
}