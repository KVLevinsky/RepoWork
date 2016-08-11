using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAA {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            LDAPProcessor lp = LDAPProcessor.GetInstance();
            //int c = lp.Users().Count();
            foreach (UserPrincipal user in lp.Users()) {
                if (user.Certificates.Count > 0) {
                    DateTime expDate = user.Certificates[0].NotAfter;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
