namespace Ubiquitous.Data.Model.DTO.UserDto
{
    /// <summary>
    /// Data Transfer Object for user entity.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the email is confirmed.
        /// </summary>
        public bool EmailConfirmed { get; set; }
    }
}
