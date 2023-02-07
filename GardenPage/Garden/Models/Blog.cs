using System.Text.Json;

namespace Garden.Models
{
    public class Blog // 1. 클래스 생성
    {
        /// <summary>
        /// 모델 클래스(접미사): Model, ViewModel, Dto, Object, Entity, ...
        /// 다른 코드와 충돌을 방직하기 위해 붙이는 접미사
        /// </summary>
        /// 2. 인스턴스 생성
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        
        public override string ToString() // 문자열로 반환
        {
            // Blog에 대한 개체(this)를 Json 형태로 변환
            return JsonSerializer.Serialize<Blog>(this);
        }
    }
}
