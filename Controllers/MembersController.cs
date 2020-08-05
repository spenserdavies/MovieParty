using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movieparty.Models;
using movieparty.Services;

namespace movieparty.Controllers
{
      [ApiController]
      [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        
        private readonly MembersService _ms;
        public MembersController(MembersService ms)
        {
            _ms = ms;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAll()
        {
            try
            {
                return Ok(_ms.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetById(int id)
        {
            try
            {
              return Ok(_ms.GetById(id));  
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    [HttpPost]
    public ActionResult<Member> Post([FromBody] Member newMember)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newMember.UserId = userId;
        return Ok(_ms.Create(newMember));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Member> Edit(int id, [FromBody] Member memberToUpdate)
    {
         try
        {
            memberToUpdate.Id = id;
            string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Ok(_ms.Edit(memberToUpdate, userId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ms.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    }
}