using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FuelDashApp.Providers
{
    public class APIData
    {

        /// <summary>
        /// Posts the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extURL">The ext URL.</param>
        /// <param name="sendData">The send data.</param>
        /// <param name="authHeaders">if set to <c>true</c> [authentication headers].</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> PostData<T>(string extURL, object sendData, bool authHeaders = false)
        {
            T data = default(T);
            string url = string.Format("{0}{1}", APIUrlConstant.BASE_URL, extURL);
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content;
                if (sendData != null)
                {
                    var json = JsonConvert.SerializeObject(sendData);
                    content = new StringContent(json);
                }
                else
                {
                    content = new StringContent(string.Empty);
                }
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(url, content).ConfigureAwait(false);
                result.EnsureSuccessStatusCode();
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<T>(response);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                data = default(T);
            }
            return data;
        }

        /// <summary>
        /// Gets the concrete data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extURL">The ext URL.</param>
        /// <param name="authHeaders">if set to <c>true</c> [authentication headers].</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetConcreteData<T>(string extURL, bool authHeaders = true)
        {
            T data = default(T);
            string url = string.Format("{0}{1}", APIUrlConstant.BASE_URL, extURL);
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<T>(response);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                data = default(T);
            }
            return data;
        }

        /// <summary>
        /// Posts the observable data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extURL">The ext URL.</param>
        /// <param name="sendData">The send data.</param>
        /// <param name="authHeaders">if set to <c>true</c> [authentication headers].</param>
        /// <returns>Task&lt;ObservableCollection&lt;T&gt;&gt;.</returns>
        public async Task<ObservableCollection<T>> PostObservableData<T>(string extURL, object sendData, bool authHeaders = true)
        {
            ObservableCollection<T> data = default(ObservableCollection<T>);
            string url = string.Format("{0}{1}", APIUrlConstant.BASE_URL, extURL);
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content;
                if (sendData != null)
                {
                    var json = JsonConvert.SerializeObject(sendData);
                    content = new StringContent(json);
                }
                else
                {
                    content = new StringContent(string.Empty);
                }
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await client.PostAsync(url, content);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ObservableCollection<T>>(response);
                }
                else
                {
                }
            }
            catch (Exception)
            {
                data = default(ObservableCollection<T>);
            }
            return data;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extURL">The ext URL.</param>
        /// <param name="authHeaders">if set to <c>true</c> [authentication headers].</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetData<T>(string extURL, bool authHeaders = true)
        {
            T data = default(T);
            string url = string.Format("{0}{1}", APIUrlConstant.BASE_URL, extURL);
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<T>(response);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                data = default(T);
            }
            return data;
        }

        /// <summary>
        /// Gets the list data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extURL">The ext URL.</param>
        /// <param name="authHeaders">if set to <c>true</c> [authentication headers].</param>
        /// <returns>Task&lt;List&lt;T&gt;&gt;.</returns>
        public async Task<List<T>> GetListData<T>(string extURL, bool authHeaders = true)
        {
            List<T> data = default(List<T>);
            string url = string.Format("{0}{1}", APIUrlConstant.BASE_URL, extURL);
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<List<T>>(response);
                }
                else
                {
                }
            }
            catch (Exception)
            {
                data = default(List<T>);
            }
            return data;
        }

        /// <summary>
        /// Gets the observable data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extURL">The ext URL.</param>
        /// <param name="authHeaders">if set to <c>true</c> [authentication headers].</param>
        /// <returns>Task&lt;ObservableCollection&lt;T&gt;&gt;.</returns>
        public async Task<ObservableCollection<T>> GetObservableData<T>(string extURL, bool authHeaders = true)
        {
            ObservableCollection<T> data = default(ObservableCollection<T>);
            string url = string.Format("{0}{1}", APIUrlConstant.BASE_URL, extURL);
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<ObservableCollection<T>>(response);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                data = default(ObservableCollection<T>);
            }
            return data;
        }

          }
}
