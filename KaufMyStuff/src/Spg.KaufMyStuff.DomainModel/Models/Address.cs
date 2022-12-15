﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.KaufMyStuff.DomainModel.Models
{
    public record Address(string StreetName, string HouseNumber, string City, string Zip)
    { }
}
