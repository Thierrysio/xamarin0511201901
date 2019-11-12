using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xamarin0511201901.Modeles;

namespace xamarin0511201901.Services
{
    class ApiAuthentification
    {
        public async Task GetAuthAsync(string userName, string password)
        {
            User modelData = new User(userName, password);
            var jsonstring = JsonConvert.SerializeObject(modelData);

            var client = new HttpClient();

            var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Constantes.BaseApiAddress + "api/login_check", jsonContent);

            var content = await response.Content.ReadAsStringAsync();

            //Tokens token = JsonConvert.DeserializeObject<Tokens>(content);

            //string letoken = token.Token;

            /*try
            {
                await SecureStorage.SetAsync("token", letoken);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }

            try
            {
                letoken = await SecureStorage.GetAsync("token");


            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
            */



        }

    }
}
