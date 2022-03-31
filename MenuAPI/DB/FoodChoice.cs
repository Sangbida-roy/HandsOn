using System;
using System.Collections.Generic;

#nullable disable

namespace MenuAPI.DB
{
    public partial class FoodChoice
    {
        public FoodChoice()
        {
            Dishes = new HashSet<Dishes>();
        }

        public int ChoiceId { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Dishes> Dishes { get; set; }
    }
}
