using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eVehicleDealership.Modeli;
using Flurl.Http;

namespace eVehicleDealership.WinUI
{
    public class APIService
    {
        public static string Token { get; set; }
        private readonly string _route;

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {

            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            if (search != null)
            {
                url += "?" + await search.ToQueryString();
            }

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}";

            return await url.WithOAuthBearerToken(Token).PostJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{Properties.Settings.Default.APIUrl}/{_route}/{id}";

            return await url.WithOAuthBearerToken(Token).PutJsonAsync(request).ReceiveJson<T>();
        }
    }
}
