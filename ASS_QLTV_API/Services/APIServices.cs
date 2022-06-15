using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ASS_QLTV_API.Models;
using Newtonsoft.Json;

namespace ASS_QLTV_API.Services
{
    public class APIServices
    {
        public string GetDataFromAPI(string uri, string requestUri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var jsonConnect = client.GetAsync(requestUri).Result;
                string jsonData = jsonConnect.Content.ReadAsStringAsync().Result;
                return jsonData;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public int PostUser(string uri, Taikhoan tk)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(tk);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostDocGia(string uri, Docgium docgium)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(docgium);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostSach(string uri, Sach sach)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(sach);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostPhieuMuon(string uri, Phieumuon phieumuon)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(phieumuon);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int PostPhieuMuon(string uri, Ctpm ctpm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            try
            {
                var newPostJson = JsonConvert.SerializeObject(ctpm);
                var payLoad = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(uri, payLoad).Result.Content.ReadAsStringAsync().Result;
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public int Login(string username, string password)
        {
            try
            {
                var data= GetDataFromAPI("https://localhost:44301/", "api/Taikhoans");
                List<Taikhoan> accList = JsonConvert.DeserializeObject<List<Taikhoan>>(data);
                var acc = accList.FirstOrDefault(acc => acc.User == username && acc.Password == password);
                if (acc is {PhanQuyen: 1})
                {
                    return 1;
                }
                else if(acc is { PhanQuyen: 2})
                {
                    return 0;
                }
                return -1;
            }
            catch (Exception )
            {
                return -1;
            }
        }

    }
}
