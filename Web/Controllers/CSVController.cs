using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Core;
using Service;

namespace Web.Controllers
{
    public class CSVController : ApiController
    {
        private readonly ICSVParserService csvParserService;

        //public CSVController(ICSVParserService csvParserService) // TODO: uncomment when IOC in place
        //{
        //    this.csvParserService = csvParserService;
        //}

        public CSVController() //TODO: remove this once IOC is implemented.
        {
            this.csvParserService = new CSVParserService(new FileUploadHandler(new MultipartFileStreamProvider("../temp")), new CSVReader());
        }

        [HttpPost]
        [Route("file/upload")]
        public async Task UploadFile()
        {
            await csvParserService.ReadData(Request);

        }

        [HttpGet]
        [Route("items")]
        public List<Item> GetItems() //TODO: get values from database using service
        {
            var item1 = new Item()
            {
                FirstName = "Aleshia",
                LastName = "Tomkiewicz",
                CompanyName = "Alan D Rosenburg Cpa Pc",
                Address = "14 Taylor St",
                City = "St. Stephens Ward",
                County = "Kent",
                Postal = "CT2 7PP",
                Phone1 = "01835-703597",
                Phone2 = "01944-369967",
                Email = "atomkiewicz@hotmail.com",
                Web = "http://www.alandrosenburgcpapc.co.uk"
            };


            var item2 = new Item()
            {
                FirstName = "Evan",
                LastName = "Zigomalas",
                CompanyName = "Cap Gemini America",
                Address = "5 Binney St",
                City = "Abbey Ward",
                County = "Buckinghamshire",
                Postal = "HP11 2AX",
                Phone1 = "01937-864715",
                Phone2 = "01714-737668",
                Email = "evan.zigomalas@gmail.com",
                Web = "http://www.capgeminiamerica.co.uk"
            };

            return new List<Item> {item1, item2};
        }
    }
}
