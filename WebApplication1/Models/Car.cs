using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Car
    {
        [Key]
        public int car_id { get; set; }
        public string firm { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public int power { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public int diler_id { get; set; }

    }
}
