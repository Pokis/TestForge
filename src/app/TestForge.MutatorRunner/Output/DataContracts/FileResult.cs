using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestForge.MutatorRunner.Output.DataContracts
{
    [DataContract]
    public class FileResult
    {
        [DataMember(Name = "fileName")]
        public string? FileName { get; set; }

        [DataMember(Name = "mutants")]
        public List<MutantResult>? Mutants { get; set; }
    }
}
