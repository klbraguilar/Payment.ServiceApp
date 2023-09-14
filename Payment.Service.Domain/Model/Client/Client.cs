﻿using Payment.Service.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.Domain.Model.Client
{
    public class Client : AggregateRoot
    {
        public NameValue Name { get; private set; }

        public Client(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void Edit(string name)
        {
            Name = name;
        }

        public Client() { }
    }
}