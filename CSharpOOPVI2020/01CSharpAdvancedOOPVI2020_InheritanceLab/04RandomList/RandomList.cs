using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, this.Count);
            string randomString = this[randomIndex];
            this.RemoveAt(randomIndex);

            return randomString;
        }
    }
}