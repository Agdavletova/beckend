
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Agdavletova_beckend.Models
{
    public class Executor
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }

        


        public Executor(int Id, string Name, int Age)
        {
            this.Id = Id;

            this.Name = Name;
            this.Age = Age;
        }

        internal void AddExecutor(Executor? executor)
        {
            throw new NotImplementedException();
        }
    }
}