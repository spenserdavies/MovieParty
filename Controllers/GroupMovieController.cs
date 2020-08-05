using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using movieparty.Models;
using movieparty.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using movieparty.Models;


namespace movieparty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupMovieController : ControllerBase
    {
        private readonly GroupMovieService _gms;
        public GroupMovieController(GroupMovieService gms)
        {
            _gms = gms;
        }
        [HttpGet]
        public ActionResult<IEnumerable<GroupMovieViewModel>> Get()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_gms.Get(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //POST
        [HttpPost]
        public ActionResult<DTOGroupMovie> Post([FromBody] DTOGroupMovie newDTOGroupMovie)
        {
            try
            {
                newDTOGroupMovie.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Create(newDTOGroupMovie));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //EDIT
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<MovieGroup> Edit(int id, [FromBody] MovieGroup editGroupMovie)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                editMovieGroup.Id = id;
                return Ok(_ks.Edit(editGroupMovie, movieId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //DELETEBYID
        [HttpDelete("{id}")]
        public ActionResult<DTOGroupMovie> Delete(int Id)
        {
            try
            {
                string user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Delete(user, Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}