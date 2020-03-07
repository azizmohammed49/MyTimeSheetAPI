using Microsoft.AspNetCore.Mvc;
using System;
using TimeSheetDAL.BO;
using TimeSheetDAL.DO;

namespace Timesheets.API.Controllers
{
    [Route("api/v1/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDb employeeDb;
        public EmployeeController(IEmployeeDb employeeDb)
        {
            this.employeeDb = employeeDb;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employeeDb.GetEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeesById(int id)
        {
            var emp = employeeDb.GetEmployeeByEmpId(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            employeeDb.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(Employee E)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employeeDb.Insert(E);
                    //return Created("http://localhost:50664/api/Employees/" + E.EmpId, E);

                    return CreatedAtAction("GetEmployees", new { id = E.EmpId }, E);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception)
            {
                //E.Message
                return StatusCode(500, "We are working on it!");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Employee E)
        {
            if (employeeDb.GetEmployeeByEmpId(id) != null)
            {
                employeeDb.Update(E);
                return NoContent();
            }
            return BadRequest();
        }

    }
}
