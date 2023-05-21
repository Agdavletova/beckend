using Agdavletova_beckend.Models;

 namespace Agdavletova_beckend.Models
{
    public class Playlist
    {
        public int id { get; set; }
        public IList<Executor>? executor { get; set; }
        public IList<Song>? song { get; set; }

        public Playlist()
        {
            song = new List<Song>();
            executor = new List<Executor>();
        }

        public Playlist(IList<Executor>? executor, IList<Song>? Song)
        {
            this.id = id;
            this.executor = executor;
            Song = song;
        }
    }
}