using Microsoft.AspNetCore.Identity;

namespace Ubiquitous.Data.Models.Entity
{
    /// <summary>
    /// Represents an application user for authentication and authorization.
    /// Inherits from ASP.NET Core IdentityUser with integer key.
    /// </summary>
    public class Users : IdentityUser<int>
    {
        
    }
}