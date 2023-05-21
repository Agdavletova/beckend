
using Agdavletova_beckend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Agdavletova_beckend.Interfaces
{
    public interface IAllExecutor
    {
        IEnumerable<Executor> AllExecutor { get; }
    }
}
