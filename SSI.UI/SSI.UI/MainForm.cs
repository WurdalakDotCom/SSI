using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraVerticalGrid;
using SSI.Server.ServiceModel.ClientModels;
using SSI.Server.ServiceModel.DeliveryModels;
using SSI.Server.ServiceModel.ProductModels;
using SSI.UI.Core;
using SSI.UI.Forms;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Windows.Forms;

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
            OnPrivate();

            clientBindingSource.DataSource = Gateway.Call(new GetAllClient()).Result;
            clientBindingSource1.DataSource = Gateway.Call(new GetAllClient()).Result;
            productBindingSource.DataSource = Gateway.Call(new GetAllProduct()).Result;
            deliveryBindingSource.DataSource = Gateway.Call(new GetAllDelivery()).Result;

            clientBindingSource1.CurrentChanged += ClientBindingSource1_CurrentChanged;
        }

        private void ClientBindingSource1_CurrentChanged(object sender, System.EventArgs e)
        {
            if (clientBindingSource1.Current is Client buffer)
                accountingBindingSource.DataSource = Gateway.Call(new GetAccountingByOwnerId() { Id = buffer.Id }).Result;
            else
                accountingBindingSource.Clear();
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
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(clientBindingSource.Current is Client currentClient) || tabPane1.SelectedPageIndex != 0)
            {
                XtraMessageBox.Show("Сначала выберете клиента", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            using (var form = new AddClient(currentClient))
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(clientBindingSource.Current is Client currentClient) || tabPane1.SelectedPageIndex != 0)
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
            if (!(productBindingSource.Current is Product currentProduct) || tabPane1.SelectedPageIndex == 1)
            {
                XtraMessageBox.Show("Сначала выберете товар", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            Gateway.Call(new DeleteProduct() { Product = currentProduct });
            RefreshData();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!(productBindingSource.Current is Product currentProduct) || tabPane1.SelectedPageIndex == 1)
            {
                XtraMessageBox.Show("Сначала выберете товар", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            using (var form = new ProductManagement(currentProduct))
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
            if (!(deliveryBindingSource.Current is Delivery currentDelivery) || tabPane1.SelectedPageIndex != 2)
            {
                XtraMessageBox.Show("Сначала выберете поставку", "Предупреждение", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            Gateway.Call(new DeleteDelivery() { Delivery = currentDelivery });
            RefreshData();
        }

        private void OnPrivate()
        {
            var roles = MemoryCache.Default["roles"] as List<string>;

            if (!roles.Contains("Admin"))
            {
                ribbonPageGroup1.Enabled = false;

                if (roles.Contains("Dis") && roles.Contains("Opr"))
                {
                    return;
                }

                if (roles.Contains("Dis"))
                {
                    ribbonPageGroup2.Enabled = false;
                    ribbonPageGroup3.Enabled = false;
                    tabNavigationPage1.PageVisible = false;
                    tabNavigationPage2.PageVisible = false;
                }
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Restart();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabPane1.SelectedPageIndex == 2)
            {
                if (deliveryBindingSource.Current is Delivery buffer)
                {
                    var report = new Report();
                    report.objectDataSource1.DataSource = buffer;
                    report.ShowPreview();
                }
            }
            else
            {
                XtraMessageBox.Show("Выберете поставку для вывода в отчёт.");
            }
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (tabPane1.SelectedPageIndex == 3)
            {
                if (clientBindingSource1.Current is Client buffer)
                {
                    buffer.Accountings = Gateway.Call(new GetAccountingByOwnerId() { Id = buffer.Id }).Result;
                    var report = new Report1();
                    report.objectDataSource1.DataSource = buffer;
                    report.ShowPreview();
                }
            }
            else
            {
                XtraMessageBox.Show("Выберете клиента для вывода в отчёт.");
            }
        }
    }
}