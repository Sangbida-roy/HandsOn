using System;
using System.Collections.Generic;

namespace MenuAPI2022.DB
{
    public partial class MenuCard
    {
        public MenuCard()
        {
            Dishes = new HashSet<Dishes>();
        }

        public int MenuId { get; set; }
        public string? Cuisine { get; set; }

        public virtual ICollection<Dishes> Dishes { get; set; }
    }
}
