using CountingPathsApi.Interfaces;
using CountingPathsApi.Models;
using CountingPathsApi.Queries;
using MediatR;

namespace CountingPathsApi.Handlers
{
    public class GetPathsHandler : IRequestHandler<GetPathsQueryRequest, PathResponse>
    {
        private readonly IPathCalculator _pathCalculator;

        public GetPathsHandler(IPathCalculator pathCalculator)
        {
            _pathCalculator = pathCalculator;
        }

        public Task<PathResponse> Handle(GetPathsQueryRequest request, CancellationToken cancellationToken)
        {
            var paths = _pathCalculator.GetAllPaths(request.CoordinateRequest.X, request.CoordinateRequest.Y);
            var response = new PathResponse
            {
                NumberOfPaths = paths.Count,
                Paths = paths
            };

            return Task.FromResult(response);
        }
    }
}
