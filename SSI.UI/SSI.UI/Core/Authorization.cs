using DevExpress.XtraEditors;
using ServiceStack;
using SSI.Server.ServiceModel.UserModels;
using SSI.UI.UserControls;
using System;
using System.Runtime.Caching;
using System.Windows.Forms;

namespace SSI.UI.Core
{
    public class Authorization
    {
        public bool UserAuthorizationForm()
        {
            var authorizedUser = GetAuthorizedUser();
            
            if (authorizedUser == null)
            {
                return false;
                //Environment.Exit(1);
            }

            MemoryCache.Default["roles"] = authorizedUser.Roles;
            return true;
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
                XtraMessageBox.Show("Неправильный пароль или логин!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    if (Authorize(userAuth))
                    {
                        return Gateway.Call(new GetUserInfo() { UserName = userAuth.UserName });
                    }
                    else
                    {
                        return null;
                    }
                }
                else                   
                {
                    Environment.Exit(1);
                    return null;
                }
            }
        }
    }
}
