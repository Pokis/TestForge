using System.Xml.Linq;

namespace TestForge.ProjectFinder
{
    public class FileFinder
    {
        public string RootDir { get; }
        private string[]? _allProjects;

        public FileFinder(string? rootDir)
        {
            RootDir = rootDir ?? Directory.GetCurrentDirectory();
        }

        public string[] GetAllProjectsFullPaths()
        {
            var projects = _allProjects ??= GetFilesWithExtension(".csproj")
                .ToArray();

            if (projects.Length == 0)
            {
                return Array.Empty<string>();
            }

            return projects.ToArray()!;
        }

        public string[] GetAllTestProjects()
        {
            var testProjects = GetAllProjectsFullPaths()
                .Where(p => p.Contains("test", StringComparison.InvariantCultureIgnoreCase))
                .ToArray();

            var nUnitTestProjects = testProjects.Where(IsUnitTestProject).ToArray();

            return nUnitTestProjects.ToArray();
        }

        public string[] GetAllSolutions() => GetFilesWithExtension(".sln").ToArray();

        private List<string> GetFilesWithExtension(string extension)
        {
            var files = new List<string>();
            SearchDirectory(RootDir, extension, files);
            return files;
        }

        private static void SearchDirectory(string currentDirectory, string extension, List<string> files)
        {
            foreach (var file in Directory.GetFiles(currentDirectory))
            {
                if (Path.GetExtension(file) == extension)
                {
                    files.Add(file);
                }
            }

            foreach (var directory in Directory.GetDirectories(currentDirectory))
            {
                SearchDirectory(directory, extension, files);
            }
        }

        private static bool IsUnitTestProject(string csprojPath)
        {
            try
            {
                XDocument projectFile = XDocument.Load(csprojPath);
     
                var packageReferences = from reference in projectFile.Descendants("PackageReference")
                                        select reference.Attribute("Include").Value;

                return packageReferences.Any(reference =>
                {
                    return reference.StartsWith("Microsoft.NET.Test.Sdk", StringComparison.OrdinalIgnoreCase)
                           || reference.StartsWith("NUnit3TestAdapter", StringComparison.OrdinalIgnoreCase)
                           || reference.StartsWith("MSTest.TestFramework", StringComparison.OrdinalIgnoreCase);

                });
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}