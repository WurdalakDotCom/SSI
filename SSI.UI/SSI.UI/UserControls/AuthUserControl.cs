using DevExpress.XtraEditors;
using SSI.UI.Type;
using System;
using System.ComponentModel;

namespace SSI.UI.UserControls
{
    [ComplexBindingProperties("DataSource")]
    public partial class AuthUserControl : XtraUserControl
    {
        public UserLocal DataSource
        {
            get =>
                new UserLocal
                {
                    UserName = loginTE.Text,
                    Password = passwordTE.Text,
                    UserCreateDate = DateTime.Now
                };
            set
            {
                loginTE.Text = value.UserName;
                passwordTE.Text = value.Password;
            }
        }

        public AuthUserControl()
        {
            InitializeComponent();
            SetTestValue();
        }
        
        private void SetTestValue()
        {
            loginTE.Text = @"Admin";
            passwordTE.Text = @"12345678";
        }
    }
}
