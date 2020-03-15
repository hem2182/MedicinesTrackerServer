using MedicinesServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MedicinesServer.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class MedicinesController : ApiController
    {
        private static List<MedicinesModel> medicines = new List<MedicinesModel>();
        public MedicinesController()
        {
            if (medicines.Count == 0) { 
                medicines.Add(new MedicinesModel { Id = 1, Name= "Sample Medicine 1", Brand = "Sample Brand 1", Quantity = 8,
                ExpiryDate = DateTime.Now.AddMonths(3).ToString("MM/dd/yyyy"), Price = 120.99, Notes = "Sample Notes 1"});

                medicines.Add(new MedicinesModel { Id = 2, Name= "Sample Medicine 2", Brand = "Sample Brand 2", Quantity = 5,
                ExpiryDate = DateTime.Now.AddMonths(4).ToString("MM/dd/yyyy"), Price = 120.99, Notes = "Sample Notes 1"});

                medicines.Add(new MedicinesModel { Id = 3, Name= "Sample Medicine 3", Brand = "Sample Brand 3", Quantity = 80,
                ExpiryDate = DateTime.Now.AddDays(15).ToString("MM/dd/yyyy"), Price = 120.99, Notes = "Sample Notes 1"});

                medicines.Add(new MedicinesModel { Id = 4, Name= "Sample Medicine 4", Brand = "Sample Brand 4", Quantity = 1000,
                ExpiryDate = DateTime.Now.AddMonths(6).ToString("MM/dd/yyyy"), Price = 120.99, Notes = "Sample Notes 1"});

                medicines.Add(new MedicinesModel { Id = 5, Name= "Sample Medicine 5", Brand = "Sample Brand 5", Quantity = 500,
                ExpiryDate = DateTime.Now.AddMonths(1).ToString("MM/dd/yyyy"), Price = 120.99, Notes = "Sample Notes 1"});
            }
        }
        // GET: api/Medicines
        public IEnumerable<MedicinesModel> Get()
        {
            return medicines;
        }

        // GET: api/Medicines/5
        public MedicinesModel Get(int id)
        {
            return medicines.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        // POST: api/Medicines
        public string Post([FromBody]MedicinesModel value)
        {
            var maxId = medicines.Max(x => x.Id);
            value.Id = maxId+1;
            medicines.Add(value);
            return value.Id.ToString();
        }

        // PUT: api/Medicines/5
        public void Put(int id, [FromBody]MedicinesModel updatedData)
        {
            var data = medicines.FirstOrDefault(x => x.Id == id);
            data.Name = updatedData.Name;
            data.Brand = updatedData.Brand;
            data.Notes = updatedData.Notes;
            data.Price = updatedData.Price;
            data.Quantity = updatedData.Quantity;
            data.ExpiryDate = updatedData.ExpiryDate;

        }

        // DELETE: api/Medicines/5
        public void Delete(int id)
        {
            var data = medicines.FirstOrDefault(x => x.Id == id);
            medicines.Remove(data);
        }
    }
}
