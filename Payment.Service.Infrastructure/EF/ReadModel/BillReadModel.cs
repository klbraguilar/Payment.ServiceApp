using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.ReadModel
{
    [Table("bill")]
    public class BillReadModel
    {
        [Key]
        [Column("billId")]
        public Guid Id { get; set; }

        [Column("categoryId")]
        public Guid CategoryId { get; set; }
        public CategoryReadModel Category { get; set; }

        [Column("clientId")]
        public Guid ClientId { get; set; }
        public ClientReadModel Client { get; set; }

        [Column("period")]
        [StringLength(250)]
        [Required]
        public string Period { get; set; }

        [Column("state")]
        [StringLength(10)]
        [Required]
        public string State { get; set; }

        [Column("costo", TypeName = "decimal(18,2)")]
        [Required]
        public decimal Amount { get; set; }
    }
}
