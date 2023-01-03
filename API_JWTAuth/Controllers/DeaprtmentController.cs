using BAL.Interface;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_JWTAuth.Controllers
{
    [Authorize]
    [ApiController]
    [Route ("api/department")]
    public class DeaprtmentController : Controller
    {
        private readonly IDataRepository<Department> _idatarepo;
        public DeaprtmentController(IDataRepository<Department> idatarepo)
        {
            _idatarepo = idatarepo;

        }

        [HttpGet]
        public IActionResult Getdepartment()
        {
            _idatarepo.GetAllDepartment();
            return Ok();
           
            
        }
    }
}
