using System.Collections.Generic;
using System.Linq;

namespace SettlersOfCatan.DOF
{
    public static class ResourcesExtensions
    {
        public static Resources Sum(this IEnumerable<Resources> resources)
        {
            if (resources.Any())
                return resources.Aggregate((r1, r2) => r1 + r2);
            else
                return new Resources();
        }
    }
}
