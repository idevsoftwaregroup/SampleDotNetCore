using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Contract.Interfaces
{
    public interface ISampleRepository
    {
        Task<List<SampleItems>> GetSampleItems(CancellationToken cancelationToken = default);
    }
}
