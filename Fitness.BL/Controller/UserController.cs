using Fitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// App user
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Create new user controller
        /// </summary>
        /// <param name="userName"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User)
                {
                    User = User;
                }

                //TODO: What to do if user is not found
            }
        }

        /// <summary>
        /// Save user data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        /// <summary>
        /// Load user data
        /// </summary>
        /// <returns>User</returns>  
    }
}
