using System;
using System.Collections.Generic;
using System.Text;
using WebApiCore.Model.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureMeetupApp.Services
{
    interface IBackend
    {
        Task<Employee[]> GetEmployees();
    }
}
