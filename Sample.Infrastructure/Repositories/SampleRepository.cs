using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models;
using Sample.Infrastructure.Context;
using Sample.Infrastructure.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly SampleContext _context;
        public SampleRepository(SampleContext context)
        {
            _context = context;
        }

        public async Task<List<SampleItems>> GetSampleItems(CancellationToken cancelationToken = default)
        {
            try
            {
                return await _context.SampleItems.ToListAsync(cancellationToken: cancelationToken);
            } 
            catch(Exception)
            {
                return new List<SampleItems>();
            }
        }
    }
}
