using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movieparty.Models;
using movieparty.Services;

namespace movieparty.Controllers


{

[Route("api/[controller]")]
[ApiController]
    public class GroupMembersController : ControllerBase
    {
        private readonly GroupMembersService _gms; 
        public GroupMembersController (GroupMembersService gms)
        {
            _gms = gms;
        }

        [HttpGet]

        public ActionResult<IEnumerable<GroupMemberViewModel>> Get()
        {
           try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_gms.GetAll());
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    [HttpGet("{id}")]
    public ActionResult<DTOGroupMember> GetById(int id)
    {
       try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_gms.GetById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<DTOGroupMember> Post([FromBody] DTOGroupMember newDTOGroupMember)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_gms.Create(newDTOGroupMember));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<GroupMemberViewModel> Delete(int id)
    {
     try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_gms.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    }
}