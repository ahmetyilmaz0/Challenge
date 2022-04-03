using Challenge.Services;
using Challenge.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ChallengeDBContext _challengedbContext;
        private IStudentService _studentService;
        private IStudentPaidService _studentPaidService;
        public StudentController(ILogger<StudentController> logger, 
            IStudentService studentService, 
            ChallengeDBContext challengedbContext,
            IStudentPaidService studentPaidService)
        {
            _logger = logger;
            _studentService = studentService;
            _studentPaidService = studentPaidService;
            _challengedbContext = challengedbContext;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<StudentViewModel> Get()
        {
            return _studentService.List();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public StudentViewModel Get(Guid id)
        {
            return _studentService.List().FirstOrDefault(x => x.studentID == id);
        }

        // GET api/<StudentController>/GetByStudentNumber/5
        [HttpGet("GetByStudentNumber/{studentNumber}")]
        public StudentViewModel GetByStudentNumber(int studentNumber)
        {
            return _studentService.List().FirstOrDefault(x => x.studentNumber == studentNumber);
        }

        // POST api/<StudentController>
        [HttpPost]
        public bool Post([FromBody] StudentViewModel value)
        {
            return _studentService.Add(value);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] StudentViewModel value)
        {
            value.studentID = id;
            return _studentService.Update(value);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
           return _studentService.Delete(id);
        }
    }
}
