using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForge.MutatorRunner.Config.Flags;

namespace TestForge.MutatorRunner.Config
{
    public sealed class StrykerConfig : IMutatorConfig
    {
        public SolutionLocationFlag? Solution { get; set; }
        public ReporterFlag? ReporterFlags { get; set; }
        public ProjectNameFlag? ProjectName { get; set; }
        public TestProjectsFlag? TestProjects { get; set; }
        public OutputDirectoryFlag? OutputDirectory { get; set; }

        public string GetCommand()
        {
            StringBuilder builder = new("");
            builder.Append(AppendCommand(Solution));
            builder.Append(AppendCommand(ReporterFlags));
            builder.Append(AppendCommand(ProjectName));
            builder.Append(AppendCommand(TestProjects));
            builder.Append(AppendCommand(OutputDirectory));

            return builder.ToString();
        }

        public string? GetWorkingDir() => Path.GetDirectoryName(Solution?.Value);

        private static string AppendCommand(IMutatorFlagConfig? config)
        {
            return config is null ? string.Empty : $" {config.Command}";
        }
    }
}
