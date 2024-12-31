using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Diler
    {
        [Key]
        public int diler_id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public double Rating { get; set; }
    }
}
