namespace EmployeeManagement.API.Models
{
    public class UserDto // DTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public bool isFullTime { get; set; }
        public double Salary { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; } // data fromat: Json "{{"Id":"123","FirstName":"navi"}}" Json to  ---> Object UserViewModel
        public Guid Id { get; set; }
        public int Age { get; set; }
    }
}
