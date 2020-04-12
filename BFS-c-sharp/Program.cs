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

            var user1 = users.ElementAt(1);
            var user2 = users.ElementAt(5);
            Console.WriteLine("Done");
            Console.WriteLine($"Get distance between: " +
                $"{ user1.FirstName} { user1.LastName } " +
                $"and { user2.FirstName} { user2.LastName}");

            //Get distanceLevel
            var getDistanceLevel = generator.GetDistanceLevel(user1, user2);
            Console.WriteLine($"distance is: { getDistanceLevel}");


            //Get friendsofGivenlevel
            var friendsofGivenlevel = generator.GetFriendsOfLevel(user1, 1);
            Console.WriteLine("The friendlist of a given level is:");
            foreach (var friend in friendsofGivenlevel)
            {
                Console.WriteLine(friend);
            }

            Console.ReadKey();
        }
    }
}
