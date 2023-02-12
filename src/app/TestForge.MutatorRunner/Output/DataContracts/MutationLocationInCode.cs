using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestForge.MutatorRunner.Output.DataContracts
{
    [DataContract]
    public class MutationLocationInCode
    {
        [DataMember(Name = "start")]
        public CodeLocation? Start { get; set; }

        [DataMember(Name = "end")]
        public CodeLocation? End { get; set; }
    }
}
