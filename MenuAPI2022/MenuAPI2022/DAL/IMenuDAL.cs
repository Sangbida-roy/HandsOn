using MenuAPI2022.DAL;
using MenuAPI2022.BO;
namespace MenuAPI2022.DAL
{
    public interface IMenuDAL
    {
        IEnumerable<MenuBO> GetMenu(); //ask Indian or Continental -> returns the table Indian+Continental
        IEnumerable<ChoiceBO> GetChoice();//returs Veg+NonVeg Options

        IEnumerable<MenuCardBO> GetMenuCard(int Mid, int Cid);

        bool AddDish(MenuCardBO dish);

    }
}