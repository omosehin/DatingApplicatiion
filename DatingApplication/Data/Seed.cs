using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using DatingApplication.Models;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DatingApplication.Data
{
    public class Seed
    { 
        public static async Task  SeedUsers(DataContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var userData = File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);  //convert to user object
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "password");
                }
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
