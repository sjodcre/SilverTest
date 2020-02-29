using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SilverTest.API.Controllers.ActionFilters;

namespace SilverTest.API.Controllers
{
    [TypeFilter(typeof(ValidateAuthHeaderAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetCollections()
        {
            List<Dictionary<string, string>> posts = new List<Dictionary<string, string>>();
            Random rnd = new Random();
            var postsUri = new Uri("https://jsonplaceholder.typicode.com/posts/");
            var usersUri = new Uri("https://jsonplaceholder.typicode.com/users/");
            var albumsUri = new Uri("https://jsonplaceholder.typicode.com/albums/");
            string postsResult,usersResult,albumsResult,collectionsResult="";
            using (var client = new HttpClient())
            {            
                var response1 = await client.GetAsync(postsUri);
                postsResult = await response1.Content.ReadAsStringAsync();
                var response2 = await client.GetAsync(usersUri);
                usersResult = await response2.Content.ReadAsStringAsync();
                var response3 = await client.GetAsync(albumsUri);
                albumsResult = await response3.Content.ReadAsStringAsync();
            }
                JArray postsObj = (JArray)JsonConvert.DeserializeObject(postsResult);
                JArray usersObj = (JArray)JsonConvert.DeserializeObject(usersResult);
                JArray albumsObj = (JArray)JsonConvert.DeserializeObject(albumsResult);

                // JObject item = new JObject();
                for(int i =0;i<30;i++) {
                    JObject item = new JObject();
                    item.Add(new JProperty("post", postsObj[rnd.Next(100)]));
                    item.Add(new JProperty("album", albumsObj[rnd.Next(100)]));
                    item.Add(new JProperty("user", usersObj[rnd.Next(10)]));
                    // postsResult = item.ToString();
                    if(i==0){
                        collectionsResult += item.ToString();
                    } else {
                        collectionsResult += ',' + item.ToString();
                    }
                }
            // collectionsResult = postsResult + ','+ usersResult +','+ albumsResult;
            return Ok('['+ collectionsResult+']');
            
        }
    }
}