using ServiceStack;
using SSI.UI.Type;
using SSI.UI.UserControls;
using System;
using System.Runtime.Caching;
using System.Windows.Forms;

namespace SSI.UI.Core
{
    public class Authorization
    {
        public void UserAuthorizationForm()
        {
            var authorizedUser = GetAuthorizedUser();
            if (authorizedUser == null)
            {
                Environment.Exit(1);
            }

            MemoryCache.Default["roles"] = authorizedUser.Roles;
        }

        public bool Authorize(UserLocal userAuth)
        {
            try
            {
                Gateway.Call(new Authenticate() { UserName = userAuth.UserName, Password = userAuth.Password });
                return true;
            }
            catch (WebServiceException ex)
            {
                MessageBox.Show(ex.ErrorMessage);
                return false;
            }
        }

        public UserLocal GetAuthorizedUser()
        {
            using (var control = new AuthUserControl())
            {
                var dialogResult = DevExpress.XtraEditors.XtraDialog.Show(control, "Авторизация", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    var userAuth = control.DataSource;
                    var authorizeStatus = Authorize(userAuth);
                    
                    if (authorizeStatus)
                    {
                        //userAuth.Roles = SharedGateway.SharedGateway
                        //    .Call(new GetRolesForUser() { UserRefId = userAuth.RefIdStr }).Roles.ToList();
                    }

                    return authorizeStatus == false ? null : userAuth;
                }
                if (dialogResult == DialogResult.Cancel)
                {
                    MessageBox.Show("Отмена");
                    return null;
                }
            }
            return null;
        }
    }
}
