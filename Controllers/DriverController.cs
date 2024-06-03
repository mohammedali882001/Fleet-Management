using AnasProject.DTOS;
using AnasProject.Repos.DriverRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;

namespace AnasProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepo driverRepo;

        public DriverController(IDriverRepo driverRepo)
        {
            this.driverRepo = driverRepo;
        }

        
        [HttpPost("add")]
        public  IActionResult AddDriver([FromBody] DriverDTO driverDTO)
        {
            if (ModelState.IsValid)
            {
                Driver driver= new Driver() { 
                   
                        DriverName = driverDTO.DriverName,  
                        PhoneNumber = driverDTO.PhoneNumber,
                };
                // Add the driver to the database
                driverRepo.Insert(driver);
                driverRepo.Save();

                // Create a GVAR object and populate the DicOfDic with driver data
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverID"] = driver.DriverId.ToString(),
                    ["DriverName"] = driver.DriverName,
                    ["PhoneNumber"] = driver.PhoneNumber.ToString()
                };

                // Wrap the GVAR object into a response structure
                var response = new
                {
                    gvar = gvar
                };

                // Return the wrapped response
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");
            
        }


        [HttpPut("Update")]
        public IActionResult UpdateDrivers(int driverId,DriverDTO driverDTO)
        {
            if (ModelState.IsValid)
            {

                Driver driver = driverRepo.GetById(driverId);
             
                driver.DriverName = driverDTO.DriverName;
                driver.PhoneNumber = driverDTO.PhoneNumber;
                    
                    //DriverName = driverDTO.DriverName
                    //PhoneNumber = driverDTO.PhoneNumber
                
                driverRepo.Update(driver);
                driverRepo.Save();
                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverID"] = driver.DriverId.ToString(),
                    ["DriverName"] = driver.DriverName,
                    ["PhoneNumber"] = driver.PhoneNumber.ToString()
                };
                var response = new
                {
                    gvar = gvar
                };

                // Return the wrapped response
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteDriver(long driverId)
        {
            if (ModelState.IsValid)
            {
                Driver driver = driverRepo.GetById(driverId);
                //driver.DriverName = driverDTO.DriverName;
                //driver.PhoneNumber = driverDTO.PhoneNumber;

                driver.IsDeleted=true;
                driverRepo.Update(driver);
                driverRepo.Save();

                var gvar = new GVAR();
                gvar.DicOfDic["Tags"] = new ConcurrentDictionary<string, string>
                {
                    ["DriverID"] = driver.DriverId.ToString(),
                    ["DriverName"] = driver.DriverName,
                    ["PhoneNumber"] = driver.PhoneNumber.ToString()
                };
                var response = new
                {
                    gvar = gvar
                };

                // Return the wrapped response
                return Ok(response);
            }

            return BadRequest("Invalid Data For Adding This Driver");
        
        }
        


        // GET: api/drivers/all
        [HttpGet("all")]
        public IActionResult GetAllDrivers()
        {
            var drivers = driverRepo.GetAll();
            var dataTable = new DataTable("Drivers");
            dataTable.Columns.Add("DriverID", typeof(long));
            dataTable.Columns.Add("DriverName", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(long));

            foreach (var driver in drivers)
            {
                dataTable.Rows.Add(driver.DriverId, driver.DriverName, driver.PhoneNumber);
            }

            var gvar = new GVAR();
            gvar.AddDataTable("Drivers", dataTable);

            // Wrap the GVAR object into a response structure
            var response = new
            {
                gvar = gvar
            };

            return Ok(response);
        }


        

    }
}
