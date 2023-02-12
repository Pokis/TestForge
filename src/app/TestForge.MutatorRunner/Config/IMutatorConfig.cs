using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForge.MutatorRunner.Config
{
    public interface IMutatorConfig
    {
        public string GetCommand();
        public string? GetWorkingDir();
    }
}
