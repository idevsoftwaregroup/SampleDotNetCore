using Sample.Application.Contract.DTOs;
using Sample.Application.Contract.Interfaces;
using Sample.Infrastructure.Contract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services
{
    public class SampleService : ISampleItemService
    {
        private readonly ISampleRepository _repo;

        public SampleService(ISampleRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<SampleItemApplicationDTO>> GetSampleItems(CancellationToken cancellationToken = default)
        {
            return (await _repo.GetSampleItems(cancellationToken)).Select(p => new SampleItemApplicationDTO
            {
                Id = p.Id,
                SampleTitlte = p.SampleTitle,
            }).ToList();
        }
    }
}
