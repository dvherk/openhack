using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kube.RestApi.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace Kube.RestApi
{
    [Route("api/[controller]")]
    public class TenantsController : Controller
    {
        private const string KubernetesEndpoint = "http://127.0.0.1:8001";
        private const string MinecraftLabel = "minecraft";

        private const int MinecraftPort = 25565;
        private const int RconPort = 25575;

        // GET api/tenants
        [HttpGet]
        public async Task<IEnumerable<Tenant>> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(KubernetesEndpoint);
                var response = await client.GetAsync("/api/v1/services");

                var stringResponse = await response.Content.ReadAsStringAsync();
                var serviceList = JsonConvert.DeserializeObject<ServiceList>(stringResponse);

                return serviceList.items
                    .Where(i => i.spec.selector?.app == MinecraftLabel)
                    .Select(i => new Tenant
                    {
                        Name = i.metadata.name,
                        Endpoints = new Endpoints
                        {
                            Minecraft = $"{i.status.loadBalancer.ingress.First().ip}:{MinecraftPort}",
                            Rcon = $"{i.status.loadBalancer.ingress.First().ip}:{RconPort}"
                        }
                    });
            }
        }
    }
}
