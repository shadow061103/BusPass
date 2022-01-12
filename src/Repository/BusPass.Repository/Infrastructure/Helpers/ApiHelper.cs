using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net.Http;
using System.Text.Json;
using System.Net;

namespace BusPass.Repository.Infrastructure.Helpers
{
    public class ApiHelper : IApiHelper
    {
        private readonly HttpClient _client;

        private readonly IConfiguration _configuration;

        public ApiHelper(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _client = httpClientFactory.CreateClient("PFX");
            _configuration = configuration;
        }

        /// <summary>
        /// 非同步呼叫Api(無參數)
        /// </summary>
        /// <param name="uri">Api位置</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("cache-control", "no-cache");
            request.Headers.Add("content-type", "application/json");
            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error retrieving response");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        /// <summary>
        /// 非同步呼叫PTX Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public async Task<T> GetPTXAsync<T>(string uri)
        {
            var APPID = this._configuration.GetValue<string>("AppId");
            var APPKey = this._configuration.GetValue<string>("AppKey");
            string xdate = DateTime.Now.ToUniversalTime().ToString("r");
            string Signature = HMACHelper.Signature($"x-date: {xdate}", APPKey);
            var sAuth = $"hmac username=\"{APPID}\", algorithm=\"hmac-sha1\", headers=\"x-date\",signature=\"{Signature}\"";

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization", sAuth);
            request.Headers.Add("x-date", xdate);
            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error retrieving response");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        /// <summary>
        /// 非同步呼叫Api(帶參數)
        /// </summary>
        /// <param name="uri">Api位置</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T, P>(string uri, P param)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Add("cache-control", "no-cache");
            request.Headers.Add("content-type", "application/json");
            request.Content = new StringContent(JsonSerializer.Serialize(param), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error retrieving response");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        /// <summary>
        /// 非同步呼叫Api(無參數)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URL.</param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Add("cache-control", "no-cache");
            request.Headers.Add("content-type", "application/json");

            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error retrieving response");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}