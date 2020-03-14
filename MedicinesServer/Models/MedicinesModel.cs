using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicinesServer.Models
{
    public class MedicinesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}