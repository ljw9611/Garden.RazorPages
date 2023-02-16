using Garden.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Json 파일을 읽어들여 컬렌션으로 변환해주는 서비스 클래스
namespace Garden.Services
{
    public class PortfolioServiceJsonFile
    {   // IWebHostEnvironment의 인스턴스는 _webHostEnvironment 된다.
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioServiceJsonFile(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }
        // (2)
        private string JsonFileName // 해당 인스턴스는 아래의 jsonFileName 의 경로 값과 동일하다.
        {
            get
            {
                //return _webHostEnvironment.WebRootPath + "\\Portfolios" + "\\Portfolios.json";
                return Path.Combine(_webHostEnvironment.WebRootPath, "Portfolios", "Portfolios.json");
            }
        }

        public IEnumerable<Portfolio> GetPortfolios()
        {   // (1)
            var jsonFileName = @"C:\Garden.RazorPages\Garden.RazorPages\GardenPage\Garden\wwwroot\Portfolios\Portfolios.json";
            // (1) jsonFileName 에서 -> (2) JsonFileName으로 변경해서 입력해보기
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var Portfolios = JsonSerializer.Deserialize<Portfolio[]>(jsonFileReader.ReadToEnd(), options);
                return Portfolios;
            }
        }

        public void AddRating(int portfolioId, int rating)
        {
            var portfolios = GetPortfolios();

            if(portfolios.First(p => p.Id == portfolioId).Ratings == null)
            {
                portfolios.First(p => p.Id == portfolioId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = portfolios.First(p => p.Id == portfolioId).Ratings.ToList();
                ratings.Add(rating);
                portfolios.First(p => p.Id == portfolioId).Ratings = ratings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<Portfolio>>
                (new Utf8JsonWriter(outputStream, new JsonWriterOptions 
                { 
                    SkipValidation = true, Indented = true 
                }), portfolios);
        }
    }
}