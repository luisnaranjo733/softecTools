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
        /// Fetch data from local storage and store it in memory
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
        /// * Set local storage from memory
        /// * Set cloud storage from memory (if possible)
        /// </summary>
        /// <param name="data"></param>
        public void UpdateData(List<DataItem> data)
        {

        }

        public void AddItem(DataItem item)
        {
            Data.Add(item);
        }
    }
}
