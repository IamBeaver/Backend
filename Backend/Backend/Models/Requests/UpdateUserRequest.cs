namespace Backend.Models.Requests
{
    public class UpdateUserRequest : BaseUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
