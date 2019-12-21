using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Ex02
{
    internal class FBLoggedInUserAdapter : FacebookService, ILoggedInUser
    {
    }
}
