using DevExpress.XtraEditors;
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
            userLocalBindingSource.CurrentChanged += UserLocalBindingSource_CurrentChanged;
            RefreshData();
        }

        private void RefreshData()
        {
            userLocalBindingSource.DataSource = Gateway.Call(new GetAllUser()).Result;
            UserLocalBindingSource_CurrentChanged(null, null);
        }

        private void UserLocalBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            var roles = GetCurrentuser()?.Roles;
            toggleSwitch1.EditValue = roles.Contains("Admin");
            toggleSwitch2.EditValue = roles.Contains("Opr");
            toggleSwitch3.EditValue = roles.Contains("Dis");
        }

        private UserLocal GetCurrentuser()
        {
            return userLocalBindingSource.Current as UserLocal;
        }

        private void toggleSwitch1_EditValueChanged(object sender, EventArgs e)
        {
            var edit = sender as ToggleSwitch;
            var user = GetCurrentuser();

            if (edit.IsOn)
            {
                if (user.Roles.Contains("Admin"))
                    return;
                else
                    user.Roles.Add("Admin");
            }
            else
            {
                if (!user.Roles.Contains("Admin"))
                    return;
                else
                    user.Roles.Remove("Admin");
            }

            Gateway.Call(new UpdateUser() { User = user });
            RefreshData();
        }

        private void toggleSwitch2_EditValueChanged(object sender, EventArgs e)
        {
            var edit = sender as ToggleSwitch;
            var user = GetCurrentuser();

            if (edit.IsOn)
            {
                if (user.Roles.Contains("Opr"))
                    return;
                else
                    user.Roles.Add("Opr");
            }
            else
            {
                if (!user.Roles.Contains("Opr"))
                    return;
                else
                    user.Roles.Remove("Opr");
            }

            Gateway.Call(new UpdateUser() { User = user });
            RefreshData();
        }

        private void toggleSwitch3_EditValueChanged(object sender, EventArgs e)
        {
            var edit = sender as ToggleSwitch;
            var user = GetCurrentuser();

            if (edit.IsOn)
            {
                if (user.Roles.Contains("Dis"))
                    return;
                else
                    user.Roles.Add("Dis");
            }
            else
            {
                if (!user.Roles.Contains("Dis"))
                    return;
                else
                    user.Roles.Remove("Dis");
            }

            Gateway.Call(new UpdateUser() { User = user });
            RefreshData();
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var form = new AddUser())
            {
                form.ShowDialog();
                RefreshData();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var user = GetCurrentuser();
            Gateway.Call(new DeleteUser() { Id = user.Id });
            RefreshData();
        }
    }
}