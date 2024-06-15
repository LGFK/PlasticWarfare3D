using PLASTIC_WARFARE_PROJ.Models;

namespace PLASTIC_WARFARE_PROJ.Repos
{
    public interface IPlasticWarfareRepo
    {
        List<Order> GetAllOrders();

        void CreateOrder(Order order, List<Render_STL> models);

        public List<PlasticType> GetPlasticTypes();

        public List<Color> GetColors();
        public List<Order> GetOrderListForParticularUser(String userId);

    }
}
