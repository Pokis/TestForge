using TestForge.MutatorRunner.Config;

namespace TestForge.MutatorRunner.Runner
{
    public class StrykerRunner : IMutatorRunner
    {
        public void RunMutator(IMutatorConfig config)
        {
            var mutatorParams = config.GetCommand();
            Console.WriteLine($"Running mutator with params: {mutatorParams}");
            var output = DotNetToolRunner.RunTool(
                "dotnet",
                $"stryker {mutatorParams}",
                config.GetWorkingDir());
            Console.WriteLine("Mutator tool output:");
            Console.WriteLine(output);
        }
    }
}
