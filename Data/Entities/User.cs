namespace EmployeeManagement.API.Data.Entities
{
    public class User  // Table Structure
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public bool isFullTime { get; set; }
        public double Salary { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
    }
}