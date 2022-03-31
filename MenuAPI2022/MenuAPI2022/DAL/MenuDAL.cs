using MenuAPI2022.DAL;
using MenuAPI2022.BO;
using MenuAPI2022.DB;

namespace MenuAPI2022.DAL
{
    public class MenuDAL : IMenuDAL
    {
        private readonly TrainingDbContext _db;
        private readonly ILogger<MenuDAL> _logger;

        public MenuDAL(TrainingDbContext db, ILogger<MenuDAL> logger)
        {
            _db = db;
            _logger = logger;
        }

        //get the cusine
        public IEnumerable<MenuBO> GetMenu()
        {
            return _db.MenuCard.Select(x => new MenuBO
            {
                MenuID = x.MenuId,
                Cusine = x.Cuisine,
            }).ToList();
        }
        //get the choice
        public IEnumerable<ChoiceBO> GetChoice() /*id=1 || id=2*/
        {
            return _db.FoodChoice.Select(x => new ChoiceBO
            {
                ChoiceID = x.ChoiceId,
                Category = x.Category,
            }).ToList();
        }

        public IEnumerable<MenuCardBO> GetMenuCard(int Mid, int Cid)
        {


            return _db.Dishes.Where(x => x.ChoiceId == Cid && x.MenuId == Mid).Select(x => new MenuCardBO
            {
                DishId = x.DishId,
                Dish = x.Dish,
                Price = x.Price,
            }).ToList();


        }

        //create dish
        public bool AddDish(MenuCardBO dish)
        {
            var success = true;
            try
            {
                _db.Dishes.Add(new Dishes
                {
                    Dish = dish.Dish,
                    Price = dish.Price,
                    MenuId = dish.MenuID,
                    ChoiceId = dish.ChoiceID,



                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
                throw;
            }
            return success;
        }



    }
}
