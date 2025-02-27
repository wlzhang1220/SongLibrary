using SongLibrary.Models;

namespace SongLibrary.Services
{
    public static class SongService
    {
        private static int idCounter = 1;
        private static Dictionary<int, Song> songList = new Dictionary<int, Song>();

        static SongService()
        {
            songList[idCounter] = new Song()
            {
                Id = 1,
                Title = "This Is My Song",
                Artist = "NotMe",
                Year = 2025,
            };

            idCounter++;
        }

        public static List<Song> GetSongs()
        {
            return songList.Values.ToList();
        }

        public static Song? GetSong(int id)
        {
            return songList.ContainsKey(id) ? songList[id] : null;
        }

        public static Song CreateSong(Song song)
        {
            song.Id = idCounter;
            songList[idCounter] = song;

            idCounter++;
            return song;
        }

        public static bool DeleteSong(int songId)
        {
            return songList.Remove(songId);
        }

        public static bool UpdateSong(Song song)
        {
            if(song == null || !songList.ContainsKey(song.Id))
            {
                return false;
            }

            songList[song.Id] = song;

            return true;
        }
    }
}
