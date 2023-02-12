namespace TestForge.MutatorRunner.Config.Flags
{
    public class ReporterFlag : StrykerConfigFlagBase<ReporterType[]>
    {
        public ReporterFlag(ReporterType[] value) : base(value)
        {
        }

        public override string Description =>
            "During a mutation testrun one or more reporters can be enabled. A reporter will produce some kind of output during or after the mutation testrun.";

        public override string Command => string.Join(" ", Value.Select(x => $"--reporter \"{x.ToString().ToLower()}\""));
    }
}
