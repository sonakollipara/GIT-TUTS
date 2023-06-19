using ApiMusicMay.Data;
using ApiMusicMay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMusicMay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.songclass.ToListAsync());           
            
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song =await _dbContext.songclass.FindAsync(id);
            return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] SongClass song)
        {
            await _dbContext.songclass.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        
        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, [FromForm] SongClass songobj)
        {
            var song =await _dbContext.songclass.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found");
            }
            else
            {
                song.Title = songobj.Title;
                song.Language = songobj.Language;
                await _dbContext.SaveChangesAsync();
                return Ok("Record updated successfully");
            }
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song =await _dbContext.songclass.FindAsync(id);
            if (song == null)
            {
                return NotFound("No record found");
            }
            else
            {
                _dbContext.songclass.Remove(song);
                await _dbContext.SaveChangesAsync();
                return Ok("Record deleted successfully");
            }
        }
    }
}
