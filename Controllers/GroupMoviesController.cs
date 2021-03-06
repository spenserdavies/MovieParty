using System;
using System.Collections.Generic;
using System.Security.Claims;
using movieparty.Models;
using movieparty.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace movieparty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GroupMoviesController : ControllerBase
    {
        private readonly GroupMoviesService _gms;
        public GroupMoviesController(GroupMoviesService gms)
        {
            _gms = gms;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GroupMovieViewModel>> Get()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_gms.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<DTOGroupMovie> GetById(int id)
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
        //POST
        [HttpPost]
        public ActionResult<DTOGroupMovie> Post([FromBody] DTOGroupMovie newDTOGroupMovie)
        {
            try
            {
                newDTOGroupMovie.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_gms.Create(newDTOGroupMovie));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //EDIT
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<DTOGroupMovie> Edit(int id, [FromBody] DTOGroupMovie editDTOGroupMovie)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                editDTOGroupMovie.Id = id;
                return Ok(_gms.Edit(editDTOGroupMovie));
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
                return Ok(_gms.Delete(user, Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}