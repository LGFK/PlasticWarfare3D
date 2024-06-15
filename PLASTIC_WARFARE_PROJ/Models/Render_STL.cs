using System.ComponentModel.DataAnnotations;

namespace PLASTIC_WARFARE_PROJ.Models
{
    public class Render_STL
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;

        public int Size { get; set; }

        public string Name { get; set; }

        public ICollection<ModelOrder> ModelOrders { get; set; }


    }
}
