using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSVFileConverter
{
    public partial class Form1 : Form
    {
        public string FileDirectory { get; set; }
        public bool FileCreated { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> nameList = new List<string>();
            
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                FileDirectory = Path.GetDirectoryName(filePath);

                var personDetails = File.ReadAllLines(filePath).Skip(1).Select(s => PersonDetails.CreateObjects(s)).ToList();

                //var nameCount = NameCountSorted(personDetails).OrderBy(p => p.Key).OrderByDescending(o => o.Value);

                NameCountSorted(personDetails);

                AddressSorted(personDetails);
                
            }
        }

        public void NameCountSorted(List<PersonDetails> personDetails)
        {
            var sb = new StringBuilder();

            var returnList = new List<KeyValuePair<string, int>>();

            var tempList = new List<string>();
            foreach (var person in personDetails)
            {
                tempList.Add(person.FirstName);
                tempList.Add(person.LastName);
            }

            var list = tempList.GroupBy(g => g);

            foreach (var item in list)
            {
                returnList.Add(new KeyValuePair<string, int>(item.Key, item.Count()));
            }

            //return returnList;
            var newList = returnList.OrderBy(p => p.Key).OrderByDescending(o => o.Value);

            foreach (var item in newList)
            {
                sb.Append(string.Format("{0}, {1}{2}", item.Key, item.Value, Environment.NewLine));
            }

            WriteToTxt(sb.ToString(), "NameCountSorted.txt");
        }

        public void AddressSorted(List<PersonDetails> personList)
        {
            var sb = new StringBuilder();

            var addressList = personList.OrderBy(a => a.Address.Substring(a.Address.IndexOf(' '))).Select(s=> s.Address).ToList();

            foreach (var item in addressList)
            {
                sb.Append(item + Environment.NewLine);
            }
            
            WriteToTxt(sb.ToString(), "AddressSorted.txt");
        }

        private void WriteToTxt(string text, string filename)
        {
            try
            {
                File.WriteAllText(Path.Combine(FileDirectory, filename), text);
                FileCreated = true;
            }
            catch (Exception ex)
            {
                FileCreated = false;
                throw ex;
            }
        }
    }

    public class PersonDetails
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;

        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        public static PersonDetails CreateObjects(string fileLine)
        {
            List<string> stringArray = fileLine.Split(',').ToList();
            var personDetails = new PersonDetails
            {
                FirstName = stringArray[0],
                LastName = stringArray[1],
                Address = stringArray[2],
                PhoneNumber = stringArray[3]
            };

            return personDetails;
        }
    }
}
