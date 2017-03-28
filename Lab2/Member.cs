using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2 {
    //creating a single member
    class Member {
        private string firstName, lastName, email;

        public Member() {firstName = lastName = email = "default";}

        //constructor
        public Member(string firstName, string lastName, string email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }

        //property for firstname
        public string FirstName {
            get { return firstName; }
            set {firstName = value;}
        }

        public string LastName { //property for lastname
            get { return lastName; }
            set {lastName = value;}
        }

        public string Email { //property for email
            get { return email; }
            set {email = value;}
        }

        public string GetDisplayText() { //return information
            return firstName + " " + lastName + " " + email;
        }
    }
}
