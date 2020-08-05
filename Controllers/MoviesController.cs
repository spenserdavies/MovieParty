using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using movieparty.Models;
using MovieParty.Services;

namespace MovieParty.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesService _ms;
        public MoviesController(MoviesService ms)
        {
            _ms = ms;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            try
            {
                return Ok(_ms.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            try
            {
                return Ok(_ms.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("user")]
        public ActionResult<IEnumerable<Movie>> GetMoviesByUser()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_ms.GetByUserId(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }
        [HttpPut(" {id}")]
        public ActionResult<Movie> Edit(int id, [FromBody] Movie editMovie)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                editMovie.Id = id;
                return Ok(_ms.Edit(editMovie, userId));
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