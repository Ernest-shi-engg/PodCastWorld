namespace PodCastWorld
{
    /// <summary>
    /// premium listener's properties inherited from User
    /// Premium -> child, User -> parent
    /// </summary>
    public class Premium : User
    {
        /// <summary>
        /// premium listener has registration date and PayID function
        /// build PROPERTY 'RegDate & PayID'
        /// </summary>
        public string RegDate { get; private set; }
        public int PayID { get; private set; }
        public List<Podcaster> Subscriptions { get; private set; } 
        = new List<Podcaster>(); // store subscriptions of podcasts by premium listener
        /// <summary>
        /// call the params from parent(base)
        /// constructor of premium need all values from parent
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="regdate"></param>
        /// <param name="id"></param>
        public Premium(string name, int age, string mobile, string email,
        string password, string regdate, int id) : base(name, age, mobile,
        email, password)
        {
            RegDate = regdate;
            PayID = id;
        }
        /// <summary>
        /// validate the date format using 'TryParseExact' method
        /// source: https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact?view=net-10.0
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsValidDate(string date)
        {
            return DateTime.TryParseExact(date, "dd/MM/yyyy", null,
            System.Globalization.DateTimeStyles.None, out _);
        }
    }
}