using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab11_MyFirstMVCApp.Models
{
    public class TimePerson
    {
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        /// <summary>
        /// pass in two prameters and return a list as result
        /// </summary>
        /// <param name="beginYear"></param>
        /// <param name="endYear"></param>
        /// <returns>a list of TimePerson based on the query</returns>


        public static List<TimePerson> GetPersons(int beginYear,int endYear)
        {
            List<TimePerson> people = new List<TimePerson>();
            //readfile      

    // string filepath=@"C:\Users\xialiu\codefellows401\Lab11-firstMVC\lab11-MyFirstMVCApp\lab11-MyFirstMVCApp\wwwroot\personOfTheYear.csv";

  string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/personOfTheYear.csv");
            //skip the first line because there is no informatioh in the fisrt line just titles. start searching from second line
        var lines = File.ReadAllLines(filepath).Skip(1);

            //iterate through that array and set the values appropriatly to a new timeperson object
            //create the full list of peoples from the cvs file
            foreach (var item in lines)
            {
                string[] columns = item.Split(',');
                TimePerson tp = new TimePerson();
                tp.Year = (columns[0]==""?0:Convert.ToInt32(columns[0]));
                tp.Honor = columns[1];
                tp.Name = columns[2];
                tp.Country = columns[3];
                tp.BirthYear=(columns[4]==""?0:Convert.ToInt32(columns[4]));
                tp.DeathYear= (columns[5]==""?0:Convert.ToInt32(columns[5]));
                tp.Title = columns[6];
                tp.Category = columns[7];
                tp.Context = columns[8];

                people.Add(tp);

            }



         

        
            //Then do the LINQ query with lamda to filter

        List<TimePerson> listofPeople = people.Where(p => (p.Year >= beginYear) && (p.Year <= endYear)).ToList();
            return listofPeople;
        }

    }
}
