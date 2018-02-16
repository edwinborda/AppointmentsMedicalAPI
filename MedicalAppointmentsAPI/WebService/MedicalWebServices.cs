using RestSharp;


namespace MedicalAppointmentsAPI.WebService
{
    public static class MedicalWebServices
    {
        private static RestClient client = new RestClient("http://pruebas.apimedic.personalsoft.net:8082/api/v1/");

        public static bool ExistsPatient(int id)
        {
            var request = new RestRequest($"patients/{id}", Method.GET);

            return client.Execute(request).StatusCode == System.Net.HttpStatusCode.OK;
        }

        public static bool ExistsDoctor(int id)
        {
            var request = new RestRequest($"doctors/{id}", Method.GET);

            return client.Execute(request).StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}