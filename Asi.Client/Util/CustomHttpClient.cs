using Asi.Client.Util.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asi.Client.Util
{


    public class CustomHttpClient : ICustomHttpClient
    {
        private readonly Uri _baseAddress;
        private string _route;
        public CustomHttpClient()
        {
            _baseAddress = new Uri("http://2.186.12.95/asiserver/api/");
           // _baseAddress = new Uri("http://192.168.0.104/AsiServer/api/");

        }


        async Task ICustomHttpClient.Delete(int id, string uri,int version)
        {
            HttpClient hc = new HttpClient
            {
                MaxResponseContentBufferSize = int.MaxValue,
            };
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            hc.BaseAddress = this._baseAddress;
            HttpResponseMessage hrm = await hc.DeleteAsync("V" + version.ToString() + "/" + _route + "/" + id).ConfigureAwait(false);
            if (hrm.StatusCode == System.Net.HttpStatusCode.OK)
            {
                hc.Dispose();
            }
            else
            {
                var msg = await hrm.Content.ReadAsStringAsync();
                hc.Dispose();
                throw new Exception(msg);
            }
        }

        async Task<Tout> ICustomHttpClient.Get<Tout>(string uri, int version)
        {
            Tout res;
            HttpClient hc = new HttpClient
            {
                MaxResponseContentBufferSize = int.MaxValue,
            };
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            hc.BaseAddress = this._baseAddress;
            HttpResponseMessage hrm = await hc.GetAsync("V" + version.ToString() + "/" + _route +"/"+ uri).ConfigureAwait(false);
            var x = hrm.RequestMessage;
            if (hrm.StatusCode == System.Net.HttpStatusCode.OK)
            {

                string result = await hrm.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<Tout>(result);
                hc.Dispose();
                return res;
            }
            else
            {
                var msg = await hrm.Content.ReadAsStringAsync();
                hc.Dispose();
                throw new Exception(msg);
            }
        }

       async Task<int> ICustomHttpClient.Get(string uri, int version)
        {
            int res = 0;
            HttpClient hc = new HttpClient
            {
                MaxResponseContentBufferSize = int.MaxValue,
            };
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            hc.BaseAddress = this._baseAddress;
            HttpResponseMessage hrm = await hc.GetAsync("V" + version.ToString() + "/" + _route + "/" + uri).ConfigureAwait(false);
            if (hrm.StatusCode == System.Net.HttpStatusCode.OK)
            {

                string result = await hrm.Content.ReadAsStringAsync();
                res = JsonConvert.DeserializeObject<int>(result);
                hc.Dispose();
                return res;
            }
            else
            {
                var msg = await hrm.Content.ReadAsStringAsync();
                hc.Dispose();
                throw new Exception(msg);
            }
        }

        async Task<TOut> ICustomHttpClient.Post<TIn, TOut>(TIn model, string uri, int version)
        {
            try
            {
                TOut res;
                HttpClient hc = new HttpClient
                {
                    MaxResponseContentBufferSize = int.MaxValue,
                };
                hc.DefaultRequestHeaders.Accept.Clear();
                hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                hc.BaseAddress = this._baseAddress;
                string requst = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(requst, Encoding.UTF8, "application/json");

                HttpResponseMessage hrm = await hc.PostAsync("V"+version.ToString()+"/"+_route + "/" + uri, stringContent).ConfigureAwait(false);
                if (hrm.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string result = await hrm.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<TOut>(result);
                    hc.Dispose();
                    return res;
                }
                else
                {
                    var msg = await hrm.Content.ReadAsStringAsync();
                    hc.Dispose();
                    throw new Exception(msg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task ICustomHttpClient.Post<TIn>(TIn model, string uri, int version)
        {
            HttpClient hc = new HttpClient
            {
                MaxResponseContentBufferSize = int.MaxValue,
            };
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            hc.BaseAddress = this._baseAddress;
            string requst = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(requst, Encoding.UTF8, "application/json");
            HttpResponseMessage hrm = await hc.PostAsync("V" + version.ToString() + "/" + _route + "/" + uri, stringContent).ConfigureAwait(false);
            var x = hrm.RequestMessage;
            var v = hrm.ReasonPhrase;
            var y = hrm.Content;
            if (hrm.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await hrm.Content.ReadAsStringAsync();
                hc.Dispose();
            }
            else
            {
                var msg = await hrm.Content.ReadAsStringAsync();
                hc.Dispose();
                throw new Exception(msg);
            }
        }

        async Task ICustomHttpClient.Put<TIn>(TIn model, string uri, int version)
        {
            HttpClient hc = new HttpClient
            {
                MaxResponseContentBufferSize = int.MaxValue,
            };
            hc.DefaultRequestHeaders.Accept.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            hc.BaseAddress = this._baseAddress;
            string requst = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(requst, Encoding.UTF8, "application/json");
            HttpResponseMessage hrm = await hc.PutAsync("V" + version.ToString() + "/" + _route + "/" + uri, stringContent).ConfigureAwait(false);
            if (hrm.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string result = await hrm.Content.ReadAsStringAsync();
                hc.Dispose();
            }
            else
            {
                var msg = await hrm.Content.ReadAsStringAsync();
                hc.Dispose();
                throw new Exception(msg);
            }
        }

        void ICustomHttpClient.SetRoute(string route)
        {
            this._route = route;
        }
    }
}
