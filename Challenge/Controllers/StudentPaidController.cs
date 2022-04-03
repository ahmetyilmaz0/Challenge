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
    public class StudentPaidController : ControllerBase
    {
        private readonly ILogger<StudentPaidController> _logger;
        private readonly ChallengeDBContext _challengedbContext;
        private IStudentService _studentService;
        private IStudentPaidService _studentPaidService;
        public StudentPaidController(ILogger<StudentPaidController> logger,
            IStudentService studentService,
            ChallengeDBContext challengedbContext,
            IStudentPaidService studentPaidService)
        {
            _logger = logger;
            _studentService = studentService;
            _studentPaidService = studentPaidService;
            _challengedbContext = challengedbContext;
        }
        // GET: api/<StudentPaidController>
        [HttpGet]
        public IEnumerable<StudentPaidViewModel> Get()
        {
            return _studentPaidService.List();
        }

        // GET api/<StudentPaidController>/5
        [HttpGet("{id}")]
        public StudentPaidViewModel Get(Guid id)
        {
            return _studentPaidService.List().FirstOrDefault(x => x.studentPaidID == id);
        }

        // GET api/<StudentPaidController>/GetbyStudentID/5
        [HttpGet("GetByStudentID/{studentid}")]
        public IEnumerable<StudentPaidViewModel> GetbyStudentID(Guid studentid)
        {
            return _studentPaidService.GetbyStudentID(studentid);
        }

        // GET api/<StudentPaidController>/GetByDate/5
        [HttpGet("GetByDate/{startDate,endDate}")]
        public IEnumerable<StudentPaidViewModel> GetByStudentIDDate(Guid studentid, DateTime startDate, DateTime endDate)
        {
            return _studentPaidService.GetByStudentIDDate(studentid,  startDate,  endDate);
        }

        // POST api/<StudentPaidController>
        [HttpPost]
        public bool Post([FromBody] StudentPaidViewModel value)
        {
            return _studentPaidService.Add(value);
        }

        // PUT api/<StudentPaidController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] StudentPaidViewModel value)
        {
            value.studentPaidID = id;
            return _studentPaidService.Update(value);
        }

        // DELETE api/<StudentPaidController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _studentPaidService.Delete(_studentPaidService.List().FirstOrDefault(x => x.studentPaidID == id));
        }
    }
}
