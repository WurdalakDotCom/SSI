using System;
using System.Collections.Generic;
using SSI.UI.Core;
using SSI.Server.ServiceModel.ProductModels;
using SSI.Server.ServiceModel.ClientModels;
using SSI.Server.ServiceModel.DeliveryModels;
using SSI.UI.UserControls;
using DevExpress.XtraEditors;

namespace SSI.UI.Forms
{
    public partial class DeliveryManagement : DevExpress.XtraEditors.XtraForm
    {
        private Client currentClient = null;
        private List<Party> currentParty = new List<Party>();
        private Delivery currentDelivery = new Delivery();


        public DeliveryManagement()
        {
            InitializeComponent();
            currentDelivery.Parties = currentParty;
        }

        private void DeliveryManagment_Load(object sender, EventArgs e)
        {
            RefrehData();
        }

        private void RefrehData()
        {
            productBindingSource.DataSource = Gateway.Call(new GetAllProduct()).Result;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            foreach (var index in gridView1.GetSelectedRows())
            {
                var product = gridView1.GetRow(index) as Product;

                if (!currentParty.Exists(x => x.ProductId == product.Id))
                {
                    var party = new Party() { Product = product, ProductId = product.Id };
                    partyBindingSource.Add(party);
                    currentParty.Add(party);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var control = new SelectorClient() { Dock = System.Windows.Forms.DockStyle.Fill })
            {
                using (var form = new XtraForm()
                {
                    StartPosition = System.Windows.Forms.FormStartPosition.CenterParent,
                    Text = "Выбор клиента",
                    ShowIcon = false,
                    Size = new System.Drawing.Size(400,600)
                })
                {
                    form.Controls.Add(control);
                    form.ShowDialog();
                    if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        currentClient = control.GetClient;
                        currentDelivery.OwnerId = currentClient.Id;
                        textEdit1.Text = $"{currentClient.FirstName} {currentClient.SecondName} {currentClient.LastName}";
                    }
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
                return;

            currentDelivery.Date = DateTime.Now;
            Gateway.Call(new RegisterDelivery() { Delivery = currentDelivery });
            this.Close();
        }

        private bool ValidateData()
        {
            if (currentClient == null)
            {
                XtraMessageBox.Show("Необходимо выбрать клиента", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            foreach (Party item in partyBindingSource)
            {
                if (item.Count < 1)
                {
                    XtraMessageBox.Show("Колличество товара не может быть меньше одного", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
            }


            if (currentParty.Count < 1)
            {
                XtraMessageBox.Show("Необходимо добавить товар", "Ошибка", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InDataRow)
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var party = partyBindingSource.Current as Party;
            currentParty.Remove(party);
            partyBindingSource.RemoveCurrent();
        }
    }
}