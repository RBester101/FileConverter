using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSVFileConverter;
using System.Collections.Generic;

namespace FileConverterTest
{
    [TestClass]
    public class FileProcessingTests
    {
        [TestMethod]
        public void SortNameCount()
        {
            Form1 form = new Form1();
            form.FileDirectory = @"C:\MyDev\";

            List<PersonDetails> persons = new List<PersonDetails>();

            persons.Add(new PersonDetails
            {
                FirstName = "John",
                LastName = "Smith",
                Address = "22 Street",
                PhoneNumber = "412346546"
            });

            persons.Add(new PersonDetails
            {
                FirstName = "Pete",
                LastName = "John",
                Address = "2 Road",
                PhoneNumber = "123454"
            });

            persons.Add(new PersonDetails
            {
                FirstName = "Sam",
                LastName = "Smith",
                Address = "556 Baker Street",
                PhoneNumber = "99999999"
            });

            form.NameCountSorted(persons);

            //Assert
            Assert.IsTrue(form.FileCreated);
        }

        [TestMethod]
        public void SortAddress()
        {
            Form1 form = new Form1();
            form.FileDirectory = @"C:\MyDev\";

            List<PersonDetails> persons = new List<PersonDetails>();

            persons.Add(new PersonDetails
            {
                FirstName = "John",
                LastName = "Smith",
                Address = "22 Street",
                PhoneNumber = "412346546"
            });

            persons.Add(new PersonDetails
            {
                FirstName = "Pete",
                LastName = "John",
                Address = "2 Road",
                PhoneNumber = "123454"
            });

            persons.Add(new PersonDetails
            {
                FirstName = "Sam",
                LastName = "Smith",
                Address = "556 Baker Street",
                PhoneNumber = "99999999"
            });

            form.AddressSorted(persons);

            //Assert
            Assert.IsTrue(form.FileCreated);
        }
    }
}
