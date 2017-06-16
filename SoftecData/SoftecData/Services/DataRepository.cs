using SoftecData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Services
{
    public class DataRepository
    {
        public List<DataItem> Data { get; set; }

        public void FetchData()
        {
            Data = new List<DataItem>();
            Data.Add(new DataItem
            {
                Key = "softouch username",
                Value = "admin",
                Protected = false
            });

            Data.Add(new DataItem
            {
                Key = "softouch password",
                Value = "1234",
                Protected = false
            });

            Data.Add(new DataItem
            {
                Key = "Teamviewer installed?",
                Value = "yes",
                Protected = true
            });
        }
    }
}
