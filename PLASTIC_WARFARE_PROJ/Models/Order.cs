using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLASTIC_WARFARE_PROJ.Models
{
    [Index(nameof(UserId))]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("FK_USER_ID")]

        public String UserId { get; set; }

        public int Price { get; set; }

        public int ModelsAmount { get; set; }

        public int TotalWeight { get; set; }

        public string AdditionalDescription { get; set; }

        public bool IsChecked { get; set; } = false;

        public int PlasticTypeId { get; set; }
        public int ColorId { get; set; }

        public Color Color { get; set; }

        public PlasticType PlasticType { get; set; }

        public ICollection<ModelOrder> ModelOrders { get; set; }
    }
}
