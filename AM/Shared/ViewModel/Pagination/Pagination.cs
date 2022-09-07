﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel.Pagination
{
    public class Pagination<T>
    {
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}
