using Geometry.Model;

namespace Geometry.Extensions
{
    public static class FormExtension
    {
        //extension de class
        public static IEnumerable<Point> Where(this Polygon polygon, Func<Point, bool> predicate)
        {
            return polygon.Summits.Where(predicate);
        }
    }
}
