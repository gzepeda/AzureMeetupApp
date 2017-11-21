using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WebApiCore.Model.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureMeetupApp.Services
{
    public class BackendDotNetCore: IBackend
    {
        public async Task<Employee[]> GetEmployees()
        {
            var client = new HttpClient();
            string results = "";
            HttpResponseMessage response;

            string url = "http://localhost:58300/api/employees";

            //using (var content = new ByteArrayContent(requestContent))
            //{
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                try
                {
                    response = await client.GetAsync(url);
                    results = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    results = "Exception on call to HTTP service: " + e.Message;
                    System.Diagnostics.Debug.WriteLine(e.Message + e.InnerException + e.StackTrace);
                    throw new Exception(results, e.InnerException);
                }
            //}

            if (String.IsNullOrEmpty(results))
            {
                return null;
            }

            Employee[] deserializedDto;

            try
            {
                deserializedDto = JsonConvert.DeserializeObject<Employee[]>(results);
            }
            catch (Exception e)
            {
                //return "Cannot process the prediction results: " + e.Message;
                return null;
            }
            return deserializedDto;
        }
    }
}
