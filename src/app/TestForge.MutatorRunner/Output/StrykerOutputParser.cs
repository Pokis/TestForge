using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForge.MutatorRunner.Output.DataContracts;

namespace TestForge.MutatorRunner.Output
{
    public class StrykerOutputParser : IMutatorOutputParser
    {
        public IMutatorResult? Parse(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.", filePath);
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<StrykerResult>(json);
        }
    }
}
