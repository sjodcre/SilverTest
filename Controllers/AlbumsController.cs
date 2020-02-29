using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SilverTest.API.Controllers.ActionFilters;

namespace SilverTest.API.Controllers
{
    [TypeFilter(typeof(ValidateAuthHeaderAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            using (var client = new HttpClient())
            {
            var uri = new Uri("https://jsonplaceholder.typicode.com/albums");

            var response = await client.GetAsync(uri);

            string textResult = await response.Content.ReadAsStringAsync();
            return Ok(textResult);
            }
            
        }
    }
}