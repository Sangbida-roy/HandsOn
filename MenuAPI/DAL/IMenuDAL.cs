using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuAPI.DAL;
using MenuAPI.BO;


namespace MenuAPI.DAL
{
    public interface IMenuDAL
    {
        IEnumerable<MenuBO> GetMenu(); //ask Indian or Continental -> returns the table Indian+Continental
        IEnumerable<ChoiceBO> GetChoice();//returs Veg+NonVeg Options

        IEnumerable<MenuCardBO> GetMenuCard(int Mid, int Cid);

        bool AddDish(MenuCardBO dish);
    }
}
