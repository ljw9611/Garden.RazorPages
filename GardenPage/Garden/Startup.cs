using Garden.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garden
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(); // 해당 메서드 추가
            services.AddServerSideBlazor(); // (!) 블레이저 서버를 사용할 수 있는 가장 기본적 단계
            services.AddTransient<BlogServiceJsonFile>(); // DI Container
            services.AddTransient<PortfolioServiceJsonFile>(); // DI Container
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // 미들웨어 추가
            app.UseStaticFiles(); // wwwroot에 있는 정적인 HTML, CSS, Javascript, 이미지 등 실행을 위해 필요한 메소드
            //app.UseFileServer(); // UseStaticFiles + 기본 문서 등록 기능까지 추가

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // 해당 메서드 추가
                endpoints.MapBlazorHub(); // (!) 블레이저 서버를 사용할 수 있는 가장 기본적 단계
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
