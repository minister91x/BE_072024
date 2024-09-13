namespace BE_072024.NetCoreAPI
{
    public class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        public MyCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            // return httpContext.Response.WriteAsync("Hello world!");
            httpContext.Response.Headers.Add("HackerBy", "MR Quan");
            return _next(httpContext);
        }

    }
}
