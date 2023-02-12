using TestForge.Core;
using TestForge.MutatorRunner.Config;
using TestForge.MutatorRunner.Config.Flags;
using TestForge.MutatorRunner.Output;
using TestForge.MutatorRunner.Runner;
using TestForge.ProjectFinder;

namespace TestForge.InteractiveConsole
{
    public class InteractiveForgeConsole : IForgeConsole
    {
        //TODO[DJ]: Make configurable
        private string _source = "C:\\src\\";
        private string _strykerOutput = "C:\\Source\\reports";

        public InteractiveForgeConsole(string[] args)
        {

        }

        public void Start()
        {
            var userSelectionResult = StringChooser<ConsoleOptions>.PromptForChoice(Enum.GetValues<ConsoleOptions>());

            if (userSelectionResult == ConsoleOptions.GenerateStrykerOutput)
            {
                System.IO.Directory.SetCurrentDirectory(_source);
                var fileFinder = new FileFinder(_source);
                var projects = fileFinder.GetAllProjectsFullPaths();

                var projectNames = projects.Select(Path.GetFileName).ToArray();
                var project = StringChooser<string>.PromptForChoice(projectNames!);
                var solutions = fileFinder.GetAllSolutions();

                var testProjects = fileFinder.GetAllTestProjects();

                var config = CreateStrykerConfig(project, testProjects, solutions);
                var runner = new StrykerRunner();
                runner.RunMutator(config);
            }

            if (userSelectionResult == ConsoleOptions.ReadStrykerOutput)
            {
                try
                {
                    var parser = new StrykerOutputParser();
                    var result = parser.Parse(Path.Join(_strykerOutput, "mutation-report.json"));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to parse mutator result {0}", e.Message);
                }
            }
        }

        private IMutatorConfig CreateStrykerConfig(string projectName, string[] testProjects, string[] solutions)
        {
            var config = new StrykerConfig()
            {
                ProjectName = new ProjectNameFlag(projectName),
                ReporterFlags =
                    new ReporterFlag(new[] { ReporterType.Json, ReporterType.Html }),
                TestProjects = new TestProjectsFlag(testProjects),
                Solution = new SolutionLocationFlag(solutions.First()),
                OutputDirectory = new OutputDirectoryFlag(_strykerOutput)
            };

            return config;
        }
    }
}