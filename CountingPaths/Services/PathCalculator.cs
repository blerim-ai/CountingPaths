using CountingPathsApi.Interfaces;
using System.Text;

namespace CountingPathsApi.Services
{
    public class PathCalculator : IPathCalculator
    {

        public List<string> GetAllPaths(int X, int Y)
        {
            List<string> validPaths = new List<string>();
            CountPaths(0, 0, X, Y, "", validPaths);
            return validPaths;
        }

        private void CountPaths(int x, int y, int targetX, int targetY, string path, List<string> validPaths)
        {
            if (path.EndsWith("EEEN") || path.EndsWith("NNNE"))
            {
                return;
            }

            if (x == targetX && y == targetY)
            {
                validPaths.Add(path);
                return;
            }

            if (x < targetX)
            {
                CountPaths(x + 1, y, targetX, targetY, path + "E", validPaths);
            }

            if (y < targetY)
            {
                CountPaths(x, y + 1, targetX, targetY, path + "N", validPaths);
            }
        }
    }
}
