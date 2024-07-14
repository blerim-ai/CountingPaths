using CountingPathsApi.Models;
using MediatR;

namespace CountingPathsApi.Queries
{
    public class GetPathsQueryRequest: IRequest<PathResponse>
    {
        public CoordinateRequest CoordinateRequest { get; set; }

        public GetPathsQueryRequest(CoordinateRequest coordinateRequest)
        {
            CoordinateRequest = coordinateRequest;
        }
    }
}
