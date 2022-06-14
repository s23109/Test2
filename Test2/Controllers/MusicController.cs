using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Services;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private IMusicService _musicservice;

        public MusicController(IMusicService musicservice)
        {
            _musicservice = musicservice;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum (int idAlbum)
        {
            try
            {
                return Ok(await _musicservice.GetAlbum(idAlbum));
            }
             catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusician(int IdMusician)
        {
            try
            {
                await _musicservice.DeleteMusician(IdMusician);
                return NoContent();
            }
            catch (Exception e)
            {
                if (e.Message.Equals("Nie istnieje"))
                {
                    return NotFound();
                }

                if (e.Message.Equals("Nie można usunąć muzyka , już ma album"))
                {
                    return Forbid();
                }

                //"Błąd przy usuwaniu rekordów"
                return Problem();
            }
        }


    }
}
