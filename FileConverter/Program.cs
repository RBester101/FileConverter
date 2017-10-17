using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var personDetails = File.ReadAllLines().Skip(1).ToList();
        }
    }

    class PersonDetails
    {
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;

        public static PersonDetails CreateObjects(string fileLine)
        {
            List<string> stringArray = fileLine.Split().ToList();
            var personDetails = new PersonDetails
            {
                firstName = stringArray[0],
                lastName = stringArray[1],
                address = stringArray[2],
                phoneNumber = stringArray[3]
            };
            
            return personDetails;
        }
    }
}
