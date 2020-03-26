using System;

namespace InteractiveDomain
{
    public class InteractiveElement
    {
        public int Id { get; set; }
        public int InteractiveAmplifierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Panel { get; set; }
        public string MeshName { get; set; }

        public virtual InteractiveAmplifier InteractiveAmplifier { get; set; }
    }
}
