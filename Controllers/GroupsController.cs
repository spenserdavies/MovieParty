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
    public class GroupsController : ControllerBase
    {
        private readonly GroupsService _gs;
        private readonly GroupMoviesService _gmov;
        private readonly GroupMembersService _gmem;
        public GroupsController(GroupsService gs, GroupMoviesService gmov, GroupMembersService gmem)
        {
            _gs = gs;
            _gmov = gmov;
            _gmem = gmem;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Group>> Get()
        {
            try
            {
                return Ok(_gs.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Group> GetById(int id)
        {
            try
            {
                return Ok(_gs.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/movies")]
        [Authorize]
        public ActionResult<IEnumerable<GroupMovieViewModel>> GetMoviesByGroupId(int id)
        {
            try
            {
                return Ok(_gmov.GetMoviesByGroupId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/members")]
        [Authorize]
        public ActionResult<IEnumerable<GroupMemberViewModel>> GetMembersByGroupId(int id)
        {
            try
            {
                return Ok(_gmem.GetMembersByGroupId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Group> Post([FromBody] Group newGroup)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newGroup.UserId = userId;
                return Ok(_gs.Create(newGroup));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Group> Edit(int id, [FromBody] Group groupToUpdate)
        {
            try
            {
                groupToUpdate.Id = id;
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_gs.Edit(groupToUpdate, userId));
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
                return Ok(_gs.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}