using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using SSI.Server.ServiceModel.ClientModels;
using SSI.UI.Core;
using System;

namespace SSI.UI.Forms
{
    public partial class AddClient : DevExpress.XtraEditors.XtraForm
    {
        private Client currentClient;
        private Client DataSource
        {
            get => new Client()
            {
                FirstName = textEdit1.Text,
                SecondName = textEdit2.Text,
                LastName = textEdit4.Text,
                PersonType = textEdit3.Text,
                Phone = textEdit7.Text,
                RegDate = dateEdit1.DateTime,
                ReferenceCompany = textEdit5.Text,
                Identif = textEdit6.Text
            };
            set
            {
                currentClient = value;
                textEdit1.Text = value.FirstName;
                textEdit2.Text = value.SecondName;
                textEdit4.Text = value.LastName;
                textEdit3.Text = value.PersonType;
                textEdit7.Text = value.Phone;
                dateEdit1.DateTime = value.RegDate;
                textEdit5.Text = value.ReferenceCompany;
                textEdit6.Text = value.Identif;
            }
        }


        public AddClient()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now;
            
            textEdit1.CausesValidation = false;
            textEdit2.CausesValidation = false;
            textEdit4.CausesValidation = false;
            textEdit7.CausesValidation = false;
            textEdit6.CausesValidation = false;
        }

        public AddClient(Client toUpdate) : this()
        {
            DataSource = toUpdate;
            this.Text = "Изменить клиента";
            simpleButton1.Text = "Изменить";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textEdit1.CausesValidation = true;
            textEdit2.CausesValidation = true;
            textEdit4.CausesValidation = true;
            textEdit7.CausesValidation = true;
            textEdit6.CausesValidation = true;

            if (ValidateChildren())
            {
                if(simpleButton1.Text == "Добавить")
                {
                    Gateway.Call(new CreateClient()
                    {
                        Client = DataSource
                    });
                }
                else
                {
                    var client = DataSource;

                    client.Id = currentClient.Id;

                    Gateway.Call(new UpdateClient()
                    {
                        Client = client
                    });
                }
                

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Некорректно заполнены поля формы");
                textEdit1.CausesValidation = false;
                textEdit2.CausesValidation = false;
                textEdit4.CausesValidation = false;
                textEdit7.CausesValidation = false;
                textEdit6.CausesValidation = false;
            }
        }

        private void textEdit1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var field = sender as BaseEdit;
            if (string.IsNullOrEmpty(field.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textEdit1, "Поле не может быть пустым");
            }
        }

        private void textEdit1_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as BaseEdit, "");
        }
    }
}