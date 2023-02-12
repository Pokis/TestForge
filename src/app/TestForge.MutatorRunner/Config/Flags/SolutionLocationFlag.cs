namespace TestForge.MutatorRunner.Config.Flags
{
    public sealed class SolutionLocationFlag : StrykerConfigFlagBase<string>
    {
        public SolutionLocationFlag(string value) : base(value)
        {
        }

        public override string Description => "Path for the solution";
        public override string Command => $"--solution {Value}";
    }
}
