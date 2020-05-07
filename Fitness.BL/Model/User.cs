using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Properties
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public double Weight { get; set; }
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthDate">Date of birth.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>
        public User(string name,
            Gender gender,
            DateTime birthDate,
            double weight,
            double height)
        {
            #region Validation of params
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be null or empty", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender can not be null or empty.", nameof(gender));
            }

            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible to have such birth date.", nameof(birthDate));
            }

            if(weight <= 0)
            {
                throw new ArgumentException("Weight can not be less or equal to zero.", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("Height can not be less or equal to zero.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name; 
        }
    }
}
