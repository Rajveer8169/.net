using Microsoft.AspNetCore.SignalR;

namespace PracticeAdoNet
{
    public static class ConnectionString
    {
        private static string cs = "Server=LAPTOP-9PKS1DJ7; Database=CrudADOdb; Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True;";
        public static string dbcs { get { return cs; } }
    }
}
