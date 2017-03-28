using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2 { //main form
    public partial class memberMaintenanceForm : Form {
        MembershipList x = new MembershipList(); //create list of members
        
        public memberMaintenanceForm() {
            InitializeComponent();
            x.write(); //grab list of members from text file
            x.Changed += new MembershipList.ChangeHandler(this.addMemberForm_refreshList);
            //x.Changed += new EventHandler(addMemberForm_refreshList); 
            Load += new EventHandler(addMemberForm_refreshList); //calls event to populate listbox
        }
        
        //add button that creates a new member form
        private void addButton_Click(object sender, EventArgs e) {
            //form 2
            addMemberForm newMemberForm = new addMemberForm();
            //subscribe form for callback from delegate
            //when form 2 calls delegate the information is tranferred to OnSaved
            newMemberForm.AddItemCallback = new addMemberForm.AddItemDelegate(this.OnSaved);
            //event for refreshing window is called
            newMemberForm.refreshWindow += new EventHandler(addMemberForm_refreshList);
            newMemberForm.Show(); //show the dialog box
        }

        //event that refreshes listbox
        public void addMemberForm_refreshList(Object sender, EventArgs e) {
            listBox1.Items.Clear(); //clears the list
            foreach (Member m in MembershipData.GetMemberships()) { //fills the list with members
                listBox1.Items.Add(m.FirstName + " " + m.LastName + ", " + m.Email);
            }
        }

        //delegate callback, it subscribes and this is the information that was passed from the form 2 object
        public void OnSaved(string fn, string ln, string e) {
            Member m = new Member(); //create a new member with form2 properties
            m.FirstName = fn;
            m.LastName = ln;
            m.Email = e;
            x += m; //overload to add to the list
            x.save(); //save it to the text file
        }

        //deletes item from listBox and memberlist
        private void deleteButton_Click(object sender, EventArgs e) {
            int index = listBox1.SelectedIndex; //index from selected item
            Member m = x[index]; //indexor to find that member
            listBox1.Items.Remove(listBox1.SelectedItem); //deletes from listbox
            x-=m; //overload operator deletes from membership list
        }

        //closes form and saves
        private void exitButton_Click(object sender, EventArgs e) {
            x.save();
            this.Close();
        }

        //unused
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {}
    }
}
