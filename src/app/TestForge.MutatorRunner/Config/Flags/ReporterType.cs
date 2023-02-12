namespace TestForge.MutatorRunner.Config.Flags
{
    [Flags]
    public enum ReporterType
    {
        Html = 1,
        Progress = 2,
        Dashboard = 4,
        ClearText = 8,
        ClearTextTree = 16,
        Dots = 32,
        Json = 64
    }
}
