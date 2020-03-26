using System;
using System.Collections.Generic;

namespace InteractiveDomain
{
    public class AmplifierModel
    {
        public int ID { get; set; }
        public AmplifierModel()
        {
            Elements = new List<ElementModel>();
        }
        public ICollection<ElementModel> Elements { get; set; }
        public string Name { get; set; }
    }
}
