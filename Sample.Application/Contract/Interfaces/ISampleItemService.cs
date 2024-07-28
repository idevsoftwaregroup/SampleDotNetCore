using Sample.Application.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Contract.Interfaces
{
    public interface ISampleItemService
    {
        Task<List<SampleItemApplicationDTO>> GetSampleItems(CancellationToken cancelationToken = default);
    }
}
