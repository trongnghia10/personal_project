namespace project.BackendAPI.Models
{
    public class UserRequest
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
