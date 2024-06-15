using PLASTIC_WARFARE_PROJ.Models;

namespace PLASTIC_WARFARE_PROJ.ViewModels
{
    public class OrderVM
    {
        public List<Color> Colors { get; set; }

        public List<Order> Orders { get; set; }

        public List<PlasticType> PlasticTypes { get; set; }
    }
}
