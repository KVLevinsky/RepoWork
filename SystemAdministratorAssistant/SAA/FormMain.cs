using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAA {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }

        LDAPProcessor lp;

        private void FormMain_Load(object sender, EventArgs e) {

            lp = LDAPProcessor.GetInstance();
            this.Text = lp.ADServer;
            foreach (UserPrincipal user in lp.Users()/*.Where(x => x.SamAccountName.Contains("."))*/) {
                ListViewItem lvi = new ListViewItem(new string[] {
                    user.GivenName.Split(' ')[0],
                    user.GivenName.Split(' ')[1],
                    user.Surname,
                    user.SamAccountName,
                    user.EmailAddress,
                    user.DisplayName,
                    user.Enabled.ToString(),
                    //(user.Certificates.Count>0)?((user.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindByTimeValid,DateTime.Now,true).Count>0)?(user.Certificates.Find(System.Security.Cryptography.X509Certificates.X509FindType.FindByTimeValid,DateTime.Now,true)[0].NotAfter.ToString()):("-")):("-"),
                    user.DistinguishedName
                });
                listView1.Items.Add(lvi);
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            //foreach (GroupPrincipal group in lp.Groups()) {
            //    string s = group.Name;
            //}
        }
    }
}
