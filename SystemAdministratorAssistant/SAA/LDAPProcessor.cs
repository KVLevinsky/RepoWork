using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace SAA {
    internal class LDAPProcessor {
        static LDAPProcessor _instance = null;
        public static LDAPProcessor GetInstance() {
            if (_instance == null)
                _instance = new LDAPProcessor();
            return _instance;
        }

        public IEnumerable<UserPrincipal> Users() {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain)){
                using (PrincipalSearcher principalSearcher = new PrincipalSearcher(new UserPrincipal(principalContext))) {
                    foreach (UserPrincipal item in principalSearcher.FindAll()) {
                        yield return item;
                    }
                }
            }
        }
        public IEnumerable<ComputerPrincipal> Computers() {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain)) {
                using (PrincipalSearcher principalSearcher = new PrincipalSearcher(new ComputerPrincipal(principalContext))) {
                    foreach (ComputerPrincipal item in principalSearcher.FindAll()) {
                        yield return item;
                    }
                }
            }
        }
    }
}
