using System;
using OrchestraLib;


namespace OrchestraListConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrchestraRepository orchestra_repo = new SqlOrchestraRepository();
            var results = orchestra_repo.ReadAll();
            foreach (Orchestra orchestra in results) {
                Console.WriteLine("Id: "+ orchestra.Id);
                Console.WriteLine("Name: "+ orchestra.Name);
                Console.WriteLine("Address Line 1 : "+ orchestra.AddressLine1);
                Console.WriteLine("Address Line 2 : "+ orchestra.AddressLine2);
                Console.WriteLine("City : "+ orchestra.City);
                Console.WriteLine("State : "+ orchestra.State);
                Console.WriteLine("Zip Code : "+ orchestra.ZipCode);
                Console.WriteLine("Website URL : "+ orchestra.WebsiteURL);
                Console.WriteLine("---------------------------");
            }; 
        }
    }
}
