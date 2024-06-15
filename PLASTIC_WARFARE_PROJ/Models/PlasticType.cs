using System.ComponentModel.DataAnnotations;

namespace PLASTIC_WARFARE_PROJ.Models
{
    public class PlasticType
    {
        [Key]
        public int Id { get; set; }
        
        public string Type { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
