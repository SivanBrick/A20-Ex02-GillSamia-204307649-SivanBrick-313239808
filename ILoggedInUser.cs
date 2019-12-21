using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal interface ILoggedInUser
    {
        void loginAndInit();
        string GetProfilePictureURL();
        string GetName();
    }
}
