namespace PodCastWorld
{
    ///<summary>
    /// store information for all user types
    /// </summary>
    public class User
    {
        // building the PROPERTIES which include {name, age, mobile, email, password} for user
        public string Name{ get; private set; }
        public int Age{ get; private set; }
        public string Mobile{ get; private set; }
        public string Email{ get; private set;}
        public string Password{get; private set; }
        // the following four properties are for reg listeners
        public int EpisodesStarted { get; set;}
        public int EpisodesCompleted {get; set;}
        public int MinutesLlistened {get; set; }
        public int Ads {get; set; }


        /// <summary>
        /// create a user with all registration details (PARAMETERS)
        /// </summary>
        /// <param name="name"> User's name </param>
        /// <param name="age"> User's age</param>
        /// <param name="mobile"> User's mobile number </param>
        /// <param name="email"> User's email </param>
        /// <param name="password"> User's password </param>
        // building constructor for initialisation
        public User(string name, int age, string mobile, string email, string password)
        {
            // assign values into properties
            Name = name;
            Age = age;
            Email = email;
            Mobile = mobile;
            Password = password;
        }
        /// <summary>
        /// check the validate of password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsValidPassword(string password)
        {
            // assume passwrod invalid for init
            bool ContainNumber = false;
            bool ContainLower = false;
            bool ContainUpper = false;

            // check if pasword satisfy 8 char length
            if (password.Length < 8)
            {
                return false;
            }

            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    ContainNumber = true;
                }
                if (char.IsLower(c))
                {
                    ContainLower = true;
                }
                if (char.IsUpper(c))
                {
                    ContainUpper = true;
                }
            }
            // password valid only when all requirements reached
            return ContainNumber && ContainLower && ContainUpper;
        }

        /// <summary>
        /// check validate status of user name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidName(string name)
        {
            bool ContainLetter = false;

            foreach (char c in name)
            {
                if (char.IsLetter(c))
                {
                    ContainLetter = true;
                }
                // name requirements
                else if ( c != ' ' && c != '-' && c != '\'' && c != '.')
                {
                    return false;
                }
            }
            return ContainLetter;
        }
        /// <summary>
        /// age restriction validate
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        public static bool IsValidAge(int age)
        {
            return age >= 18 && age <= 99;
        }
        /// <summary>
        /// mobile formatting validate
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsValidMobile(string mobile)
        {
            if (mobile.Length != 10)
            {
                return false;
            }
            // mobile should have a leading '0'
            if (mobile[0] != '0')
            {
                return false;
            }
            // all char in mobile should be digits
            foreach (char c in mobile)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// email formatting validate
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {
            // number of @ init
            int atNum = 0;

            foreach (char c in email)
            {
                if (c == '@')
                {
                    atNum++;
                }
            }

            // restrict only 1 '@' and either side of '@' has char
            // realise by letting '@' dont lay at the left and right edge
            return atNum == 1 && email.IndexOf('@') > 0 && email.IndexOf('@') < email.Length - 1;
        }
        /// <summary>
        /// user want to change newpassword
        /// </summary>
        /// <param name="newPassword"></param>
        public void ChangePassword(string newPassword)
        {
            // assign value 'newPassword' to private property 'Password'
            Password = newPassword;
        }
    }
}