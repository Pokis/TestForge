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
        public string? Id { get; set; }

        [DataMember(Name = "mutatorName")]
        public string? MutatorName { get; set; }

        [DataMember(Name = "replacement")]
        public string? Replacement { get; set; }

        [DataMember(Name = "location")]
        public MutationLocationInCode? LocationInCode { get; set; }

        [DataMember(Name = "status")]
        public string? Status { get; set; }

        [DataMember(Name = "static")]
        public bool Static { get; set; }
    }
}
