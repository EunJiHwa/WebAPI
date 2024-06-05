using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //TO-DO
    //1. call 줄이고, 메모리캐시..
    //2. route url...
    //요청 결과 값
    [Produces("application/json")] //GET 작업의 경우 응답 콘텐츠 형식 드롭다운에서 기본 값으로 선택
    [ProducesResponseType(StatusCodes.Status200OK)]     // Success
    [ProducesResponseType(StatusCodes.Status400BadRequest)] //BadRequest
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("")]//URL 맵핑 대소문자 가리기(변경하기)
    [ApiController]
    public class InfoController : ControllerBase
    {
        private IMemoryCache _cache;

        public InfoController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
    
        [HttpGet]
        public IEnumerable<MaMuBoxOfficeVO> Get()
        {
            return GetBoxOfiiceVO();
        }

        /// <summary>
        /// 일간박스오피스
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("boxoffice/{date}")]
        public ActionResult<string> Get(string date)
        {
            return "value";
        }

    /*    
        [HttpPost]
        [Route("mybookmark/")]
        public void Post([FromBody] string value)
        {
        }
        */

        [HttpPut()]
        [Route("mybookmark/delete")]
        public void Delete([FromBody] string value)
        {
        }
        

        private List<MaMuModel> GetMaMuModel()
        {
            return new List<MaMuModel>()
            {
                new MaMuModel()
                {
                    Id = "New",
                    Name = "New Movie"
                },
                new MaMuModel()
                {
                    Id = "Old",
                    Name = "Old Movie"
                }

            };
        }

        private List<MaMuBoxOfficeVO> GetBoxOfiiceVO()
        {
            return new List<MaMuBoxOfficeVO>()
            {
                new MaMuBoxOfficeVO()
                {
                    Date = DateTime.Now.ToString()
                }
            };
        }


    }
}
