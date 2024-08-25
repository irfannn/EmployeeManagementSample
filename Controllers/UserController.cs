using EmployeeManagement.API.Data;
using EmployeeManagement.API.Data.Entities;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private AppDBContext _userDataManagementDBContext;

        public UsersController(AppDBContext userManagementDBContext)
        {
            _userDataManagementDBContext = userManagementDBContext;
        }


        [HttpGet] // 1
        [Route("/getallusers")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _userDataManagementDBContext.Users.ToListAsync();
            return Ok(employees); // Send "Response"
        }


        [HttpPost] // 2
        [Route("/adduser")] 
        public async Task<IActionResult> AddUser([FromBody] UserDto userRequest) 
        {
            // TODO: Later
            //if(!IsDataValid())
            //{
            // return BadRequest(ErrorMessage);
            //}

            userRequest.Id = Guid.NewGuid();
            var user = new User() // This is a DB Table Object Entity.
            {
                Id = userRequest.Id,
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                DateOfBirth = userRequest.DateOfBirth,
                Address = userRequest.Address,
                Gender = userRequest.Gender,
                Nationality = userRequest.Nationality,
                isFullTime = userRequest.isFullTime,
                PhoneNumber = userRequest.PhoneNumber,
                Salary = userRequest.Salary
            };

            await _userDataManagementDBContext.Users.AddAsync(user);
            await _userDataManagementDBContext.SaveChangesAsync();
            return Ok("User created"); // This is a Response.
        }


        [HttpGet]
        [Route("/getuserbyId/{id:Guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await _userDataManagementDBContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPut]
        [Route("/edituser/{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, UserDto updateUserRequest)
        {
            // TODO: Later
            //if(!IsDataValid())
            //{
            // return BadRequest(ErrorMessage);
            //}

            var user = await _userDataManagementDBContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updateUserRequest.FirstName;
            user.LastName = updateUserRequest.LastName;
            user.Email = updateUserRequest.Email;
            user.DateOfBirth = updateUserRequest.DateOfBirth;
            user.Address = updateUserRequest.Address;
            user.Gender = updateUserRequest.Gender;
            user.Nationality = updateUserRequest.Nationality;
            user.isFullTime = updateUserRequest.isFullTime;
            user.PhoneNumber = updateUserRequest.PhoneNumber;
            user.Salary = updateUserRequest.Salary;

            await _userDataManagementDBContext.SaveChangesAsync();

            return Ok("User Details Updated sucessfully");
        }


        [HttpDelete]
        [Route("/deleteuser/{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var user = await _userDataManagementDBContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _userDataManagementDBContext.Users.Remove(user);
            await _userDataManagementDBContext.SaveChangesAsync();
            return Ok(user);
        }
    }
}

// let AppDB = new AppDBContext();
// let userController = new UsersController(AppDB)
// host: http://localhost:7070/ // A: hostname + "api/users"
// Receive "Request: HttpMethod, Headers, Body" "Response: StatusCode, Headers, Body"
// This is a Request from FE.
//class EmailDetailsRequest
//{
//    public string Subject { get; set; }
//}

//[HttpPost]
//[Route("/sendEmailToClient")] // 50 tables --> 50 Controllers -- each controller has one or more endpoints 
//public async Task<IActionResult> InvokeEmailClient([FromBody] EmailDetailsRequest IReceiveEmailDetailsFromFE)
//{
// possibilities: this endpoint or API
// Can communicate with other APIs or DB or AWS Service (Simple Email Service SES) or OAuth or Okta service or bla bla
// TODO: Check incoming data is valid or no?

//    // Step1: Create a HttpRequest Object
//    // Step2: fill the incoming data in to the HttpRequest Object
//    // Step3. send the Object to the Other Email API Endpoint.
//    // Step4: wait for the Response from the Other Email API (Navi) Request --> Reponse StatusCode:200, 500
//    // Step5: return the response to the Browser

//    return Ok("Email sent to Client"); // Goes back to user who send this request.
//}

// API Main Parent
// API generate for Update Employee Method()
//     List of Controllers (features: Users, Surveys)
// UserController --> Endpoints(specific URL)
// CreateUser(createUser ThisrequestHasFEValues) "http://betterworks.com/api/v1/users/createuser"
// 50 tables --> 50 Controllers -- each controller has one or more endpoints
// EditUser() { LogicWhatTODO }                  "http://betterworks.com/api/v1/users/edituser"

// GetUserById()
// GetAllUsers()
// DeleteUser()

// SurveysController
// CreateSurvery()
// EditSurvery()
// GetAllSurvery()
// B:"/getallusers" ;; HostName + A + B = "http://localhost:7035/api/v2/users/getallusers" ; // WOrking: http://localhost:5035/getallusers
/*
 *  Web API Interview Questions:
 *  1. what are the key components of API
 *  2. Whats is the diff betwéen HttpMethod & HttpStatus
 *  3. Whats is the diff betwéen Request & Response
 *  4. Whats is the diff betwéen HttpPUT & HttpPatch
 *  5. What is the diff betwéen Query Parameter.

 *  Build FE for User Feature using In-Memory Array List
    Modify the FE for User Feature to communicate with BE for CRUD Operations.

    BE:
        1. Build the User feature Endpoints.
        2. Share it it Github.
        3. Navu will Clone the BE.
        4. Install .net6 in Macos. OR Run Docker Image

 */