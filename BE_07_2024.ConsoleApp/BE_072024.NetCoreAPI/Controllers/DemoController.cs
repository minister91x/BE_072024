using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_072024.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet("GetData")]
        public async Task<ActionResult> GetData()
        {
            var list = new List<BE_072024.NetCoreAPI.Models.Acccount>();
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new Models.Acccount
                    {
                        FullName = "Nguyễn văn " + i,
                        ID = i,
                        UserName = "user" + i
                    });
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Ok(list);
        }
    }
}
