﻿using MediatR;
using Payment.Service.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Application.UseCases.Bill.Command.Quey.GetBillsListQuery
{
    public class GetBillsListQuery : IRequest<ICollection<BillDto>>
    {
    }
}
