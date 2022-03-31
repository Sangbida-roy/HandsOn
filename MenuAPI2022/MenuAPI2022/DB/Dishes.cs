using System;
using System.Collections.Generic;

namespace MenuAPI2022.DB
{
    public partial class Dishes
    {
        public int DishId { get; set; }
        public string? Dish { get; set; }
        public int? Price { get; set; }
        public int? MenuId { get; set; }
        public int? ChoiceId { get; set; }

        public virtual FoodChoice? Choice { get; set; }
        public virtual MenuCard? Menu { get; set; }
    }
}
