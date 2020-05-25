using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForACarRace
{
    class CarRace
    {
        public string FirstNameOfTheCompetitor { get; set; }
        public string LastNameOfTheCompetitor { get; set; }
        public string CarBrand { get; set; }
        public double VehicleWeight { get; set; }
        public int Horsepower { get; set; }
        public string Boost { get; set; }
        public Dictionary<string, int> FirstNameOfTheCompetitorAndPoints { get; set; }
        public int AllPoints
        {
            get
            {
                return this.FirstNameOfTheCompetitorAndPoints.Sum(x => x.Value);
            }
        }
        public CarRace()
        {
            this.FirstNameOfTheCompetitorAndPoints = new Dictionary<string, int>();
        }
        public override string ToString()
        {
            return $"{this.FirstNameOfTheCompetitor} - {this.AllPoints} points";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter details for the competitor:");
            Console.WriteLine("First name -> Last name -> Car brand -> Vehicle weight -> Horsepower -> BOOST:");
            List<CarRace> carracer = new List<CarRace>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] data = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Trim()).ToArray();
                string firstname = data[0];
                string lastname = data[1];
                string carbrand = data[2];
                double vehicleweight = double.Parse(data[3]);
                int horsepower = int.Parse(data[4]);
                string boost = data[5];
                int points = 0;
                CarRace r = carracer.Where(rac => rac.FirstNameOfTheCompetitor.Equals(firstname)).FirstOrDefault();
                if (r == null)
                {
                    r = new CarRace() { FirstNameOfTheCompetitor = firstname, LastNameOfTheCompetitor = lastname, CarBrand = carbrand, VehicleWeight = vehicleweight, Horsepower = horsepower, Boost = boost };
                    r.FirstNameOfTheCompetitorAndPoints.Add(firstname, points);
                    carracer.Add(r);
                    if (boost == "do-100")
                    {
                        double acceleration = (1 / (horsepower) * 1000 / 2) - (0.30 * 100);
                    }
                    else if (boost == "do-200")
                    {
                        double acceleration = (1 / (horsepower) * 1000) - (0.20 * 100);
                    }
                    else
                    {
                        double acceleration = (1 / (horsepower) * 1000);
                    }

                }


                foreach (CarRace carRacer in carracer.OrderByDescending(x => x.AllPoints))
                {
                    Console.WriteLine(carRacer.ToString());
                }
                Console.ReadLine();
            }
        }
    }
}

 

