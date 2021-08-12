namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    public abstract class FarmAnimal : ISingable
    {
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public abstract string Name { get; }

        private string sound;
        /// <summary>
        /// The farm animal's sound.
        /// </summary>
        public string Sound
        {
            get
            {
                return sound;
            }
            set
            {
                sound = value;
            }
        }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        /// <param name="sound">The sound that the animal makes.</param>
        public FarmAnimal(string sound)
        {
            Sound = sound;
        }
    }
}
