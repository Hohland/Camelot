using System;
using System.Threading.Tasks;
using Camelot.Services.Abstractions.Models.EventArgs;

namespace Camelot.Services.Abstractions
{
    public interface IRecursiveSearchResult
    {
        Lazy<Task> Task { get; }

        event EventHandler<NodeFoundEventArgs> NodeFoundEvent;
    }
}