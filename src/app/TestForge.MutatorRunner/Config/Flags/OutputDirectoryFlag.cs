namespace TestForge.MutatorRunner.Config.Flags
{
    public class OutputDirectoryFlag : StrykerConfigFlagBase<string>
    {
        public OutputDirectoryFlag(string value) : base(value)
        {
        }

        public override string Description =>
            "Changes the output path for Stryker logs and reports. This can be an absolute or relative path.";
        public override string Command => $"--output {Value}";
    }
}
