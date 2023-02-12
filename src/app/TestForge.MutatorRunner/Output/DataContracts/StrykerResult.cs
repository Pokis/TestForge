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
    public class StrykerResult : IMutatorResult
    {
        [DataMember(Name = "version")]
        public string? Version { get; set; }

        [DataMember(Name = "timestampUtc")]
        public DateTime TimestampUtc { get; set; }

        [DataMember(Name = "projectRoot")]
        public string? ProjectRoot { get; set; }

        [DataMember(Name = "thresholds")]
        public Threshold[]? Thresholds { get; set; }

        [DataMember(Name = "files")]
        public List<FileResult>? Files { get; set; }
    }
}
