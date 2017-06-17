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
        //private List<DataItem> _data { get; set; }
        public List<DataItem> Data { get; set; }

        /// <summary>
        /// Load data from local storage into memory
        /// </summary>
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

        /// <summary>
        /// * Add item to memory
        /// * Save memory to local storage
        /// * Save memory to cloud storage (if possible)
        /// </summary>
        /// <param name="data"></param>
        public void AddItem(DataItem item)
        {
            Data.Add(item);
        }
    }
}
