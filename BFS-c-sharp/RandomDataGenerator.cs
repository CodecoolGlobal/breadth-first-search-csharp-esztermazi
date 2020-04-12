using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BFS_c_sharp
{
    public class RandomDataGenerator
    {
        private Random rng = new Random(1234);
        private String[] firstNames = {
            "Inez", "Emery", "Virginia", "Charissa", "Tyrone", "Ayanna", "Jena", "Ora",
            "Cooper", "Gareth", "Karleigh", "Aladdin", "Arden", "Pearl", "Mariko", "Hadley",
            "Tanya", "Madeline", "Naomi", "Maggie", "Kerry", "Elmo", "Wylie", "Alec",
            "Axel", "Belle", "Cally", "Theodore", "Emmanuel", "Christopher", "Olympia"};

        private String[] lastNames =  {
            "Winifred", "Tanner", "Rajah", "Cedric", "Tyler", "Nicholas", "Abra", "Aurora",
            "Bryar", "Kibo", "Myles", "Hillary", "Lydia", "Dolan", "Lucian", "Prescott"
        };

        public List<UserNode> Generate()
        {
            List<UserNode> users = new List<UserNode>();
            UserNode firstUser = GenerateNewUser();
            users.Add(firstUser);
            // first generate and connect users in a star shaped tree
            GenerateTree(firstUser, users, 4);

            for (int i = 0; i < users.Count - 30; i++)
            {
                if (i % 5 == 0)
                {
                    var friendUser = users[i + 30];
                    users[i].AddFriend(friendUser);
                }
            }

            return users;
        }

        private void GenerateTree(UserNode user, List<UserNode> allUsers, int depth)
        {
            if (depth == 0)
            {
                return;
            }
            for (int i = 0; i < depth; i++)
            {
                UserNode newUser = GenerateNewUser();
                user.AddFriend(newUser);
                allUsers.Add(newUser);
                GenerateTree(newUser, allUsers, depth - 1);
            }
        }

        private UserNode GenerateNewUser()
        {
            return new UserNode(GetRandomElement(firstNames), GetRandomElement(lastNames));
        }

        private string GetRandomElement(string[] array)
        {
            return array[rng.Next(array.Length)];
        }

        public int GetDistanceLevel(UserNode user1, UserNode user2)
        {
            // Breadth First Search
            var personToView = user1;
            var personToFind = user2;
            Dictionary<UserNode, int> distance = new Dictionary<UserNode, int>();
            Queue<UserNode> queue = new Queue<UserNode>();
            distance[personToView] = 0;
            queue.Enqueue(personToView);

            while (queue.Count > 0 && !distance.ContainsKey(personToFind))
            {
                personToView = queue.Dequeue();
                var friendList = personToView.Friends;

                foreach (var friend in friendList)
                {
                    if (!distance.ContainsKey(friend))
                    {
                        distance[friend] = distance[personToView] + 1;
                        queue.Enqueue(friend);
                    }

                }

            }
            if (!distance.ContainsKey(personToFind)) return -1;
            return distance[user2];

        }

        public HashSet<UserNode> GetFriendsOfLevel(UserNode user1, int distanceLevel)
        {
            // Breadth First Search
            var personToView = user1;
            Dictionary<UserNode, int> distance = new Dictionary<UserNode, int>();
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<UserNode> result = new HashSet<UserNode>();
            distance[personToView] = 0;
            queue.Enqueue(personToView);

            while (queue.Count > 0)
            {
                personToView = queue.Dequeue();
                var friendList = personToView.Friends;

                foreach (var friend in friendList)
                {
                    if (!distance.ContainsKey(friend) && distance[personToView] != distanceLevel)
                    {
                        distance[friend] = distance[personToView] + 1;
                        queue.Enqueue(friend);
                        result.Add(friend);
                    }

                }
            }

            return result;
        }

    }
}