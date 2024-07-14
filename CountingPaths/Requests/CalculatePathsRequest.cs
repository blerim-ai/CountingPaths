using CountingPathsApi.Models;
using MediatR;

namespace CountingPathsApi.Queries
{
    public class CalculatePathsRequest : IRequest<CalculatePathsResponse>
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
