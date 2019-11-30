using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSI.Server.ServiceModel.ClientModels;
using SSI.Server.ServiceModel.DeliveryModels;
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
            RefreshData();
        }

        private void RefreshData()
        {
            clientBindingSource.DataSource = Gateway.Call(new GetAllClient()).Result;
            productBindingSource.DataSource = Gateway.Call(new GetAllProduct()).Result;
            deliveryBindingSource.DataSource = Gateway.Call(new GetAllDelivery()).Result;
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
                RefreshData();
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
            RefreshData();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new AddClient(clientBindingSource.Current as Client))
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new ProductManagement())
            {
                form.ShowDialog();
                RefreshData();
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
            RefreshData();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new ProductManagement(productBindingSource.Current as Product))
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var form = new DeliveryManagement())
            {
                form.ShowDialog();
            }
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            var currentDelivery = deliveryBindingSource.Current as Delivery;

            if (currentDelivery == null)
            {
                XtraMessageBox.Show("Сначала выберете поставку", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            Gateway.Call(new DeleteDelivery() { Delivery = currentDelivery });
            RefreshData();
        }
    }
}