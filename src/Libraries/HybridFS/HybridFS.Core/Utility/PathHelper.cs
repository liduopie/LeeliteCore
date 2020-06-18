using System;
using System.Linq;

namespace HybridFS.Utility
{
    public static class PathHelper
    {
        /// <summary>
        /// Combines multiple path parts using the path delimiter semantics of the abstract virtual file store.
        /// </summary>
        /// <param name="paths">The path parts to combine.</param>
        /// <returns>The full combined path.</returns>
        public static string Combine(params string[] paths)
        {
            if (paths.Length == 0)
                return null;

            var normalizedParts =
                paths
                    .Select(x => NormalizePath(x))
                    .Where(x => !String.IsNullOrEmpty(x))
                    .ToArray();

            var combined = String.Join("/", normalizedParts);

            // Preserve the initial '/' if it's present.
            if (paths[0]?.StartsWith('/') == true)
                combined = "/" + combined;

            return combined;
        }

        /// <summary>
        /// Normalizes a path using the path delimiter semantics of the abstract virtual file store.
        /// </summary>
        /// <remarks>
        /// Backslash is converted to forward slash and any leading or trailing slashes
        /// are removed.
        /// </remarks>
        public static string NormalizePath(string path)
        {
            if (path == null)
                return null;

            return path.Replace('\\', '/').Trim('/');
        }
    }
}
