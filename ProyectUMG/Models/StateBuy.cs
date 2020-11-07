using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectUMG.Models
{
    public class StateBuy
    {
        [Key]
        public int StateBuyId { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public float total { get; set; }
     
        public DateTime? Created_at = null;

        public ICollection<Buy> Buys { get; set; }
        public DateTime DateCreated
        {
            get
            {
                return this.Created_at.HasValue ? this.Created_at.Value : DateTime.Now;
            }

            set { this.Created_at = value; }

        }
    }
}
