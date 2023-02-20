namespace WebShopApp.Infrastructure
{
    internal class ApplicationUser
    {
        public ApplicationUser()
        {
        }

        public string PhoneNumber { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string UserName { get; internal set; }
        public string Email { get; internal set; }
    }
}