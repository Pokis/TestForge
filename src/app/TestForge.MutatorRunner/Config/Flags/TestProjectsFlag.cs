namespace TestForge.MutatorRunner.Config.Flags
{
    public class TestProjectsFlag : StrykerConfigFlagBase<string[]>
    {
        public TestProjectsFlag(string[] value) : base(value)
        {
        }

        public override string Description => "When you have multiple test projects covering one project under test you may specify all relevant test projects in the config file. You must run stryker from the project under test instead of the test project directory when using multiple test projects.";
        public override string Command => string.Join(" ", Value.Select(x => $"-tp {x}"));
    }
}
