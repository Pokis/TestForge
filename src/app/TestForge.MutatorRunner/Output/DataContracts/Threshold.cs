using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestForge.MutatorRunner.Output.DataContracts
{
    [DataContract]
    public class Threshold
    {
        [DataMember(Name = "high")]
        public int High { get; set; }

        [DataMember(Name = "low")]
        public int Low { get; set; }
    }
}
