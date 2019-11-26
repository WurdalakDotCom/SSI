using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using SSI.Server.ServiceModel.ClientModels;
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

        private void clientView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InDataRow)
            {
                clientPopup.ShowPopup(MousePosition);
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshData();
        }

        private void clientView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }

        private void clientView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }
    }
}