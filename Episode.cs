namespace PodCastWorld
{
    /// <summary>
    /// build class Episode for episodes information
    /// </summary>
    public class Episode
    {
        /// <summary>
        /// build all properties for episodes
        /// </summary>
        public string Name{ get; private set; }
        public string Description{ get; private set; }
        public string RecordedDate{ get; private set; }
        public int Length{get; private set; }
        public bool PremiumOnly{ get; private set; }

        /// <summary>
        /// create a constructor for episodes with initialise
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        /// <param name="length"></param>
        /// <param name="premiumOnly"></param>
        public Episode(string name, string description, 
        string date, int length, bool premiumOnly)
        {
            Name = name;
            Description = description;
            RecordedDate = date;
            Length = length;
            PremiumOnly = premiumOnly;
        }
    }
}