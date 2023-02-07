using Garden.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Json 파일을 읽어들여 컬렌션으로 변환해주는 서비스 클래스
namespace Garden.Services
{
    public class BlogServiceJsonFile
    {
        public IEnumerable<Blog> GetBlogs()
        {
            var jsonFileName = @"C:\Garden.RazorPages\Garden.RazorPages\GardenPage\Garden\wwwroot\Blogs\Blogs.json";

            using (var jsonFileReader = File.OpenText(jsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var blogs = JsonSerializer.Deserialize<Blog[]>(jsonFileReader.ReadToEnd(), options);
                return blogs;
            }
        }
    }
}
