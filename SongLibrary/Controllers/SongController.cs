using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SongLibrary.Models;
using SongLibrary.Services;

namespace SongLibrary.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Song> GetSongs()
        {
            return SongService.GetSongs().ToArray();
        }

        [HttpGet("{id}")]
        public Song? GetSong(int id)
        {
            return SongService.GetSong(id);
        }

        [HttpPost]
        public bool CreateSong(Song song)
        {
            var newSong = SongService.CreateSong(song);
            return newSong.Id != 0;
        }

        [HttpDelete("{id}")]
        public bool DeleteSong(int id)
        {
            return SongService.DeleteSong(id);
        }

        [HttpPut]
        public bool UpdateSong(Song song)
        {
            return SongService.UpdateSong(song);
        }
    }
}
