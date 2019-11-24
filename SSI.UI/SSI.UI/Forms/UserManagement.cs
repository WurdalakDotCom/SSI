using SSI.Server.ServiceModel.UserModels;
using SSI.UI.Core;
using System;

namespace SSI.UI.Forms
{
    public partial class UserManagement : DevExpress.XtraEditors.XtraForm
    {
        public UserManagement()
        {
            InitializeComponent();
            userLocalBindingSource.DataSource = Gateway.Call(new GetAllUser()).Result;
            userLocalBindingSource.CurrentChanged += UserLocalBindingSource_CurrentChanged;
        }

        private void UserLocalBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var user = (userLocalBindingSource.Current as UserLocal).Roles;
        }
    }
}