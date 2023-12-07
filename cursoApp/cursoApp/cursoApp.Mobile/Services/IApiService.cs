using cursoApp.Mobile.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cursoApp.Mobile.Services
{
    public interface IApiService
    {
        Task<Response> PostAsync<T>(string urlBase, string servicePrefix, string controller, T model);

        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}