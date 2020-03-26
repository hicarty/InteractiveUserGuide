using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InteractiveDomain
{
    public class InteractiveAmplifier //Model
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }

        public virtual List<InteractiveElement> InteractiveElements { get; set; }
    }
}
