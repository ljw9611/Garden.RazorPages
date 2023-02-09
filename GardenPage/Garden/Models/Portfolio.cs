using System.Text.Json;
using System.Text.Json.Serialization;

namespace Garden.Models
{
    public class Portfolio // 1. 클래스 생성
    {
        /// <summary>
        /// 모델 클래스(접미사): Model, ViewModel, Dto, Object, Entity, ...
        /// 다른 코드와 충돌을 방직하기 위해 붙이는 접미사
        /// </summary>
        /// 2. 인스턴스 생성
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        public override string ToString() // 문자열로 반환
        {
            return JsonSerializer.Serialize<Portfolio>(this);
        }
    }
}
