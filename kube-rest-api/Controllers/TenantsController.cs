using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kube.RestApi.Models;

namespace Kube.RestApi
{
    [Route("api/[controller]")]
    public class TenantsController : Controller
    {
        // GET api/tenants
        [HttpGet]
        public IEnumerable<Tenant> Get()
        {
            return new Tenant[]
            {
                new Tenant
                {
                    Name = "tenant1",
                    Endpoints = new Endpoints
                    {
                        Minecraft = "10.10.10.10:25565",
                        Rcon = "10.10.10.10:25575"
                    }
                }
            };
        }
    }
}
