using System;

namespace Fitness.BL.Model
{
    public class Gender
    {
        /// <summary>
        /// Naming of gender
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create new gender
        /// </summary>
        /// <param name="name"></param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender can not be null or empty.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
