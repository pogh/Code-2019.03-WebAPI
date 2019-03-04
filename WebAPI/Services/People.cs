using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Enums;

namespace WebAPI.Services
{
    public class People : IPeople
    {
        public People()
        {
            int n = 0;
            using (StreamReader reader = new StreamReader("data/people.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] col = line.Split(',');

                    _everyone.Add(new Person()
                    {
                        Id = n++,
                        LastName = col[0].Trim(),
                        Name = col[1].Trim(),
                        ZipCode = int.Parse(col[2].Substring(0, col[2].IndexOf(' '))),  //TODO: Not Efficient.  Solve in a nicer way
                        City = col[2].Substring(col[2].IndexOf(' ') + 1).Trim(),
                        Color = Enum.Parse<ColorEnum>(col[3])
                    });
                }
            }
        }

        private readonly List<Person> _everyone = new List<Person>();
        public List<Person> EveryOne
        {
            get
            {
                // Always return a copy so we can be sure different calls are not accessing same instance
                // Otherwise no guarantee that a client will use LOCK() when performing a modification to the list
                lock (_everyone)
                    return _everyone.ToList();
            }
        }

        /// <summary>
        /// Adds the specified person and persists list
        /// </summary>
        public async Task Add(Person person)
        {
            lock (_everyone)
                _everyone.Add(person);

            List<string> lines;
            lock (_everyone)
                lines = _everyone.Select(x => string.Concat(x.LastName, ",", x.Name, ",", x.ZipCode, " ", x.City, ",", (int)x.Color)).ToList();

            await File.WriteAllLinesAsync("data/people.csv", lines);
        }
    }
}
