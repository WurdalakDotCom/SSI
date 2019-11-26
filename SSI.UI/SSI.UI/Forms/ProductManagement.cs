using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;
using SSI.Server.ServiceModel.ProductModels;
using SSI.UI.Core;

namespace SSI.UI.Forms
{
    public partial class ProductManagement : DevExpress.XtraEditors.XtraForm
    {
        private Product currentProduct;
        private Product DataSource {
            get=> new Product()
            {
                Article = textEdit2.Text,
                Description = richTextBox1.Text,
                Name = textEdit1.Text
            };
            set
            {
                currentProduct = value;
                textEdit1.Text = value.Name;
                textEdit2.Text = value.Article;
                richTextBox1.Text = value.Description;
            }
        }

        public ProductManagement()
        {
            InitializeComponent();

            textEdit1.CausesValidation = false;
            textEdit2.CausesValidation = false;
            richTextBox1.CausesValidation = false;
        }

        public ProductManagement(Product toUpdate): this()
        {
            DataSource = toUpdate;
            this.Text = "Изменить товар";
            simpleButton1.Text = "Изменить";
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textEdit1.CausesValidation = true;
            textEdit2.CausesValidation = true;
            richTextBox1.CausesValidation = true;

            if (ValidateChildren())
            {
                if (simpleButton1.Text == "Добавить")
                {
                    Gateway.Call(new CreateProduct()
                    {
                        Product = DataSource
                    });
                }
                else
                {
                    var product = DataSource;

                    product.Id = currentProduct.Id;

                    Gateway.Call(new UpdateProduct()
                    {
                        Product = product
                    });
                }

                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Некорректно заполнены поля формы");
                textEdit1.CausesValidation = false;
                textEdit2.CausesValidation = false;
                richTextBox1.CausesValidation = false;
            }
        }

        private void textEdit1_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError(sender as BaseEdit, "");
        }

        private void textEdit1_Validating(object sender, CancelEventArgs e)
        {
            var field = sender as BaseEdit;
            if (string.IsNullOrEmpty(field.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textEdit1, "Поле не может быть пустым");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}