using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SSI.UI.Core;
using SSI.Server.ServiceModel.ClientModels;

namespace SSI.UI.UserControls
{
    public partial class SelectorClient : DevExpress.XtraEditors.XtraUserControl
    {
        public Client GetClient => clientBindingSource.Current as Client;
        
        public SelectorClient()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }

        private void SelectorClient_Load(object sender, EventArgs e)
        {
            clientBindingSource.DataSource = Gateway.Call(new GetAllClient()).Result;
        }
    }
}
