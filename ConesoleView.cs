using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace PodCastWorld
{
    ///<summary>
    /// handles console input & output for podcastworld
    /// </summary>
    public class ConsoleView
    {
        ///<summary>
        /// welcome sign display at the top
        ///</summary>
        public void DispWelcome()
        {          
            string border = "";

            // looping the border of '=+' instead of enumerate 
            for(int i = 0; i < 21; i++)
            {
                border = border + "=+";
            }

            Console.WriteLine(border + "==");
            Console.WriteLine("         Welcome to PodCastWorld!");
            Console.WriteLine("      Podcasting all over the world.");
            Console.WriteLine(border + "==");
            Console.WriteLine();
        }

        ///<summary>
        /// Main menu instruction
        ///</summary>
        public int MainMenu()
        {
            Console.WriteLine("Main Menu.");
            Console.WriteLine("Please make a choice from the menu below.");
            Console.WriteLine("1. Log in as a registered user.");
            Console.WriteLine("2. Register as a new user.");
            Console.WriteLine("3. Exit.");
            Console.WriteLine("Please enter a choice between 1 and 3:");

            int MenuInput = int.Parse(Console.ReadLine());
            return MenuInput;
        }

        ///<summary>
        /// handle registration menu
        /// </summary>
        public int RegMenu()
        {
            Console.WriteLine("Registration Menu.");
            Console.WriteLine("Please enter your user type.");
            Console.WriteLine("1. A regular listener.");
            Console.WriteLine("2. A premium listener.");
            Console.WriteLine("3. A podcaster.");
            Console.WriteLine("Please enter a choice between 1 and 3:");

            int RegInput = int.Parse(Console.ReadLine());
            return RegInput;
        }

        ///<summary>
        /// regular listener registration prompt
        /// </summary>
        public string ReadListenerName()
        {
            Console.WriteLine("Registering as a regular listener.");
            Console.WriteLine("Please enter your name:");
            string nameReg = Convert.ToString(Console.ReadLine());
            return nameReg;
        }
        public int ReadListenerAge()
        {
            Console.WriteLine("Please enter your age between 18 and 99:");

            // read user's input
            string input = Console.ReadLine();
            int age;

            // try to convert char/string into int
            while (!int.TryParse(input, out age))
            {
                Console.WriteLine("#####");
                Console.WriteLine("# Error - Supplied value must be an integral number.");
                Console.WriteLine("# Please try again.");
                Console.WriteLine("#####");
                Console.WriteLine("Please enter your age between 18 and 99:");
                input = Console.ReadLine();
            }
            return age;
        }
        public string ReadListenerMobile()
        {
            Console.WriteLine("Please enter your mobile number:");
            string mobileReg = Convert.ToString(Console.ReadLine());
            return mobileReg;
        }
        public string ReadListenerEmail()
        {
            Console.WriteLine("Please enter your email:");
            string emailReg = Convert.ToString(Console.ReadLine());
            return emailReg;
        }
        public string ReadListenerPassword()
        {
            Console.WriteLine("Please enter your password:");
            Console.WriteLine("Your password must:");
            Console.WriteLine("- be at least 8 characters long");
            Console.WriteLine("- contain a number");
            Console.WriteLine("- contain a lowercase letter");
            Console.WriteLine("- contain an uppercase letter");
            string passwordReg = Convert.ToString(Console.ReadLine());
            return passwordReg;
        }
        // registration successfully prompt
        public void RegSuccess(string name)
        {
            Console.WriteLine($"Congratulations {name}. You have registered as a regular listener.");
            Console.WriteLine();
        }

        ///<summary>
        /// log in instructions
        /// </summary>
        public string EmailVerify()
        {
            Console.WriteLine("Log in Menu.");
            Console.WriteLine("Please enter your email:");
            string emailLogin = Convert.ToString(Console.ReadLine());
            return emailLogin;
        }
        public string PasswordVerify()
        {
            Console.WriteLine("Please enter your password:");
            string passwordLogin = Convert.ToString(Console.ReadLine());
            return passwordLogin;
        }
        public void LogInSuccess(string name)
        {
            Console.WriteLine($"Welcome back {name}.");
            Console.WriteLine();
        }

        ///<summary>
        /// regular listener menu
        /// </summary>
        public int RegListnerMenu()
        {
            Console.WriteLine("Regular Listener Menu.");
            Console.WriteLine("Please make a choice from the menu below.");
            Console.WriteLine("1. See my details.");
            Console.WriteLine("2. Change my password.");
            Console.WriteLine("3. View all podcasts.");
            Console.WriteLine("4. Listen to a podcast episode.");
            Console.WriteLine("5. Provide feedback on a podcast episode.");
            Console.WriteLine("6. Log out.");
            Console.WriteLine("Please enter a choice between 1 and 6:");
            int listenerInput = int.Parse(Console.ReadLine());
            return listenerInput;
        }
        public void Details(User user)
        {
            Console.WriteLine("Your details.");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"Mobile phone number: {user.Mobile}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Episodes started: {user.EpisodesStarted}");
            Console.WriteLine($"Episodes completed: {user.EpisodesCompleted}");
            Console.WriteLine($"Total minutes listened to: {user.MinutesLlistened}");
            Console.WriteLine($"Advertisements listened to: {user.Ads}");
        }
        /// <summary>
        /// no registered user find prompt
        /// </summary>
        public void NoRegFind()
        {
            Console.WriteLine("#####");
            Console.WriteLine("# Error - There are no people registered.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// unregistered email
        /// </summary>
        public void NoEmailFind()
        {
            Console.WriteLine("#####");
            Console.WriteLine("# Error - Email is not registered.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// listener name invalid
        /// </summary>
        public void InfoInvalid(string info)
        {
            Console.WriteLine("#####");
            Console.WriteLine($"# Error - Supplied {info} is invalid.");
            Console.WriteLine("# Please try again.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// retry prompt if name invalid
        /// </summary>
        public string RetryName()
        {
            Console.WriteLine("Please enter your name:");
            string nameNew = Convert.ToString(Console.ReadLine());
            return nameNew;
        }
        /// <summary>
        /// password does not match with registered prompt
        /// </summary>
        public void PasswordNotMatch()
        {
            Console.WriteLine("#####");
            Console.WriteLine("# Error - Entered password does not match existing password.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// email already registered
        /// </summary>
        public void EmailAlreadyReg()
        {
            Console.WriteLine("#####");
            Console.WriteLine("# Error - Email already registered.");
            Console.WriteLine("# Please try again.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// password change - enter old
        /// </summary>
        /// <returns></returns>
        public string EnterCurrPaswrd()
        {
            Console.WriteLine("Please enter your current password:");
            return Console.ReadLine();
        }
        /// <summary>
        /// password change - enter new
        /// </summary>
        /// <returns></returns>
        public string EnterNewPaswrd()
        {
            Console.WriteLine("Please enter your new password:");
            return Console.ReadLine();
        }
        /// <summary>
        /// password change - confirm updated
        /// </summary>
        public void UpdatedPaswrd()
        {
            Console.WriteLine("Password has been updated.");
            Console.WriteLine();
        }
        /// <summary>
        /// changed password error due to duplicate or invalid
        /// </summary>
        /// <param name="message"></param>
        public void ChangePaswrdError(string message)
        {
            Console.WriteLine("#####");
            Console.WriteLine($"# Error - {message}.");
            Console.WriteLine("# Please try again.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// premium user login
        /// </summary>
        /// <returns></returns>
        public string ReadPremiumName()
        {
            Console.WriteLine("Registering as a premium listener.");
            Console.WriteLine("Please enter your name:");
            return Console.ReadLine();
        }
        /// <summary>
        /// read registration date for premium
        /// </summary>
        /// <returns></returns>
        public string ReadRegDate()
        {
            Console.WriteLine("Please enter the registration date in dd/MM/yyyy format:");
            return Console.ReadLine();
        }
        /// <summary>
        /// read pay id for premium
        /// </summary>
        /// <returns></returns>
        public int ReadPayID()
        {
            Console.WriteLine("Please enter your pay ID between 100000 and 999999:");
            int readPayID = int.Parse(Console.ReadLine());
            return readPayID;
        }
        /// <summary>
        /// premium user log in success
        /// </summary>
        /// <param name="name"></param>
        public void PremiumRegSucc(string name)
        {
            Console.WriteLine($"Congratulations {name}. You have registered as a premium listener.");
            Console.WriteLine();
        }
        public int PremiumMenu()
        {
            Console.WriteLine("Premium Listener Menu.");
            Console.WriteLine("Please make a choice from the menu below.");
            Console.WriteLine("1. See my details.");
            Console.WriteLine("2. Change my password.");
            Console.WriteLine("3. View all podcasts.");
            Console.WriteLine("4. Listen to a podcast episode.");
            Console.WriteLine("5. Listen to a subscribed podcast episode.");
            Console.WriteLine("6. Subscribe to a podcast.");
            Console.WriteLine("7. Unsubscribe from a podcast.");
            Console.WriteLine("8. Provide feedback on a podcast episode.");
            Console.WriteLine("9. Log out.");
            Console.WriteLine("Please enter a choice between 1 and 9:");
            int PremInput = int.Parse(Console.ReadLine());
            return PremInput;
        }
        /// <summary>
        /// premium user's details
        /// </summary>
        /// <param name="user"></param>
        public void PremiumDetails(Premium user)
        {
            Console.WriteLine("Your details.");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"Mobile phone number: {user.Mobile}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Episodes started: 0");
            Console.WriteLine($"Episodes completed: 0");
            Console.WriteLine($"Total minutes listened to: 0");
            Console.WriteLine($"Registration Date: {user.RegDate}");
            Console.WriteLine($"Pay ID: {user.PayID}");
        }
        /// <summary>
        /// read the podcster's name
        /// </summary>
        /// <returns></returns>
        public string ReadPodcasterName()
        {
            Console.WriteLine("Registering as a podcaster.");
            Console.WriteLine("Please enter your name:");
            return Console.ReadLine();
        }
        /// <summary>
        /// podcast genre choices
        /// </summary>
        /// <returns></returns>
        public int ReadpPodcasterGenre()
        {
            Console.WriteLine("Please enter your podcast genre:");
            Console.WriteLine("1. News.");
            Console.WriteLine("2. Politics.");
            Console.WriteLine("3. Sports.");
            Console.WriteLine("4. Entertainment.");
            Console.WriteLine("5. Education.");
            Console.WriteLine("6. Hobbies.");
            Console.WriteLine("Please enter a choice between 1 and 6:");
            
            // handle invalid input
            int genreInput = int.Parse(Console.ReadLine());

            // input only acceptable in this bound
            while (genreInput < 1 || genreInput > 6)
            {
                Console.WriteLine("#####");
                Console.WriteLine("# Error - Supplied menu input is out of range.");
                Console.WriteLine("# Please try again.");
                Console.WriteLine("#####");
                Console.WriteLine("Please enter a choice between 1 and 6:");
                // read the new input again
                genreInput = int.Parse(Console.ReadLine());
            }
            return genreInput;
        }
        /// <summary>
        /// read the podcast's name
        /// </summary>
        /// <returns></returns>
        public string ReadPodcastName()
        {
            Console.WriteLine("Please enter your podcast name:");
            return Console.ReadLine();
        }
        /// <summary>
        /// read podcast description
        /// </summary>
        /// <returns></returns>
        public string ReadPodcastDescription()
        {
            Console.WriteLine("Please enter your podcast description:");
            return Console.ReadLine();
        }
        /// <summary>
        /// podcaster register successful
        /// </summary>
        public void PodcasterRegiSucc(string name)
        {
            Console.WriteLine($"Congratulations {name}. You have registered as a podcaster.");
            Console.WriteLine();
        }
        /// <summary>
        /// podcaster's menu
        /// </summary>
        /// <returns></returns>
        public int PodcasterMenu()
        {
            Console.WriteLine("Podcaster Menu.");
            Console.WriteLine("Please make a choice from the menu below.");
            Console.WriteLine("1. See my details.");
            Console.WriteLine("2. Change my password.");
            Console.WriteLine("3. Create an episode.");
            Console.WriteLine("4. View my episodes.");
            Console.WriteLine("5. View statistics about my episodes.");
            Console.WriteLine("6. View feedback about my episodes.");
            Console.WriteLine("7. Log out.");
            Console.WriteLine("Please enter a choice between 1 and 7:");
            return int.Parse(Console.ReadLine());
        }
        public void PodcasterDetails(Podcaster user)
        {
            Console.WriteLine("Your details.");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"Mobile phone number: {user.Mobile}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Podcast name: {user.PodcastName}");
            Console.WriteLine($"Podcast genre: {user.Genre}");
            Console.WriteLine($"Podcast description: {user.Description}");
            Console.WriteLine($"Number of podcast subscribers: {user.Subscribers}");
            Console.WriteLine();
        }
        /// <summary>
        /// no podcast
        /// </summary>
        public void NoPodcast()
        {
            Console.WriteLine("#####");
            Console.WriteLine("# Error - There are no podcasts.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// display the podcast for user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="purpose"></param>
        /// <param name="podcasts"></param>
        /// <returns></returns>
        public int ShowPodcast(string name, string purpose, List<Podcaster> podcasts)
        {
            // i.e. --> {-25}, {-5} are display output width for formatting
            Console.WriteLine($"Displaying {purpose} for {name}.");
            Console.WriteLine($"{"Num", -5}{"Name", -25}{"Podcaster", -20}{"Subscribers", -15}");

            for (int i = 0; i < podcasts.Count; i++)
            {
                Podcaster p = podcasts[i];

                Console.WriteLine($"{(i+1)+".", -5}{p.PodcastName, -25}{p.Name, -20}{p.Subscribers, -15}");
            }
            Console.WriteLine("Please enter the podcast's menu number to view more information or enter 0 to cancel:");
            return int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// display podcast information
        /// </summary>
        /// <param name="p"></param>
        public void ShowPodcastInfo(Podcaster p)
        {
            Console.WriteLine("Podcast Information.");
            Console.WriteLine($"Name: {p.PodcastName}");
            Console.WriteLine($"Podcaster: {p.Name}");
            Console.WriteLine($"Podcast description: {p.Description}");
        }
        /// <summary>
        /// different responses if there is no episodes info was found
        /// with respect the identity is user or podcaster
        /// </summary>
        /// <param name="isPodcaster"></param>
        public void NoEpisodes(bool isPodcaster)
        {
            Console.WriteLine("#####");

            // response to podcaster 
            if (isPodcaster)
            {
                Console.WriteLine("# Error - You have not recorded any episodes.");
            }
            // response to users
            else
            {
                Console.WriteLine("# Error - The podcaster has not recorded any episodes.");
            }

            Console.WriteLine("#####");
        }
        /// <summary>
        /// read episodes name from podcaster
        /// </summary>
        /// <returns></returns>
        public string ReadEpisodeName()
        {
            Console.WriteLine("Please enter your episode's name:");
            return Console.ReadLine();
        }
        /// <summary>
        /// read episodes descriptions from podcaster
        /// </summary>
        /// <returns></returns>
        public string ReadEpisodeDescription()
        {
            Console.WriteLine("Please enter your podcast description:");
            return Console.ReadLine();
        }
        /// <summary>
        /// read episode's recorded date from podcaster
        /// </summary>
        /// <returns></returns>
        public string ReadEpisodeDate()
        {
            Console.WriteLine("Please enter your episode's recorded date in dd/MM/yyyy format:");
            return Console.ReadLine();
        }
        /// <summary>
        /// read episode's length from podcaster
        /// </summary>
        /// <returns></returns>
        public int ReadEpisodeLength()
        {
            Console.WriteLine("Please enter your episode's length in minutes between 1 and 300:");
            return int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// read the answer from podcaster does his/her episode available for regular listener or only premium
        /// podcaster input 'true' or 'false' and recognise these as boolean answer
        /// </summary>
        /// <returns></returns>
        public bool ReadEpisodePremium()
        {
            Console.WriteLine("Please enter if episode is reserved for premium listeners only (true/false):");

            bool premium;
            string input = Console.ReadLine();
            // handle if input is 'f', 't' etc.
            // TryParse -> try to convert input into desired type, true when convert success and assign the val into premium
            // syntax & method source: https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-10.0
            while (!bool.TryParse(input, out premium))
            {
                Console.WriteLine("#####");
                Console.WriteLine("# Error - Supplied value must be a boolean.");
                Console.WriteLine("# Please try again.");
                Console.WriteLine("#####");
                Console.WriteLine("Please enter if episode is reserved for premium listeners only (true/false):");
                input = Console.ReadLine();
            }
            return premium;
        }
        /// <summary>
        /// print episode info table for podcaster
        /// </summary>
        /// <param name="episodes"></param>
        public void ShowEpisodes4Podcaster(List<Episode> episodes)
        {
            Console.WriteLine("Your episodes.");
            // episode info table filled by podcaster -- title
            Console.WriteLine($"{"Num", -5}{"Name", -30}{"Recorded Date", -15}{"Length (min)", -15}{"Premium Only", -15}");

            for (int i = 0; i < episodes.Count; i++)
            {
                /// fetch the 'i'th episode from list and print its property
                Episode e = episodes[i];
                // episode info table -- body
                Console.WriteLine($"{(i + 1) + ".", -5}{e.Name, -30}{e.RecordedDate, -15}{e.Length, -15}{e.PremiumOnly, -15}");

                Console.WriteLine();
            }
        }
        /// <summary>
        /// episode's length is invalid
        /// </summary>
        public void EpLenInvalid()
        {
            Console.WriteLine("#####");
            Console.WriteLine("# Error - Supplied value is out of range.");
            Console.WriteLine("# Please try again.");
            Console.WriteLine("#####");
        }
        /// <summary>
        /// show episodes info for lisenters, same formatting as '4Podcaster'
        /// also 1 more function that user could check description of episodes
        /// </summary>
        /// <param name="episodes"></param>
        public void ShowEpisodes4Listener(List<Episode> episodes)
        {
            Console.WriteLine("List of episodes.");
            // episode info table filled by podcaster -- title
            Console.WriteLine($"{"Num", -5}{"Name", -30}{"Recorded Date", -15}{"Length (min)", -15}{"Premium Only", -15}{"Description", -30}");

            for (int i = 0; i < episodes.Count; i++)
            {
                /// fetch the 'i'th episode from list and print its property
                Episode e = episodes[i];
                // episode info table -- body
                Console.WriteLine($"{(i + 1) + ".", -5}{e.Name, -30}{e.RecordedDate, -15}{e.Length, -15}{e.PremiumOnly, -15}{e.Description, -30}");

                Console.WriteLine();
            }
        }
        /// <summary>
        /// read the episode choice from reg listener
        /// </summary>
        /// <returns></returns>
        public int ReadEpisodeChoice()
        {
            Console.WriteLine("Please enter the episode's menu number to listen to the episode or enter 0 to cancel:");
            return int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// read the listener's date
        /// </summary>
        /// <returns></returns>
        public string ReadListeningDate()
        {
            Console.WriteLine("Please enter the date in dd/MM/yyyy format that you listened to the episode:");
            return Console.ReadLine();
        }
        /// <summary>
        /// read the reg listener's listening time
        /// </summary>
        /// <returns></returns>
        public int ReadListeningMins()
        {
            Console.WriteLine("Please enter how many minutes you listened to the episode:");
            return int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// disp subscribed and available podcast for premiun user
        /// </summary>
        /// <param name="subscribed"></param>
        /// <param name="available"></param>
        /// <returns></returns>
        public int ShowSubscriptions(List<Podcaster> subscribed, 
        List<Podcaster> available)
        {
            Console.WriteLine("Subscribed podcasts.");

            if (subscribed.Count == 0)
            {
                Console.WriteLine("You are not subscribed to any podcasts.");
            }
            else
            {
                DispPodcastTable(subscribed);
            }
            Console.WriteLine("Available podcasts.");

            if (available.Count == 0)
            {
                Console.WriteLine("You are subscribed to all available podcasts.");
                return 0;
            }
            DispPodcastTable(available);

            Console.WriteLine("Please enter the podcast's menu number to subscribe or enter 0 to cancel:");
            return int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// dis a table of podcasts with info
        /// </summary>
        /// <param name="podcasts"></param>
        // disp the podcast table with same formatting as '4Podcaster'
        public void DispPodcastTable(List<Podcaster> podcasts)
        {
            // episode info table -- title
            Console.WriteLine($"{"Num", -5}{"Name", -25}{"Podcaster", -20}{"Subscribers", -15}");
            for (int i = 0; i < podcasts.Count; i++)
            {
                /// fetch the 'i'th episode from list and print its property
                Podcaster p = podcasts[i];
                // episode info table -- body
                Console.WriteLine($"{(i + 1) + ".", -5}{p.PodcastName, -25}{p.Name, -20}{p.Subscribers, -15}");
            }
        }
        /// <summary>
        /// disp all podcast subscribed by a premium user
        /// with new function to unsubscribe a selected podcast
        /// </summary>
        /// <param name="subscribed"></param>
        /// <returns></returns>
        public int ShowUnsubscriptions(List<Podcaster> subscribed)
        {
            Console.WriteLine("Subscribed podcasts.");
            // if there is no subscribed record
            if (subscribed.Count == 0)
            {
                Console.WriteLine("You are not subscribed to any podcasts.");
                return 0;
            }

            DispPodcastTable(subscribed);

            Console.WriteLine("Please enter the podcast's menu number to unsubscribe or enter 0 to cancel:");
            return int.Parse(Console.ReadLine());
        }

        ///<summary>
        /// display the exit interactive message
        /// </summary>
        public void Exit()
        {
            Console.WriteLine("See you on the next rotation.");
        }
    }
}