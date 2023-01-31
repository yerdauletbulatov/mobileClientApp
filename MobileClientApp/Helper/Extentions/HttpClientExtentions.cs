using MobileClientApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MobileClientApp.Models.Values;

namespace MobileClientApp.Helper.Extentions
{
    public static class HttpClientExtentions
    {
        private static HttpClient HttpClient { get; set; }

        public static async Task<TModel> ResponseDataPostAsync<TModel>(this HttpClient httpClient, string uri, TModel model = default)
        {
            HttpClient = httpClient;
            var response = await HttpClient
                .SetHeader()
                .PostAsync(uri, JsonConvert(model));
            return await Actions(uri, model, response);
        }

        private static async Task<TModel> Actions<TModel>(string uri, TModel model, HttpResponseMessage response)
            => response.StatusCode switch
            {
                HttpStatusCode.OK => await GetJsonDataAsync<TModel>(response),
                HttpStatusCode.NoContent => default,
                HttpStatusCode.Unauthorized => await RefreshAccessTokenAsync(uri, model),
                _ => throw new Exception(await response.Content.ReadAsStringAsync())
            };

        private static async Task<TModel> RefreshAccessTokenAsync<TModel>(string uri, TModel model)
        {
            var responseToken = await HttpClient.PostAsync(API.RefreshAccess, JsonConvert(new JWT(Preferences.Get(nameof(JWT.RefreshToken), string.Empty))));
            var  token = await GetJsonDataAsync<JWT>(responseToken) 
                ?? throw new Exception(await responseToken.Content.ReadAsStringAsync());
            Preferences.Set(nameof(JWT.AccessToken), token.AccessToken);
            return await HttpClient.ResponseDataPostAsync(uri, model);
        }

        private static HttpClient SetHeader(this HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get(nameof(JWT.AccessToken), string.Empty));
            return httpClient;
        }

        private static StringContent JsonConvert<TRequest>(TRequest model) => new(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");

        private static async Task<TResponse> GetJsonDataAsync<TResponse>(HttpResponseMessage response) => JsonSerializer.Deserialize<TResponse>(
            await response.Content.ReadAsStringAsync(),
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
    }
}
