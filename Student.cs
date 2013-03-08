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
        
        /* By making the methods that include data validation
         * return a boolean they can report back to the calling 
         * method to indicate whether the set has been successful or not.
         */

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
        
        /* Validation methods */
        
        
        /* Validates the Kimlik number - this is the one to work on... */
		private static bool isValidKimlik (string kimlik)
		{
			bool isValid = true; //Boolean flag. The kimlik is innocent until proven guilty :)
			/*
			 * The tests that don't require the kimlikNumber to be converted to a char array are first
			 * so that an input that doesn't satisfy these primary criteria is not reduntantly converted.
			 */
			if (Regex.IsMatch(kimlik, "[0-9]") && kimlik.Length == 11) { // Most fundamental two tests here.
				int[] kimlikCharArray = kimlik.Select(ch => ch - '0').ToArray();
				if (kimlikCharArray[0] == 0) { 
					isValid = false; 
				} else {
					int firstSubTotal = 0;
					int secondSubTotal = 0;
					// This loop makes two subtotals of the array 0th, 2nd, 4th, 6th, 8th elements and 1st, 3rd, 7nth elements
					for (int i=0; i<9; i++){
						if (i % 2 == 0) { 
							firstSubTotal += kimlikCharArray[i];
						} else {
							secondSubTotal += kimlikCharArray[i];
						}
					}
					if ((firstSubTotal*7 - secondSubTotal) % 10 == kimlikCharArray[9]){
						isValid = firstSubTotal+secondSubTotal+kimlikCharArray[9] == kimlikCharArray[10]; // This tests sophisticated kimlik number structure :)
					}
				}
			} else { isValid = false; }
			return isValid;
		}
        
        /* Validates the email address*/
        private bool isValidAddress(string email) 
        {
            /*If the regular expression (regex) included here doesn't meet expectations 
             *there are loads more on the internet. 
             *Try: http://regexlib.com/DisplayPatterns.aspx?AspxAutoDetectCookieSupport=1
             */
            
            Regex regex = new Regex(@"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*(\.[a-zA-Z]{2,6})$");
            Match match = regex.Match(email);
            return match.Success; //If the address is valid, match.Success returns true, else false.
        }
        
        /* Method to pop-up an error MessageBox box */
        private void showErrorMessage(string header, string message) 
        {
            MessageBox.Show(header, message,
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
        }

    }
}
