using TestForge.Core;
using TestForge.MutatorRunner.Config;
using TestForge.MutatorRunner.Config.Flags;
using TestForge.MutatorRunner.Runner;
using TestForge.ProjectFinder;

namespace TestForge.InteractiveConsole
{
    public class InteractiveForgeConsole : IForgeConsole
    {
        public InteractiveForgeConsole(string[] args)
        {

        }

        public void Start()
        {
            //TODO[DJ]: Make configurable
            var source = "C:\\src\\";
            System.IO.Directory.SetCurrentDirectory(source);
            var fileFinder = new FileFinder(source);
            var projects = fileFinder.GetAllProjectsFullPaths();

            var projectNames = projects.Select(Path.GetFileName).ToArray();
            var project = StringChooser.PromptForChoice(projectNames!);
            var solutions = fileFinder.GetAllSolutions();

            var testProjects = fileFinder.GetAllTestProjects();

            var config = CreateStrykerConfig(project, testProjects, solutions);
            var runner = new StrykerRunner();
            runner.RunMutator(config);
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
                //TODO[DJ]: Make configurable
                OutputDirectory = new OutputDirectoryFlag("C:\\strykerOutput")
            };

            return config;
        }
    }
}