using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using SSI.Server.ServiceModel.ClientModels;
using SSI.UI.Core;
using System;

namespace SSI.UI.Forms
{
    public partial class AddClient : DevExpress.XtraEditors.XtraForm
    {
        public AddClient()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                XtraMessageBox.Show("Сначала заполните поля данных", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            Gateway.Call(new CreateClient() 
            { 
                Client = new Client()
                {
                    FirstName = textEdit1.Text,
                    SecondName = textEdit2.Text,
                    LastName = textEdit4.Text,
                    PersonType = textEdit3.Text,
                    Phone = textEdit7.Text,
                    RegDate = dateEdit1.DateTime,
                    ReferenceCompany = textEdit5.Text,
                    Indentif = textEdit6.Text
                }
            });

            this.Close();
        }

        private bool ValidateData()
        { 
            if (string.IsNullOrEmpty(textEdit1.Text))
                return false;
            if (string.IsNullOrEmpty(textEdit2.Text))
                return false;
            if (string.IsNullOrEmpty(textEdit3.Text))
                return false;
            if (string.IsNullOrEmpty(textEdit6.Text))
                return false; 
            if (string.IsNullOrEmpty(textEdit7.Text))
                return false;

            return true;
        }
    }
}