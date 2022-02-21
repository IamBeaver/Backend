namespace Backend.Models.Requests
{
    public class UpdateUserRequest<T>
    {
        public T Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
