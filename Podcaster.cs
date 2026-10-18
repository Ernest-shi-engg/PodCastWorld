namespace PodCastWorld
{
    /// <summary>
    /// podcaster's properties inherited from User
    /// Podcaster -> child, User -> parent
    /// </summary>
    public class Podcaster: User
    {
        /// <summary>
        /// podcaster's function
        /// </summary>
        public string PodcastName {get; private set; }
        public string Genre {get; private set; }
        public string Description {get; private set; }
        public int Subscribers {get; private set; }
        // store all episodes created by this specific podcaster
        // now all podcasters have their own episodes list
        public List<Episode> Episodes { get; private set; } = new List<Episode>();
        /// <summary>
        /// call the params from parent(base)
        /// constructor of podcaster need all values from parent 'User'
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="podcastName"></param>
        /// <param name="genre"></param>
        /// <param name="description"></param>
        /// <param name="subscribers"></param>
        public Podcaster(string name, int age, string mobile, string email, 
        string password, string podcastName, string genre, string description) 
        : base(name, age, mobile, email, password)
        {
            // initialise
            PodcastName = podcastName;
            Genre = genre;
            Description = description;
            Subscribers = 0;
        }
        /// <summary>
        /// podcast name validate
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidPodName(string name)
        {
            // assume no letter contains in name
            bool ContainLetter = false;

            foreach(char c in name)
            {
                if (char.IsLetter(c))
                {
                    ContainLetter = true;
                }
                // invalid if char not reach all these requirements
                else if(!char.IsDigit(c) && c != ' ' && c != '\'' 
                && c != ':' && c != '-')
                {
                    return false;
                }
            }
            return ContainLetter;
        }
        /// <summary>
        /// increase subscribers count when listener subscribes
        /// </summary>
        public void AddSubscriber()
        {
            Subscribers++;
        }
        /// <summary>
        /// remove the subscribers
        /// </summary>
        public void RemoveSubscriber()
        {
            Subscribers--;
        }
    }
}