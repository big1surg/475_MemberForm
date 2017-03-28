using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2 {
    //list of memebrs
    class MembershipList {
        private List<Member> memberList; //list of members
        public delegate void ChangeHandler(Object source, EventArgs e); //delegate that calls to form
        public ChangeHandler Changed; //event for change
        MembershipData x = new MembershipData();

        //event 
        protected virtual void OnChanged() {
            EventArgs e = new EventArgs();
            if (Changed != null) {
                //do something. 
                save();
                Changed(this, e);
            }
        }

        public MembershipList() { //constructor for list
            memberList = new List<Member>();
        }

        //indexer
        public Member this[int index] {
            //get and set accessors
            get {return memberList[index];}
            set {memberList[index] = value;}
        }

        //number of members
        public int memberCount() {
            int count = 0;
            count = memberList.Count;
            return count;
        }

        //Add a specified Membership object to the list
        public void add(Member newMember) {
            memberList.Add(newMember);
            OnChanged();
        }

        //Remove the specified Membership from the list.
        public void remove(Member newMember) {
            memberList.Remove(newMember);
            OnChanged();
        }

        //Fill the list with membership data from the Membership 
        //data from a file using the GetMemberships method of the MembershipData class
        //public void write() => memberList = MembershipData.GetMemberships();
        public void write() { memberList = MembershipData.GetMemberships();}

        //Saves the memberships to a file using the SaveMemberships method of the MembershipData class.
        public void save() { x.SaveMemberships(memberList); }

        //operator overload that adds to list with a +=
        public static MembershipList operator +(MembershipList m, Member x) {
            m.add(x);
            return m;
        }

        //operato overload that adds to list with a -=
        public static MembershipList operator -(MembershipList m, Member x) {
            m.remove(x);
            return m;
        }
    }
}
