using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApplication.Controllers
{
    [Route("api/[Controller]")]
    public class AdminController : ControllerBase
    {
        [Authorize(Policy = "RequiredAdminRole")]
        [HttpGet("usersWithRoles")]
        public IActionResult GetUserWithRoles()
        {
            return Ok("Only admins can see this");
        }

        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photosForModeration")]
        public IActionResult GetPhotoForRoles()
        {
            return Ok(" admins or Moderator can see this");
        }
    }
}