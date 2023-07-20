using Microsoft.AspNetCore.Identity;

namespace ChatBotBackend.Data
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

    }
}
