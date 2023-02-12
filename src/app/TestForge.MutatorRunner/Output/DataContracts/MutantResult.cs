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
    public class MutantResult
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "mutationScore")]
        public int MutationScore { get; set; }

        [DataMember(Name = "killedLines")]
        public List<int>? ChangedLines { get; set; }

        [DataMember(Name = "resultStatus")]
        public string? ResultStatus { get; set; }
    }
}
