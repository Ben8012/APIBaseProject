﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Forms.Adress
{
    public class AdressFormBll
    {
        public int? Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
