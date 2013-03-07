using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public void setEmail(string email)
        {
                this.email = email;
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
                //error message
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

    }
}
