using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stories.Api.Model;

namespace Stories.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Address>>> Get()
        {
            var result = await Task.Run(() => GetAddress());

            return result;
        }

        private List<Address> GetAddress()
        {
            List<Address> list = new List<Address>();
            list.Add(new Address { City = "Ikebukuro", Country = "Japan", Others = "池袋", Street = "" });
            list.Add(new Address { City = "Tokorozawa", Country = "Japan", Others = "所沢", Street = "プロペ通り" });
            return list;

        }
    }
}
