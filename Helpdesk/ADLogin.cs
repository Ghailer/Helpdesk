using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Windows;

namespace Helpdesk
{
    class ADLogin
    {
        string username;
        string password;

        public ADLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool UserVerification()
        {
            try
            {
                DirectoryEntry login = new DirectoryEntry(@"LDAP://arcom.local", this.username, this.password);
                object nativeObject = login.NativeObject;
                return true;
            }
            catch { }
            return false; 
        }
    }
}
