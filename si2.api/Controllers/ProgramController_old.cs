
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;


namespace si2.api.Controllers
{

   // [ApiController]
    //[Route("api/program")]
    //[Route("[controller]")]
    //[Route("api/program")]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //public class ProgramController : ControllerBase
   // {
        // private readonly LinkGenerator _linkGenerator;
       // private readonly Microsoft.Extensions.Logging.ILogger<ProgramController> _logger;
        // private readonly IProgramService _programService;
       /* private static readonly string[] currentPrograms = new[] {

                "Informatique Appliquée aux Entreprises",
                "Marketing et Publicité",
                "Management Hôtlier et Arts Culinaires"
           };*/


        /*public ProgramController(LinkGenerator linkGenerator, Microsoft.Extensions.Logging.ILogger<ProgramController> logger, IProgramService programService)
        {
            _linkGenerator = linkGenerator;
            _logger = logger;
            _programService = programService;
        }*/

       /* public ProgramController(Microsoft.Extensions.Logging.ILogger<ProgramController> logger)
        {
            _logger = logger;

        }*/


        // Request list of current programs data 
        /* [HttpGet]
         public string Get()
         {
             Console.WriteLine("Current List of Programs :");

             /* for (int p = 0; p < currentPrograms.Count; p++)
              {

                   Console.WriteLine("-" + currentPrograms[p]);

               }
               return null;
             //return currentPrograms.ToArray().ToString();

             //PrintPrograms(currentPrograms);

             return currentPrograms.ToString();

         }*/

       /* [HttpGet]
        public IEnumerable<Programs> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 3).Select(index => new Programs
            {
                Date = DateTime.Now.AddDays(index),
                range = rng.Next(0, 10),
                title = currentPrograms[rng.Next(currentPrograms.Length)]
            })
            .ToArray();
        }*/


















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
