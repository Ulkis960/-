using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowRoom.Domain
{
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Range(7, 9)]
        public string RegNumber { get; set; }
        [Required]

        public string Manufacture { get; set; }
        [Required]
        [MaxLength(30)]
        public string Model { get; set; }
        [Required]
        

        public string Picture { get; set; }

        public DateTime YearOfManufacture { get; set; }

        [Required]
        [Range(1000, 300000)]
        public double Price { get; set; }

        internal static object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
