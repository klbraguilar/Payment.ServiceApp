using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Infrastructure.EF.ReadModel
{
    [Table("client")]
    public class ClientReadModel
    {
        [Key]
        [Column("clientId")]
        public Guid Id { get; set; }

        [Column("name")]
        [StringLength(250)]
        [Required]
        public string? Name { get; set; }
    }
}
