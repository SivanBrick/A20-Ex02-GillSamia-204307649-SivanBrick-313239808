using System;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Ex02
{
    public partial class LoginForm : Form
    {
        private FBLoggedInUserAdapter m_LoggedInUser = new FBLoggedInUserAdapter();

        public LoginForm()
        {
            this.InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
        }

        public FBLoggedInUserAdapter LoggedInUser
        {
            get { return m_LoggedInUser; }
        }

        private void loginAndInit()
        {
            LoggedInUser.loginAndInit();
            //facade
            //
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.loginAndInit();
            this.Hide();
        }
    }
}
