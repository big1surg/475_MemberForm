using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2 {
    public static class Validator {
        private static string title = "Entry Error";

        public static string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public static bool IsPresent(TextBox textBox) {
            if (textBox.Text == "") {
                MessageBox.Show(textBox.Tag + " is a required field.", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        //overload for 3 args, checks that there is text
        public static bool IsPresent(TextBox one, TextBox two, TextBox three) {
            if (one.Text == "" || two.Text == "" || three.Text == "") {
                if (one.Text == "") {
                    MessageBox.Show(one.Tag + " is a required field.", Title);
                    one.Focus();
                } else if (two.Text == "") {
                    MessageBox.Show(two.Tag + " is a required field.", Title);
                    two.Focus();
                } else {
                    MessageBox.Show(three.Tag + " is a required field.", Title);
                    three.Focus();
                }
                return false;
            }
            return true;
        }

        public static bool IsDecimal(TextBox textBox) {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number)) {
                return true;
            } else {
                MessageBox.Show(textBox.Tag + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsInt32(TextBox textBox) {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number)) {
                return true;
            } else {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max) {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max) {
                MessageBox.Show(textBox.Tag + " must be between " + min
                + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        //check that each textbox is less than 25 characters
        public static bool IsLessThan(TextBox one, TextBox two, TextBox three, int max) {
            if(one.TextLength > max || two.TextLength>max || three.TextLength>max) {
                if (one.TextLength > max) {
                    MessageBox.Show(one.Tag + " must be less than " + max, Title);
                    one.Focus();
                }else if (two.TextLength > max) {
                    MessageBox.Show(two.Tag + " must be less than " + max, Title);
                    two.Focus();
                }else {
                    MessageBox.Show(three.Tag + " must be less than " + max, Title);
                    three.Focus();
                }
                return false;
                
            }
            return true;
        }

        public static bool IsValidEmail(TextBox textBox) {
            if (textBox.Text.IndexOf("@") == -1 ||
            textBox.Text.IndexOf(".") == -1) {
                MessageBox.Show(textBox.Tag + " must be a valid email address.",
                Title);
                textBox.Focus();
                return false;
            } else {
                return true;
            }
        }
    }
}
