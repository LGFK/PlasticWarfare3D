using System.ComponentModel.DataAnnotations;

namespace PLASTIC_WARFARE_PROJ.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        public string ColorN { get; set; }


    }
}
