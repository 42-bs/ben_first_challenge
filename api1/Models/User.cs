namespace Api1.Models
{
#nullable disable

    /// <summary>
    /// .
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets .
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        public string Password { get; set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
