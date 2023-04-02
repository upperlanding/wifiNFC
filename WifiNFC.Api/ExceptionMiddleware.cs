using Wifi.Infrastructure.Exceptions;

namespace WifiNFC.Api
{
    internal class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NoEntryException)
            {
                httpContext.Response.StatusCode = 204;
                await httpContext.Response.WriteAsync("Kein Inhalt");
            }
            catch (RoomNotFoundException)
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("Room NFC unbekannt");
            }
            catch (InvalidCredentialsException)
            {
                httpContext.Response.StatusCode = 400;
            }
            catch (TokenException)
            {
                httpContext.Response.StatusCode = 501;
            }
            catch (Exception)
            {
                httpContext.Response.StatusCode = 500;
            }
        }
    }
}
