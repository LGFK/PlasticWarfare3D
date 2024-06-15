using PLASTIC_WARFARE_PROJ.DbContextData;
using PLASTIC_WARFARE_PROJ.Models;

namespace PLASTIC_WARFARE_PROJ.Repos
{
    public class PlasticWarfareRepo : IPlasticWarfareRepo
    {
        private readonly MainDataContext _mainDataContext;

        public PlasticWarfareRepo(MainDataContext mainDataContext)
        {
            _mainDataContext = mainDataContext;
        }
        public void CreateOrder(Order order, List<Render_STL> models)
        {
            foreach (var model in models)
            {
                var modelOrder = new ModelOrder
                {
                    Render_STL = model,
                    Order = order
                };
                order.ModelOrders = new List<ModelOrder>();
                // Добавляем ModelOrder в коллекцию ModelOrders заказа
                order.ModelOrders.Add(modelOrder);
            }

            // Добавляем заказ в базу данных
            _mainDataContext.Orders.Add(order);

            // Сохраняем изменения
            _mainDataContext.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return _mainDataContext.Orders.ToList();
        }

        public List<PlasticType> GetPlasticTypes()
        {
            return _mainDataContext.PlasticTypes.ToList();
        }

        public List<Color> GetColors()
        {
            return _mainDataContext.Colors.ToList();
        }

        public List<Order> GetOrderListForParticularUser(String u)
        {
            return _mainDataContext.Orders.Where(o=>o.UserId == u).ToList();
        }
    }
}
