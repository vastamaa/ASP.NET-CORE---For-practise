using Company.Models;
using Company.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoworkerController : ControllerBase
    {
        private readonly ICoworkerService _coworkerService;

        public CoworkerController(ICoworkerService coworkerService) => _coworkerService = coworkerService;

        [HttpGet("{email}")]
        public Coworker GetWorkerByEmail(string email) => _coworkerService.GetWorkerByEmail(email);

        [HttpGet("")]
        public int GetCoworkerNumber() => _coworkerService.GetCoworkerNumber();

        [HttpPost("")]
        public string AddPhoneToCoworker(PhoneDto phone)
        {
            var result = _coworkerService.AddPhoneToCoworker(phone);

            if (result > 0)
                return "A felvétel sikeres volt!";

            else return "A felvétel sikertelen volt!";
        }

        [HttpPost("change")]
        public string UpdatePhoneToCoworker(PhoneDto phone)
        {
            var result = _coworkerService.AddPhoneToCoworker(phone);

            if (result > 0)
                return "A felvétel sikeres volt!";

            else return "A felvétel sikertelen volt!";
        }
    }
}
