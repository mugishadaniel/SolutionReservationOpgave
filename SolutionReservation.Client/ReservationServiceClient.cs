using SolutionReservation.API.DTO.Input;
using SolutionReservation.API.MapperDTO;
using SolutionReservation.Client.UseroutputDTOs;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Client
{
    public class ReservationServiceClient
    {
        private HttpClient client;

        public ReservationServiceClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5126/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<UseroutputDTO> GetUserAsync(string path)
        {
            UseroutputDTO user = null;
            HttpResponseMessage response = await client.GetAsync("api/User/"+path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UseroutputDTO>();

                return user;
            }
            return null;
        }

        public async Task<UseroutputDTO> AddUserAsync(UserInputDTO user)
        {
            UseroutputDTO useroutputDTO = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("api/User", user);
            if (response.IsSuccessStatusCode)
            {
                useroutputDTO = await response.Content.ReadAsAsync<UseroutputDTO>();
                return useroutputDTO;
            }
            return null;
        }
    }
}
