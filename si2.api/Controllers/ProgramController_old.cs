
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;


namespace si2.api.Controllers
{
	//[ApiController]
	//[Route("api/program")]
	//public class ProgramController_old : ControllerBase
	//{
        // Write a log message and create logging scopes
        //private readonly ILogger<ProgramController> _logger = null;

        // Example of programs (testing purposes)
        /*private static readonly string[] currentPrograms = new[]
        {
            "Informatique Appliquée aux Entreprises", "Marketing et Publicité", "Management Hôtlier et Arts Culinaires"
        };*/
       // private ArrayList currentPrograms = null;

        // Initialize class object(s)
       /* public ProgramController(ILogger<ProgramController> logger)
        {
            _logger = logger;
            currentPrograms = new ArrayList() {

                "Informatique Appliquée aux Entreprises", 
                "Marketing et Publicité", 
                "Management Hôtlier et Arts Culinaires"
           };

        }

        // Request list of current programs data 
        [HttpGet]
        public String GetPrograms()
        {
            Console.WriteLine("Current List of Programs :");

            for (int p = 0; p < currentPrograms.Count; p++)
            {

                Console.WriteLine("-" + currentPrograms[p]);

            }
            return null;
        }

        // Post a new program
        [HttpPost]
        public String SetPrograms(String aprogram)
        {

            if (!currentPrograms.Contains(aprogram))
            {

                currentPrograms.Add(aprogram);
                Console.WriteLine("Program added !");
               return GetPrograms();
            }
              
            else
            {
                Console.WriteLine("Program already exist !");
                return null;
            }
        }*/

    //}

}
