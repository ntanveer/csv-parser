using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core;
using Service;
using TechXplorers.ArgumentValidation;
using System.IO;

namespace Service
{
    public interface ICSVParserService
    {
        Task<List<Item>> ReadData(HttpRequestMessage request);
    }

    public class CSVParserService : ICSVParserService
    {
        private readonly IFileUploadHandler fileUploadHandler;
        private readonly ICSVReader csvReader;

        public CSVParserService(IFileUploadHandler fileUploadHandler, ICSVReader csvReader) //TODO: use IOC
        {
            this.fileUploadHandler = fileUploadHandler;
            this.csvReader = csvReader;
        }

        public async Task<List<Item>> ReadData(HttpRequestMessage request)
        {
            Check
                .That(() => request).IsNotNull();

            var filePath = await fileUploadHandler.UploadAsync(request);
            var parsedLines = new List<string[]>();

            using (var streamReader = File.OpenText(filePath))
            {
                var line = string.Empty;
                while (true)
                {
                    line = await streamReader.ReadLineAsync();
                    if (line == null)
                        break;

                    parsedLines.Add(csvReader.ParseLine(line));
                }
            }

            return parsedLines.Skip(1).Select(line => new Item
            {
                FirstName = line[0],
                LastName = line[1],
                CompanyName = line[2],
                Address = line[3],
                City = line[4],
                County = line[5],
                Postal = line[6],
                Phone1 = line[7],
                Phone2 = line[8],
                Email = line[9],
                Web = line[10]
            }).ToList(); //TODO: persist data in database
        }
    }
}
