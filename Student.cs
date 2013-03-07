using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace StudentDemo
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string birthDay;
        private string birthMonth;
        private string birthYear;
        private string email;
        private string kimlikNumber;

        //constructor
        public Student()
        {
            //empty constructor for future development :)
        }

        //mutator (set) methods

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public void setBirthDay(string birthDay)
        {
            this.birthDay = birthDay;
        }

        public void setBirthMonth(string birthMonth)
        {
            this.birthMonth = birthMonth;
        }

        public void setBirthYear(string birthYear)
        {
            this.birthYear = birthYear;
        }

        public bool setEmail(string email)
        {
            if (isValidAddress(email))
            {
                this.email = email;
                return true;
            }
            else 
            {
                showErrorMessage("Error", "Invalid email address");
                return false;
            }
        }
        
        /* By making this method return a boolean it can report
         * back to the calling method to indicate whether the
         * Kimlik number has been successfully set or not.
         */
        public bool setKimlikNumber(string kimlikNumber)
        {
            if (isValidKimlik(kimlikNumber)) //see stub method below
            {
                this.kimlikNumber = kimlikNumber;
                return true;
            }
            else 
            {
                showErrorMessage("Error", "Invalid Kimlik Number");
                return false;             
            }
        }

        //accessor (get) methods

        public string getFirstname()
        {
            return firstName;
        }

        public string getLastname()
        {
            return lastName;
        }

        public string getBirthDay()
        {
            return birthDay;
        }

        public string getBirthMonth()
        {
            return birthMonth;
        }

        public string getBirthYear()
        {
            return birthYear;
        }

        public string getEmail()
        {
            return email;
        }



        public string getKimlikNumber()
        {
            return kimlikNumber;
        }
        
        

        private bool isValidKimlik(string kimlikNumber) {

            return true;
        }
        
        /* Validates the email address using a Regex object */
        private bool isValidAddress(string email) 
        {
            /*If the regular expression (regex) included here doesn't meet expectations 
             *there are loads more on the internet. 
             *Try: http://regexlib.com/DisplayPatterns.aspx?AspxAutoDetectCookieSupport=1
             */
            
            Regex regex = new Regex(@"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*(\.[a-zA-Z]{2,6})$");
            Match match = regex.Match(email);
            return match.Success;
        }
        
        /* Method to pop-up an error MessageBox box, 
         * mainly included to save copy/paste in the code of the methods that use data validation.
         */
        private void showErrorMessage(string header, string message) 
        {
            MessageBox.Show(header, message,
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
        }

    }
}
