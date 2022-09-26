using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scheduling.Data;
using scheduling.Enums;
using scheduling.Models;

namespace scheduling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public ShiftController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Post([FromForm] ShiftDto shift)
        {
            Shift shiftEntry=new Shift();
            {
                shiftEntry.EmployeeId = shift.EmployeeId;
                shiftEntry.TimeIn= shift.TimeIn;
                shiftEntry.TimeOut= shift.TimeOut;
                shiftEntry.Type = shift.Type;
                shiftEntry.Date = DateTime.Now.ToString();
            }
            _appDbContext.Shifts.Add(shiftEntry);
            _appDbContext.SaveChanges();

            return Ok("Inserted");
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {   
            var shifts=await _appDbContext.Shifts.ToListAsync();

            var result = shifts.GroupBy(x => new { x.EmployeeId })
                  .Select(x => new
                  {
                      Key = x.Key,                      
                      shifts = x.Select(x => new { x.EmployeeId, x.TimeIn, x.TimeOut,x.Type, x.Date }),
                  });;

            return Ok(result);            
        }
    }
}
