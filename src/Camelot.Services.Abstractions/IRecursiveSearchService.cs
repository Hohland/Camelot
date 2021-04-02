using System.Threading;
using Camelot.Services.Abstractions.Models;
using Camelot.Services.Abstractions.Specifications;

namespace Camelot.Services.Abstractions
{
    public interface IRecursiveSearchService
    {
        IRecursiveSearchResult Search(string directory, ISpecification<NodeModelBase> specification,
            CancellationToken cancellationToken);
    }
}