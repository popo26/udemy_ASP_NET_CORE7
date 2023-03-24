namespace ControllersExample.Models
{
    public class Person
    {
        public Guid Id { get; set; } //Guid will be generated automatically with timestamp and universally unique
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
