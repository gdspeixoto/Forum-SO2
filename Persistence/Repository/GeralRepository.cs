﻿using Persistence.Context;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GeralRepository : IGeralRepository
    {
        private readonly DataContext _context;

        public GeralRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public void DeleteRange<T>(T[] EntityArray) where T : class
        {
            _context.RemoveRange(EntityArray);
        }

        public async Task<bool> SaveChangesAsyncs()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
