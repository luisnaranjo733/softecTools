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
        /// </summary>
        public async void FetchData()
        {
            Data = new List<DataItem>();

            Dictionary<string, string> values = new Dictionary<string, string>
            {
                { "restaurant-id", "1" },
                { "password", "softec" }
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
        /// </summary>
        /// <param name="data"></param>
        public void AddItem(DataItem item)
        {
            Data.Add(item);
        }
    }
}
