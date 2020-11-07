using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectUMG.Models
{
    public class Buy
    {
        [Key]
        public int BuyId { get; set; }
        [Required]
        public int quantity { get; set; }

        public DateTime? Created_at = null;
        //[Required]
      public int ProviderId { get; set; }
        public Provider Provider { get; set; }
       // [Required]
       public int StateBuyId { get; set; }
        public StateBuy StateBuy { get; set; }

        
       public int UserId { get; set; }
        public User User { get; set; }

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
