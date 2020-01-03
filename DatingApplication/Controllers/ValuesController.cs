using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApplication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
   // [AllowAnonymous]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        [Authorize(Roles ="Admin,Moderator")]
        [HttpGet]
        public async Task<IActionResult> Getvalues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [Authorize(Roles = "Member")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var value =await _context.Values.FirstOrDefaultAsync(x=>x.Id ==id);
            return Ok(value);
        }

       
    }
}