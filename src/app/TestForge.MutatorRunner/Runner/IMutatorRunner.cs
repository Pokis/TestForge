using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForge.MutatorRunner.Config;

namespace TestForge.MutatorRunner.Runner
{
    public interface IMutatorRunner
    {
        void RunMutator(IMutatorConfig config);
    }
}
