namespace TestForge.MutatorRunner.Config.Flags
{
    public class ProjectNameFlag : StrykerConfigFlagBase<string>
    {
        public ProjectNameFlag(string value) : base(value)
        {
        }

        public override string Description =>
            "The project file name is required when your test project has more than one project reference. Stryker can currently mutate one project under test for 1..N test projects but not 1..N projects under test for one test project.\r\n\r\n* Do not pass a path to this option. Pass the project file name as it appears in your test project's references.";
        public override string Command => $"--project {Value}";
    }
}
