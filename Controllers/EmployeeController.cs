namespace IBASEmployeeService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using IBASEmployeeService.Models;
    
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            var employees = new List<Employee>() {
            new Employee() {
                Id = "21",
                Name = "Mette Bangsbo",
                Email = "meba@ibas.dk",
                FavoriteArtist = "Human Error",
                Department = new Department() {
                    Id = 1,
                    Name = "Salg"
                }
            },
            new Employee() {
                Id = "22",
                Name = "Hans Merkel",
                Email = "hame@ibas.dk",
                FavoriteArtist = "AC/DC",
                Department = new Department() {
                    Id = 2,
                    Name = "Support"
                }
            },
            new Employee() {
                Id = "23",
                Name = "Karsten Mikkelsen",
                Email = "kami@ibas.dk",
                FavoriteArtist = "AC/DC",
                Department = new Department() {
                    Id = 2,
                    Name = "Support"
                }
            },
            new Employee()
            {
                Id = "24",
                Name = "Angus Young",
                Email = "angus@acdc.com",
                FavoriteArtist = "Human Error",
                Department = new Department()
                {
                    Id = 3,
                    Name = "It"
                }
            },
            new Employee()
            {
                Id = "27",
                Name = "Brian Johnson",
                Email = "brian@acdc.com",
                FavoriteArtist = "Human Error",
                Department = new Department()
                {
                    Id = 3,
                    Name = "It"
                }
            },
            new Employee()
            {
                Id = "25",
                Name = "Cliff Williams",
                Email = "cliff@acdc.com",
                FavoriteArtist = "Human Error",
                Department = new Department()
                {
                    Id = 3,
                    Name = "It"
                }
            },
            new Employee()
            {
                Id = "21",
                Name = "Diesel Viberstrike",
                Email = "diesel@humanerror.com",
                FavoriteArtist = "AC/DC",
                Department = new Department()
                {
                    Id = 4,
                    Name = "Kantine"
                }
            },
            new Employee()
            {
                Id = "24",
                Name = "AC/DC",
                Email = "stone@humanerror.com",
                FavoriteArtist = "Human Error",
                Department = new Department()
                {
                    Id = 4,
                    Name = "Kantine"
                }
            }
        };
            return employees;
        }

        
        //Ved at give afdellingens Id som er instaniseret ovenfor ved new Department() med i Route på API kaldet, bruger vi nedenfor LinQ til at fremkalde det.
        [HttpGet("GetEmployees/Department/{id}")]
        public ActionResult<IEnumerable<Employee>> GetId(int id)
        {
            var ansatte = Get()
                .Where(e => e.Department.Id == id)
                .ToList();
            if (ansatte.Count == 0)
            {
                return BadRequest("Der er ingen ansatte i afdellingen");
            }
            else
            {
                return Ok(ansatte);
            }
        }
    }

}