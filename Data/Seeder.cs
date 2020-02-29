using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
// using EFCoreWebAPI;
using Newtonsoft.Json;
using JsonNet.ContractResolvers;
using SilverTest.API.Models;

namespace SilverTest.API.Data
{
    public class Seeder
    {
        public static void Seedit(string jsonData,
                            IServiceProvider serviceProvider) {
            JsonSerializerSettings settings = new JsonSerializerSettings {
                ContractResolver = new PrivateSetterContractResolver()
            };
            List<Post> events =
            JsonConvert.DeserializeObject<List<Post>>(
                jsonData, settings);
            using (
            var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                            .ServiceProvider.GetService<DataContext>();
                if (!context.Posts.Any()) {
                context.AddRange(events);
                context.SaveChanges();
                }
            }
        }
    }
}