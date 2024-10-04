using DataAccess.NetCore.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security;
using System.Security.Claims;

namespace BE_072024.NetCoreAPI.Filter
{
    public class BE_072024AuthorizeAttribute : TypeFilterAttribute
    {
        public BE_072024AuthorizeAttribute(string functionCode = "DEFAULT", string permission = "VIEW") : base(typeof(DemoAuthorizeActionFilter))
        {
            Arguments = new object[] { functionCode, permission };

        }
    }

    public class DemoAuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        private readonly string _functionCode;
        private readonly string _permission;
        private readonly IAccountServices _accountServices;
        public DemoAuthorizeActionFilter(string funtioncode,
            string permission, IAccountServices accountServices)
        {
            _functionCode = funtioncode;
            _permission = permission;
            _accountServices = accountServices;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
           

            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                var userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value != null
                    ? Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value) : 0;

                if (userId == 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Vui lòng đăng nhập để thực hiện chức năng này "
                    });
                    return;

                }

                // Check quyền 
                var function = await _accountServices.GetFunctionByCode(_functionCode);

                if (function == null || function.FunctionID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Chức năng không hợp lệ! "
                    });
                    return;
                }


                var userpermission = await _accountServices.GetPermissionByUserID(userId, function.FunctionID);
                if (userpermission == null || userpermission.PermissionID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = System.Net.HttpStatusCode.Unauthorized,
                        Message = "Chức năng không hợp lệ! "
                    });
                    return;
                }

                switch (_permission)
                {
                    case "VIEW":

                        if (userpermission.IsView == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền thực hiện Chức năng này!"
                            });
                            return;
                        }
                        
                        break;

                    case "INSERT":
                        if (userpermission.IsInsert == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = System.Net.HttpStatusCode.Unauthorized,
                                Message = "Bạn không có quyền thực hiện Chức năng này!"
                            });
                            return;
                        }
                        break;

                }

            }
        }
    }
}
