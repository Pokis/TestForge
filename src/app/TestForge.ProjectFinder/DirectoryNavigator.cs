namespace TestForge.ProjectFinder
{
    public static class DirectoryNavigator
    {
        public static string GoUpDirectory(int levels)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

            for (int i = 0; i < levels; i++)
            {
                currentDirectory = currentDirectory.Parent;
            }

            Directory.SetCurrentDirectory(currentDirectory.FullName);

            return currentDirectory.FullName;
        }
    }
}
