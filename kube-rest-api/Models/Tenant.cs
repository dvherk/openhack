namespace Kube.RestApi.Models
{

    public class Tenant
    {
        public string Name { get; set; }
        public Endpoints Endpoints { get; set; }
    }

    public class Endpoints
    {
        public string Minecraft { get; set; }
        public string Rcon { get; set; }
    }
}
