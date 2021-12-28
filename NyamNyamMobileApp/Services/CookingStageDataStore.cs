using NyamNyamMobileApp.Models.ResponseModels;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace NyamNyamMobileApp.Services
{
    public class CookingStageDataStore : IDataStore<ResponseCookingStageList>
    {
        private const string BaseUrl = "http://10.0.2.2:62319/api/cookingstages?";

        public Task<bool> AddItemAsync(ResponseCookingStageList item)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseCookingStageList> GetItemAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ResponseCookingStageList>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ResponseCookingStageList>> GetItemsAsyncFromId(bool forceRefresh = false, params object[] id)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ResponseCookingStageList));
            WebClient client = new WebClient();
            byte[] response = client.DownloadData(BaseUrl + $"orderId={id[0]}&dishId={id[1]}");
            ResponseCookingStageList stagesList = (ResponseCookingStageList)serializer.ReadObject(new MemoryStream(response));
            return await Task.FromResult(new List<ResponseCookingStageList> { stagesList });
        }

        public Task<bool> UpdateItemAsync(ResponseCookingStageList item)
        {
            throw new System.NotImplementedException();
        }
    }
}
