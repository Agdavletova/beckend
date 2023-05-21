
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

 namespace Agdavletova_beckend.Models
{
    public class Song
    {
        public int ID { get; set; } //свйства класса
        public string Title { get; set; }

        public string executor { get; set; }

        public int Year { get; set; }


        public Song(int ID, string Title, string executor, int Year)
        {
            this.ID = ID; //данные берутся из этого класса
            this.Title = Title;
            this.executor = executor;
            this.Year = Year;
        }
    }



}
