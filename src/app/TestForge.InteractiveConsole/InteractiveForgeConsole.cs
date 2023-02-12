using Newtonsoft.Json;
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
        private string? _repoRoot;
        private IMutatorResult? _strykerOutputResult;

        public InteractiveForgeConsole(string[] args)
        {

        }

        public void Start()
        {
            SetCurrentDirectory();

            ConsoleOptions? userSelectionResult = null;

            while(userSelectionResult != ConsoleOptions.Exit)
            {
                userSelectionResult = StringChooser<ConsoleOptions>.PromptForChoice(Enum.GetValues<ConsoleOptions>());

                if (userSelectionResult == ConsoleOptions.GenerateStrykerOutput)
                {
                    GenerateStrykerOutput();
                }

                if (userSelectionResult == ConsoleOptions.ReadStrykerOutput)
                {
                    ReadStrykerOutput();
                }

                if (userSelectionResult == ConsoleOptions.PrintStrykerOutput)
                {
                    PrintStrykerOutput();
                }
            }
        }

        private void SetCurrentDirectory()
        {
            //TODO[DJ]: Take source under question from args
            var currentDir = DirectoryNavigator.GoUpDirectory(6);

            Console.WriteLine($"current dir: {currentDir}");
            _repoRoot = currentDir;
        }

        private void GenerateStrykerOutput()
        {
            var fileFinder = new FileFinder(_repoRoot);
            //var projects = fileFinder.GetAllProjectsFullPaths();

            //var projectNames = projects.Select(Path.GetFileName).ToArray();
            //var project = StringChooser<string>.PromptForChoice(projectNames!);
            var solutions = fileFinder.GetAllSolutions();

            var testProjects = fileFinder.GetAllTestProjects();

            string? solution;
            if (solutions.Length > 1)
            {
                solution = StringChooser<string>.PromptForChoice(solutions);
            }
            else
            {
                solution = solutions.First();
            }


            //var config = CreateStrykerConfig(project, testProjects, solution!);
            var config = CreateStrykerConfig(string.Empty, testProjects, solution!);
            var runner = new StrykerRunner();
            runner.RunMutator(config);
        }

        private void ReadStrykerOutput()
        {
            try
            {
                var parser = new StrykerOutputParser();
                var path = Path.Join(_repoRoot, "reports", "mutation-report.json");
                Console.WriteLine($"Reading stryker result from path: {path}");
                _strykerOutputResult = parser.Parse(Path.Join(_repoRoot, "reports", "mutation-report.json"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to parse mutator result {0}", e.Message);
            }
        }

        private void PrintStrykerOutput()
        {
            if(_strykerOutputResult != null )
            {
                Console.WriteLine(JsonConvert.SerializeObject(_strykerOutputResult));
            }
            else
            {
                Console.WriteLine("No stryker output available, generate one beforehand.");
            }
        }

        private IMutatorConfig CreateStrykerConfig(string projectName, string[] testProjects, string solution)
        {
            var config = new StrykerConfig()
            {
               // ProjectName = new ProjectNameFlag(projectName),
                ReporterFlags =
                    new ReporterFlag(new[] { ReporterType.Json, ReporterType.Html }),
                TestProjects = new TestProjectsFlag(testProjects),
                Solution = new SolutionLocationFlag(solution),
                OutputDirectory = new OutputDirectoryFlag(_repoRoot!)
            };

            return config;
        }
    }
}