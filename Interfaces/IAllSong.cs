using static System.Reflection.Metadata.BlobBuilder;


using Agdavletova_beckend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agdavletova_beckend.Interfaces
{
    public interface IAllSong
    {
        IEnumerable<Song> Song { get; }
        Song getObjectBook(int BookId);
    }
}