using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//helpful site http://www.c-sharpcorner.com/article/using-delegates-to-communication-between-windows-forms/
namespace Lab2 { //adding member form
    public partial class addMemberForm : Form {
        //main delegate that others subscribe too that sends information
        public delegate void AddItemDelegate(string fn, string ln, string e);
        public event EventHandler refreshWindow; //event for refreshing when saved
        public AddItemDelegate AddItemCallback; //delegate
        public string firstName, lastName, email;

        public addMemberForm() {
            InitializeComponent(); 
        }
       
        //when saved, after validation, it sends information to main form and calls event to update
        private void saveButton_Click(object sender, EventArgs e) {
            //validation for no empty textboxes, less than 25 char, and proper email
            if (Validator.IsPresent(firstNameTextBox, lastNameTextBox, emailTextBox) && Validator.IsValidEmail(emailTextBox) 
                && Validator.IsLessThan(firstNameTextBox, lastNameTextBox, emailTextBox, 25) ) {
                firstName = firstNameTextBox.Text; //grab value from textbox
                lastName = lastNameTextBox.Text;
                email = emailTextBox.Text;
                AddItemCallback(firstName, lastName, email); //send to subscribers
                if (refreshWindow != null) { //call event to refresh window
                    refreshWindow(this, new EventArgs());
                }
                this.Close();
            }
        }

        //closes form
        private void cancelButton_Click(object sender, EventArgs e) {this.Close();}

        //unused
        private void label1_Click(object sender, EventArgs e) {}
        private void firstNameTextBox_TextChanged(object sender, EventArgs e) {}

        private void addMemberForm_Load(object sender, EventArgs e) {

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e) {}
        private void emailTextBox_TextChanged(object sender, EventArgs e) {}
        
    }
}
