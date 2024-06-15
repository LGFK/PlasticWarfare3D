using System.ComponentModel.DataAnnotations;

namespace PLASTIC_WARFARE_PROJ.Models
{
    public class ModelOrder
    {
        public int RenderId { get; set; }

        public Render_STL Render_STL { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
