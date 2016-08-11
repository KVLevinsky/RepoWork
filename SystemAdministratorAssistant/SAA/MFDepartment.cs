using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAA {
    public class MFDepartment {
        public int Room { get; private set; }
        public string PostalCode { get; private set; }
        public string StreetAddress { get; private set; }
        public string LDAPPath { get; private set; }
        public MFDepartment() {

        }
    }
}
