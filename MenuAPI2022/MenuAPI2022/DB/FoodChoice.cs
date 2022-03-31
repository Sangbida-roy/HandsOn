using System;
using System.Collections.Generic;

namespace MenuAPI2022.DB
{
    public partial class FoodChoice
    {
        public FoodChoice()
        {
            Dishes = new HashSet<Dishes>();
        }

        public int ChoiceId { get; set; }
        public string? Category { get; set; }

        public virtual ICollection<Dishes> Dishes { get; set; }
    }
}
