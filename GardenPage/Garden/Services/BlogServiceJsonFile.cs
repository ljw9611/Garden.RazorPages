using Garden.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Json 파일을 읽어들여 컬렌션으로 변환해주는 서비스 클래스
namespace Garden.Services
{
    public class BlogServiceJsonFile
    {   // IWebHostEnvironment의 인스턴스는 _webHostEnvironment 된다.
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogServiceJsonFile(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }
        // (2)
        private string JsonFileName // 해당 인스턴스는 아래의 jsonFileName 의 경로 값과 동일하다.
        {
            get
            {
                //return _webHostEnvironment.WebRootPath + "\\Blogs" + "\\Blogs.json";
                return Path.Combine(_webHostEnvironment.WebRootPath, "Blogs", "Blogs.json");
            }
        }

        public IEnumerable<Blog> GetBlogs()
        {   // (1)
            var jsonFileName = @"C:\Garden.RazorPages\Garden.RazorPages\GardenPage\Garden\wwwroot\Blogs\Blogs.json";
            // (1) jsonFileName 에서 -> (2) JsonFileName으로 변경해서 입력해보기
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var blogs = JsonSerializer.Deserialize<Blog[]>(jsonFileReader.ReadToEnd(), options);
                return blogs;
            }
        }
    }
}