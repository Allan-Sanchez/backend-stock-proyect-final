using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectUMG.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        public float quantity { get; set; }
        [Required]
        public float price { get; set; }

        public DateTime? Created_at = null;

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
