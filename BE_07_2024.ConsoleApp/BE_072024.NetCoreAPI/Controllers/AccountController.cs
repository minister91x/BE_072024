using DataAccess.NetCore.DO;
using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_072024.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices) // dependency injection 
        {
            _accountServices = accountServices;
        }

        [HttpPost("AccountLogin")]
        public async Task<ActionResult> AccountLogin(AccountLoginRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                returnData = await _accountServices.AccountLogin(requestData);
                return Ok(returnData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
