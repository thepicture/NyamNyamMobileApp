using NyamNyamMobileApp.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace NyamNyamMobileApp.Services
{
    public class OrderDataStore : IDataStore<ResponseOrder>
    {
        private const string BaseUrl = "http://10.0.2.2:62319/api/";
        public OrderDataStore()
        {
        }

        public async Task<bool> AddItemAsync(ResponseOrder item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateItemAsync(ResponseOrder item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseOrder> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResponseOrder>> GetItemsAsync(bool forceRefresh = false)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OrdersList));
            WebClient client = new WebClient();
            byte[] response = client.DownloadData(BaseUrl + "orderapi");
            OrdersList ordersList = (OrdersList)serializer.ReadObject(new MemoryStream(response));
            return await Task.FromResult(ordersList.Orders);
        }
    }
}