using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSI.Server.ServiceModel.ClientModels;
using SSI.Server.ServiceModel.ProductModels;
using SSI.UI.Core;
using SSI.UI.Forms;

namespace SSI.UI
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            RefreshDataClient();
        }

        private void RefreshDataClient()
        {
            clientBindingSource.DataSource = Gateway.Call(new GetAllClient()).Result;
        }

        private void RefreshDataProduct()
        {
            productBindingSource.DataSource = Gateway.Call(new GetAllProduct()).Result;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new UserManagement())
            {
                form.ShowDialog();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new AddClient())
            {
                form.ShowDialog();
                RefreshDataClient();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var currentClient = clientBindingSource.Current as Client;

            if(currentClient == null)
            {
                XtraMessageBox.Show("Сначала выберете клиента", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            Gateway.Call(new DeleteClient() { Client = currentClient });
            RefreshDataClient();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshDataClient();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new AddClient(clientBindingSource.Current as Client))
            {
                form.ShowDialog();
                RefreshDataClient();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new ProductManagement())
            {
                form.ShowDialog();
                RefreshDataProduct();
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            var currentProduct = productBindingSource.Current as Product;

            if (currentProduct == null)
            {
                XtraMessageBox.Show("Сначала выберете товар", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            Gateway.Call(new DeleteProduct() { Product = currentProduct });
            RefreshDataProduct();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new ProductManagement(productBindingSource.Current as Product))
            {
                form.ShowDialog();
                RefreshDataProduct();
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshDataProduct();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new DeliveryManagement())
            {
                form.ShowDialog();
            }
        }
    }
}