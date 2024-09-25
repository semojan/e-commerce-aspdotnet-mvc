﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Common.Dto
{
    public class ResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class ResultDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
