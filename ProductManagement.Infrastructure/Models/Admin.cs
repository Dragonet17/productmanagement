namespace ProductManagement.Infrastructure.Models
{
    public class Admin
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public static Admin GetDefaultAdmin()
        {
            return new Admin()
            {
                Email = "admin@admin.pl",
                Password = "AdminPassword123!"
            };

        }
    }
}
