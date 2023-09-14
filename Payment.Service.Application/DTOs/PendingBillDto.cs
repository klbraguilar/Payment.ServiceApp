using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.DTOs
{
    public class PendingBillDto
    {
        public Guid Id { get; set; }
        public Guid Client { get; set; }
        public string Period { get; set; }
        public string State { get; set; }
        public decimal Amount { get; set; }

    }
}
