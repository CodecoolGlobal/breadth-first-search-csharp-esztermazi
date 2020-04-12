using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            var user1 = users.ElementAt(25).Friends.ElementAt(0);
            var user2 = users.ElementAt(25).Friends.ElementAt(1);
            Console.WriteLine("Done");
            Console.WriteLine($"Get distance between: " +
                $"{ user1.FirstName} { user1.LastName } " +
                $"and { user2.FirstName} { user2.LastName}");
            Console.WriteLine($"distance is: { generator.GetDistanceLevel(user1, user2)}");
            Console.ReadKey();
        }
    }
}
