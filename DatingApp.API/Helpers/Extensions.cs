using Microsoft.AspNetCore.Http;

namespace DatingApp.API.Helpers
{
    public static class Extensions
    {
        /* Static means we don't need to create a new instance (object) of the Extensions class
        int order to use its methods */
        // General purpose Extension class

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            // First parameter is header, others after are the messages
            response.Headers.Add("Application-Error", message);
            // Add CORS headers
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}