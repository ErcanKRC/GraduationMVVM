
using GraduationMVVM.MVVM.Models;

namespace GraduationMVVM.Services
{
    public class BlynkService
    {
        private static BlynkService _instance = null;
        public static BlynkService Instance { get => _instance ??= new BlynkService(); }
        private BlynkService()
        {

        }

        private HttpClient client;
        private HttpResponseMessage response;
        public async Task<bool> GetDeviceStatus(SelectedDevice device)
        {
            try
            {
                response = new HttpResponseMessage();
                string getStatusReq = "external/api/isHardwareConnected?token=" + device.Token;
                response = await client.GetAsync(getStatusReq);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result == "true")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }
        public async Task<string> GetDataStreamValue(DevicesModel device, int StreamID)
        {
            try
            {
                response = new HttpResponseMessage();
                string GetDataReq = "external/api/get?token=" + device.Token + "&dataStreamId=" + StreamID;
                response = await client.GetAsync(GetDataReq);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    return result;
                }
                else
                {
                    return "Request failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task UpdateDatastreamValue(SelectedDevice device, int StreamID, int Value)
        {
            try
            {
                response = new HttpResponseMessage();
                string UpdateReq = "external/api/update?token=" + device.Token + "&dataStreamId=" + StreamID + "&value=" + Value;
                response = await client.GetAsync(UpdateReq);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public void SetBaseAddress(string Server)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Server);
        }
    }
}
