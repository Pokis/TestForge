using System.Runtime.Serialization;

namespace TestForge.MutatorRunner.Output.DataContracts
{
    [DataContract]
    public class StrykerResult : IMutatorResult
    {
        [DataMember(Name = "schemaVersion")]
        public string? Version { get; set; }

        [DataMember(Name = "projectRoot")]
        public string? ProjectRoot { get; set; }

        [DataMember(Name = "thresholds")]
        public Threshold? Thresholds { get; set; }

        [DataMember(Name = "files")]
        public Dictionary<string, FileResult>? Files { get; set; }
    }
}
