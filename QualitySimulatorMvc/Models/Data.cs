using System.Collections.Generic;

namespace WebFrontend.Models
{
    public class Data
    {
        public List<string> QualityStandards { get; set; } = new List<string>();
        public List<string> ElectronicComponents { get; set; } = new List<string>();
        public Dictionary<string, string> ComponentQuality { get; set; } = new Dictionary<string, string>();
    }
}
