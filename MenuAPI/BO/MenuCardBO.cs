using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuAPI.BO
{
    public class MenuCardBO
    {
        public int? DishId { get; set; }
        public string Dish { get; set; }
        public int? Price { get; set; }
        public int? MenuID { get; set; }
        public int? ChoiceID { get; set; }
    }
}
