﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreBox.Models
{
    public class OrderDTO
    {
        public IEnumerable<ProducTypeDTO> Products { get; set; }
        public float TotalSize { get; set; }
    }
}
