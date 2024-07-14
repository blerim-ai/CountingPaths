using CountingPathsApi.Interfaces;
using CountingPathsApi.Models;
using CountingPathsApi.Queries;
using MediatR;

namespace CountingPathsApi.Handlers
{
    public class GetPathsHandler : IRequestHandler<CalculatePathsRequest, CalculatePathsResponse>
    {
        private readonly IPathCalculator _pathCalculator;

        public GetPathsHandler(IPathCalculator pathCalculator)
        {
            _pathCalculator = pathCalculator;
        }

        public Task<CalculatePathsResponse> Handle(CalculatePathsRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                return Task.FromResult<CalculatePathsResponse>(null);
            }

            var paths = _pathCalculator.CalculatePaths(request.X, request.Y);

            if (paths is null)
            {
                return Task.FromResult<CalculatePathsResponse>(null);
            }

            var response = new CalculatePathsResponse
            {
                NumberOfPaths = paths.Count,
                Paths = paths
            };

            return Task.FromResult(response);
        }
    }
}
