using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //SwaggerGen : 경로, 컨트롤러 및 모델에서 직접 SwaggerDocument 개체를 빌드하는 Swagger 생성기.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MaMu API",
                    Description = "MaMu ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
  
            });
            //services.AddRouting(options => options.LowercaseUrls = true);
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();// 생성된 Swagger를 Json 엔드포인트로 제공하도록 미들웨어를 활성화
            // Swagger-ui(HTML. JS, CSS 등)를 제공하는 미들웨어 활성화
            // Swagger Json 엔드포인트를 제공
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaMu API V1");
            });//이 단계를 실행하면 The Swagger가 구성되고 프로젝트에서 사용할 준비가 됨

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
 
            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                //첫 번째 경로 세그먼트를 컨트롤러 이름에 매핑
                //두 번재 경로 세그먼트를 액션 이름에 매핑
                //세 번째 경로 세그먼트는 모델 엔터티에 매핑되는 선택적 id에 사용
                //routes.MapRoute("default", "{controller=Controllers}/{action=Info}/{id?}");
                routes.MapRoute("default", "{controller=Controllers}/{action=info}/{id?}");
                // routes.MapRoute("MemCache", "{controller}/{action}/{id?}", defaults: new {controller = "Controllers", action= "Mem" });
                routes.MapRoute("mem", "{controller=Controllers}/{action=Mem}/{id?}");
                

            });
            
        }
       
    }
}
