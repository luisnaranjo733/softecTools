using Newtonsoft.Json;
using SoftecData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Services
{
    public class DataRepository
    {
        //private List<DataItem> _data { get; set; }
        public List<DataItem> Data { get; set; }
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Load data from local storage into memory
        /// 
        /// v2
        /// Load data from cloud into memory
        /// Save data from memory into local storage
        ///// 
        /// OR
        /// 
        /// Load data from cloud into memory (fail)
        /// Load data from local storage
        /// </summary>
        public async void FetchData()
        {
            //Properties.Settings.Default.eAutomateID = 1;
            //Properties.Settings.Default.Save();
            var id = Properties.Settings.Default.eAutomateID;

            Data = new List<DataItem>();

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "eAutomateID", "AZ01" }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(values);

            HttpResponseMessage response = client.PostAsync("http://ec2-54-202-79-153.us-west-2.compute.amazonaws.com/api/data/", content).Result;
            string responseString = await response.Content.ReadAsStringAsync();

            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseString);

            foreach(DataItem dataItem in apiResponse.data)
            {
                AddItem(dataItem);
            }

        }

        /// <summary>
        /// * Add item to memory
        /// * Save memory to local storage
        /// * Save memory to cloud storage (if possible)
        /// 
        /// v2
        /// * Add item to memory
        /// * Save new item to local storage
        /// * Save new item to cloud
        /// </summary>
        /// <param name="data"></param>
        public void AddItem(DataItem item)
        {
            Data.Add(item);
        }
    }
}
