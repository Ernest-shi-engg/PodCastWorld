using System;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace PodCastWorld
{
    class Program
    {
        static void Main()
        {
            // new object created for furthur use
            ConsoleView view = new ConsoleView();
            // create users object and store all users in a list
            List<User> users = new List<User>();
            view.DispWelcome(); // call the welcome block method

            while (true)
            {
                int MenuInput = view.MainMenu(); // get user's input 

                if (MenuInput == 3)
                {
                    view.Exit(); // handle exit message
                    break;
                }
                else if (MenuInput == 2)
                {
                    int RegInput = view.RegMenu(); // register as new user
                    if (RegInput == 1 || RegInput == 2 || RegInput == 3)
                    {
                        
                        string nameReg;
                        // sorting reg/premium/podcaster user by name
                        if (RegInput == 1)
                        {
                            nameReg = view.ReadListenerName();
                        }
                        else if (RegInput == 2)
                        {
                            nameReg = view.ReadPremiumName();
                        }
                        else
                        {
                            nameReg = view.ReadPodcasterName();
                        }
                        // name validation
                        while (!User.IsValidName(nameReg))
                        {
                            view.InfoInvalid("name");
                            nameReg = view.RetryName() ;
                        }

                        // age validation
                        int ageReg = view.ReadListenerAge();
                        while (!User.IsValidAge(ageReg))
                        {
                            view.InfoInvalid("age");
                            ageReg = view.ReadListenerAge();
                        }

                        // mobile validation
                        string mobileReg = view.ReadListenerMobile();
                        while (!User.IsValidMobile(mobileReg))
                        {
                            // argument "mobile number" fill param "info"
                            view.InfoInvalid("mobile number");
                            mobileReg = view.ReadListenerMobile();
                        }

                        // email validation
                        string emailReg = view.ReadListenerEmail();

                        while (true)
                        {
                            // if email formatting is not valid
                            if (!User.IsValidEmail(emailReg))
                            {
                                view.InfoInvalid("email");
                            }
                            else
                            {
                                // assume email not exist before
                                bool emailExist = false;

                                // searching repeated email
                                foreach (User existingUser in users)
                                {
                                    if (existingUser.Email == emailReg)
                                    {
                                        emailExist = true;
                                        break;
                                    }
                                }
                                // if bool '!emailExist' == true -> continue executing while loop again
                                // if bool '!emailExist' == false -> break and jump out of while loop
                                if (!emailExist)
                                {
                                    break;
                                }
                                // print only emailExist == true
                                view.EmailAlreadyReg();

                            }
                            emailReg = view.ReadListenerEmail();
                        }

                        // password validation
                        string passwordReg = view.ReadListenerPassword();
                        while (!User.IsValidPassword(passwordReg))
                        {
                            view.InfoInvalid("password");
                            passwordReg = view.ReadListenerPassword();
                        }

                        // regular user registration
                        if (RegInput == 1)
                        {
                            // create user object for furthur calling
                            User user = new User(nameReg, ageReg, mobileReg, emailReg, passwordReg);
                            users.Add(user); // accumulate users into users list
                            view.RegSuccess(nameReg);
                        }
                        // premium user registration
                        else if (RegInput == 2)
                        {
                            string regdate = view.ReadRegDate();
                            // handle invalid registered date
                            while (!Premium.IsValidDate(regdate))
                            {
                                view.InfoInvalid("date");
                                regdate = view.ReadRegDate();
                            }

                            int payid = view.ReadPayID();
                            // handle invalid payid
                            while (payid < 100000 || payid > 999999)
                            {
                                view.InfoInvalid("pay ID");
                                payid = view.ReadPayID();
                            }

                            // premium object created
                            Premium user = new Premium(nameReg, ageReg, mobileReg, emailReg, passwordReg, regdate, payid);
                            users.Add(user);
                            view.PremiumRegSucc(nameReg);
                        }
                        // podcaster registration
                        else if (RegInput == 3)
                        {
                            // user's genre input selections
                            int genreInput = view.ReadpPodcasterGenre();

                            string[] genres = {"News", "Politics", "Sports", "Entertainment", "Education", "Hobbies"};

                            // C# iterating index from '0' -> 'News'
                            // user input = index + 1
                            string genre = genres[genreInput - 1];
                            string podcastName = view.ReadPodcastName();

                            // if podcst name is invalid
                            while (!Podcaster.IsValidPodName(podcastName))
                            {
                                view.InfoInvalid("podcast name");
                                podcastName = view.ReadPodcastName();
                            }
                            string description = view.ReadPodcastDescription();

                            // create new object for podcaster
                            Podcaster user = new Podcaster(nameReg, ageReg, mobileReg, emailReg, passwordReg
                            , podcastName, genre, description);

                            users.Add(user);
                            view.PodcasterRegiSucc(nameReg);
                        }
                    }
                }
                else if (MenuInput == 1)
                {        
                    // handle if there is no registered user           
                    if (users.Count == 0)
                    {
                        view.NoRegFind();
                        continue;
                    }

                    // read user's email login input
                    string emailLogin = view.EmailVerify();
                    // init var 'matcheduser' to find if this user registered
                    User matchedUser = null;
                   
                    while (matchedUser == null)
                    {
                        // searching email until a registered user in users is found
                        foreach(User user in users)
                        {
                            if (emailLogin == user.Email)
                            {
                                matchedUser = user;
                                break;
                            }
                        }

                        // if user can't found in users list
                        if (matchedUser == null)
                        {
                            view.NoEmailFind();
                            Console.WriteLine("Please enter your email:");
                            emailLogin = Console.ReadLine();
                        }
                    }

                    // read user's password login input
                    string passwordLogin = view.PasswordVerify();
                    // user's password input conflict with users list registered
                    while (passwordLogin != matchedUser.Password)
                    {
                        // password formatting check
                        if (!User.IsValidPassword(passwordLogin))
                        {
                            view.InfoInvalid("password");
                        }
                        // password does not match with users list
                        else
                        {
                            view.PasswordNotMatch();
                        }
                        passwordLogin = view.PasswordVerify();
                    }

                    // iterating existed user in users list verifying with log in info
                    foreach (User user in users)
                    {
                        if (emailLogin == user.Email && passwordLogin == user.Password)
                        {
                            view.LogInSuccess(user.Name);

                            // while listener logged in
                            bool loggedIn = true;
                            while (loggedIn)
                            {
                                // this int var stores user input from view
                                int listenerInput;

                                // sort menu for reg or prem user or podcaster
                                if(user is Premium)
                                {
                                    listenerInput = view.PremiumMenu();
                                }
                                else if (user is Podcaster)
                                {
                                    listenerInput = view.PodcasterMenu();
                                }
                                else
                                {
                                    listenerInput = view.RegListnerMenu();
                                }

                                // collect all registered podcasters into podcast list
                                List<Podcaster> podcasts = new List<Podcaster>();
                                foreach (User existingUser in users)
                                {
                                    if (existingUser is Podcaster p)
                                    {
                                        podcasts.Add(p);
                                    }
                                }
                                // sorting podcast name by alphabet on table disp
                                // a & b are two side being comparision
                                // OrdinalIgnoreCase -> compare with respect to the alphabet and ignore the U/L case
                                // list.Sort method source: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-10.0
                                // StringComparison.OrdinalIgnoreCase source: https://learn.microsoft.com/en-us/dotnet/api/system.stringcomparer.ordinalignorecase?view=net-10.0
                                podcasts.Sort((a, b) => string.Compare(a.PodcastName, b.PodcastName, StringComparison.OrdinalIgnoreCase));
                                // check if podcasts are available for this podcaster
                                bool hasPodcast = podcasts.Count > 0;

                                // handle different regular listener input
                                switch (listenerInput)
                                {
                                    case 1:
                                    // view user details
                                    // view premium details
                                    if (user is Premium premiumUser)
                                    {
                                        view.PremiumDetails(premiumUser);
                                    }
                                    else if (user is Podcaster podcaster)
                                    {
                                        view.PodcasterDetails(podcaster);
                                    }
                                    // view reg details
                                    else
                                    {
                                        view.Details(user);
                                    }
                                    break;

                                    case 2:
                                    // change password

                                    // currentPaswrd read the current paswrd
                                    string currentPaswrd = view.EnterCurrPaswrd();

                                    // check when paswrd entered not match with stored
                                    while(currentPaswrd != user.Password)
                                    {
                                        view.ChangePaswrdError("Entered password does not match existing password");
                                        currentPaswrd = view.EnterCurrPaswrd();
                                    }

                                    // newPaswrd read new paswrd
                                    string newPaswrd = view.EnterNewPaswrd();
                                    
                                    // check current password
                                    while(newPaswrd == user.Password || !User.IsValidPassword(newPaswrd))
                                    {
                                        // check new paswrd formatting validate
                                        if (!User.IsValidPassword(newPaswrd))
                                        {
                                            view.InfoInvalid("password");    
                                        }
                                        // check if duplicate paswrd
                                        else
                                        {
                                            view.ChangePaswrdError("New password is the same as the existing password");    
                                        }
                                        newPaswrd = view.EnterNewPaswrd();
                                    }
                                    user.ChangePassword(newPaswrd);
                                    view.UpdatedPaswrd();
                                    break;

                                    // handle podcast info related menu options
                                    case 3: // view podcasts
                                    case 4: // listen podcast episode
                                    case 5: // provide feedback
                                    // podcasters cannot view their own episodes if none exist
                                    if (user is Podcaster podcasterUser)
                                        {
                                            if (listenerInput == 3)
                                            {
                                                // read all info for new episode

                                                string epName = view.ReadEpisodeName();
                                                // check episode name
                                                while (!Podcaster.IsValidPodName(epName))
                                                {
                                                    view.InfoInvalid("episode's name");
                                                    epName = view.ReadEpisodeName();
                                                }

                                                string epDesc = view.ReadEpisodeDescription();
                                                // description can't be empty
                                                while (string.IsNullOrWhiteSpace(epDesc))
                                                {
                                                    view.InfoInvalid("podcast description");
                                                    epDesc = view.ReadEpisodeDescription();
                                                }

                                                string epDate = view.ReadEpisodeDate();
                                                // check date validate using existed valiadation
                                                while (!Premium.IsValidDate(epDate))
                                                {
                                                    view.InfoInvalid("date");
                                                    epDate = view.ReadEpisodeDate();
                                                }

                                                int epLen = view.ReadEpisodeLength();
                                                // length of episode only valid between 1-300 mins
                                                while(epLen < 1 || epLen > 300)
                                                {
                                                    view.EpLenInvalid();
                                                    epLen = view.ReadEpisodeLength();
                                                }

                                                bool epPrem = view.ReadEpisodePremium();
                                                
                                                // create episode object
                                                Episode episode = new Episode(epName, epDesc, epDate, epLen, epPrem); 
                                                // save new created episode into Episodes list of podcaster
                                                // episode -> one episode
                                                // podcasterUser.Episodes -> all episodes this podcaster published
                                                podcasterUser.Episodes.Add(episode);
                                            }
                                            else if (listenerInput == 4)
                                            {       
                                                if (podcasterUser.Episodes.Count == 0)
                                                {
                                                    view.NoEpisodes(true);
                                                }
                                                else
                                                {
                                                    view.ShowEpisodes4Podcaster(podcasterUser.Episodes);
                                                }
                                            }
                                            else if (listenerInput == 5)
                                            {
                                                view.NoEpisodes(true);
                                            }
                                            break;
                                        }

                                        // stop if no podcast registered/found
                                        if (!hasPodcast)
                                        {
                                            view.NoPodcast();
                                            break;
                                        }

                                        // purpose in 'view' section to fill the params
                                        string purpose = "all podcasts";
                                        string name = user.Name;

                                        if (listenerInput == 4)
                                        {
                                            purpose = "podcasts";
                                            name += " to listen to";
                                        }
                                        else if(listenerInput == 5)
                                        {
                                            purpose = "potential podcasts";
                                            name += " to provide feedback on";
                                        }
                                        
                                        // display podcast list and read the user's choice input
                                        int choice = view.ShowPodcast(name, purpose, podcasts);
                                        

                                        if (choice != 0)
                                        {
                                            // convert menu number into list index
                                            Podcaster selected = podcasts[choice - 1];

                                            if (listenerInput == 3)
                                            {
                                                // disp info about the selected podcast
                                                view.ShowPodcastInfo(selected);

                                                // check availablity the episode chosen from user selected podcast
                                                if(selected.Episodes.Count == 0)
                                                {
                                                    view.NoEpisodes(false);
                                                }
                                                // else disp all available episodes
                                                else
                                                {
                                                    view.ShowEpisodes4Listener(selected.Episodes);
                                                }
                                            }
                                            else if (listenerInput == 4)
                                            {
                                                // check if selected podcaster has recorded any eps
                                                if (selected.Episodes.Count == 0)
                                                {
                                                    // prompt listener there are no episodes available
                                                    view.NoEpisodes(false);
                                                }
                                                else
                                                {
                                                    // show selectd podcast info and the eps
                                                    view.ShowPodcastInfo(selected);
                                                    view.ShowEpisodes4Listener(selected.Episodes);
                                                    
                                                    // read the ep choice from listener wants to listen
                                                    int epChoice = view.ReadEpisodeChoice();

                                                    if(epChoice != 0)
                                                    {
                                                        // get selected episode from podcaster's ep list
                                                        Episode selectedEp = selected.Episodes[epChoice - 1];

                                                        string listeningDate = view.ReadListeningDate();
                                                        int minutes = view.ReadListeningMins();

                                                        // update by increment
                                                        user.EpisodesStarted++;
                                                        user.MinutesLlistened += minutes;

                                                        if (minutes >= selectedEp.Length)
                                                        {
                                                            user.EpisodesCompleted++;

                                                            Console.WriteLine($"Congratulations {user.Name}. You have finished the episode {selectedEp.Name}.");
                                                            Console.WriteLine();

                                                        }
                                                        else
                                                        {
                                                            // calculate the remianing time if not reach full length
                                                            int remain = selectedEp.Length - minutes;
                                                            Console.WriteLine($"In total you have listened to podcast {selected.PodcastName}, episode {selectedEp.Name}, for {minutes} minutes. The last time you listened was on {listeningDate}. You have {remain} minutes remaining.");
                                                            Console.WriteLine();
                                                        }
                                                        
                                                        // add ads every 30 mins this reg listener listsned
                                                        if (user is not Premium)
                                                        {
                                                            user.Ads += minutes / 30;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                view.NoEpisodes(false);
                                            }
                                        }
                                        break;

                                    case 6:
                                        // log out for reg user
                                        if (user is not Premium && user is not Podcaster)
                                        {
                                            loggedIn = false;
                                        }
                                        else if (user is Premium premiumListener)
                                        {
                                            if (!hasPodcast)
                                            {
                                                view.NoPodcast();
                                                break;
                                            }
                                            
                                            // 'available' -> podcast that premium user hasn't subscribed yet and available to subscribe
                                            // creat the available list to store not subscribed podcasts
                                            List<Podcaster> available = new List<Podcaster>();

                                            // iterating thru all podcast and find the not subscribed podcast of this premium listener
                                            foreach (Podcaster p in podcasts)
                                            {
                                                // check does this podcast already existed in user's sub list or not
                                                if (!premiumListener.Subscriptions.Contains(p))
                                                {
                                                    // only add podcast when it was not subscribed
                                                    available.Add(p);
                                                }
                                            }

                                            // disp subscribed and all available podcasts
                                            int subChoice = view.ShowSubscriptions(premiumListener.Subscriptions, available);

                                            if (subChoice != 0)
                                            {
                                                // save the selected podcast into listener's subscribe list
                                                Podcaster selectedPodcast = available[subChoice - 1];
                                                // save subscription
                                                premiumListener.Subscriptions.Add(selectedPodcast);
                                                // sort subscribed podcats by alphabet
                                                // source declared on 'tableDisp' already
                                                premiumListener.Subscriptions.Sort((a,b) => string.Compare(a.PodcastName,
                                                 b.PodcastName, StringComparison.OrdinalIgnoreCase));
                                                // increment the subscriber count of this podcast
                                                selectedPodcast.AddSubscriber();

                                                Console.WriteLine($"Congratulations, you have been subscribed to {selectedPodcast.PodcastName}.");
                                            }
                                        }
                                        else if (user is Podcaster)
                                        {
                                            view.NoEpisodes(true);
                                        }
                                        break;

                                    case 7:
                                        // log out for podcaster
                                        if (user is Podcaster)
                                        {
                                            loggedIn = false;
                                        }
                                        else if (user is Premium premiumUnsubUser)
                                        {
                                            // if user is premium and no podcast in the system -> print error msg
                                            if (!hasPodcast)
                                            {
                                                view.NoPodcast();
                                                break;
                                            }

                                            int unsubChoice = view.ShowUnsubscriptions(premiumUnsubUser.Subscriptions);

                                            if (unsubChoice != 0)
                                            {
                                                // find this user's podcast -> [unsubChoice - 1]
                                                Podcaster selectedPodcast = premiumUnsubUser.Subscriptions[unsubChoice - 1];
                                                
                                                // remove the selected podcast from premium listener's list
                                                premiumUnsubUser.Subscriptions.Remove(selectedPodcast);
                                                // decrease the count
                                                selectedPodcast.RemoveSubscriber();

                                                Console.WriteLine($"You have been unsubscribed to {selectedPodcast.PodcastName}.");
                                            }
                                        }
                                        break;

                                    case 8:
                                    // provide feedback
                                        if(user is Premium)
                                        {
                                            if (!hasPodcast)
                                            {
                                                view.NoPodcast();
                                            }
                                            else
                                            {
                                                int feedbackChoice = view.ShowPodcast(user.Name + 
                                                "to provide feedback on", "potential podcasts", podcasts);

                                                if (feedbackChoice != 0)
                                                {
                                                    view.NoEpisodes(false);
                                                }
                                            }
                                        }
                                        break;

                                    case 9:
                                    // log out for prem user
                                    if (user is Premium)
                                    {
                                        loggedIn = false;
                                    }
                                    break;
                                }
                            }
                            break;
                        }                  
                    }
                }
            }
        }
    }
}