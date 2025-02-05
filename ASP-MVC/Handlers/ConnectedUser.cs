namespace ASP_MVC.Handlers
{
    public class ConnectedUser
    {
        public Guid User_Id { get; set; }
        public string Email { get; set; }
        public DateTime ConnectedAt { get; set; }
        public string Role { get; set; }
    }
}
