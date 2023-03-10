
using Sample.Repositories;
using Sample.Repositories.DTO;
using Sample.Services;
using Sample.Services.Interfaces;
using Sample.Utilities.Enums;
using SampleWebApi.Filters;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _service;
        public EmployeeController() => _service = new EmployeeService(new EmployeeRepository(new SampleDbContext()));

        [HttpGet]
        [AuthenticationFilter]
        public async Task<HttpResponseMessage> Get(string firstname, string lastname, Gender? gender)
        {
            var result = await _service.GetAll(firstname??string.Empty,lastname ?? string.Empty, gender);
            if(result.Count == 0)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }


        [HttpPost]
        [AuthenticationFilter]
        public async Task<HttpResponseMessage> Save(UpdateEmployeeDTO dto)
        {
            if(dto.FirstName == null || dto.LastName == null || dto.gender == 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please enter all required fields");
            var result = await _service.Save(dto);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }

    
}