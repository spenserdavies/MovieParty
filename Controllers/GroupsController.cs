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
        private readonly GroupMovieService _gmov;
        private readonly GroupMemberService _gmem;
        public GroupsController(GroupsService gs, GroupMovieService gmov, GroupMemberService gmem)
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
        public ActionResult <IEnumerable<GroupMovieViewModel>> GetMoviesByGroupId(int id)
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
        public ActionResult <IEnumerable<GroupMemberViewModel>> GetMembersByGroupId(int id)
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
    }
}