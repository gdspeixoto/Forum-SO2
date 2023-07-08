using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IGeralRepository
    {
        void Add<T>(T Entity) where T : class;
        void Update<T>(T Entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        void DeleteRange<T>(T[] Entity) where T : class;
        Task<bool> SaveChangesAsyncs();
    }
}
