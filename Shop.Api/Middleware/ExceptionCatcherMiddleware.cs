using Shop.Application.Exceptions;
using Shop.Application.Functions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Api.Middleware
{
    public class ExceptionCatcherMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionCatcherMiddleware> _logger;

        public ExceptionCatcherMiddleware(ILogger<ExceptionCatcherMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }catch(AuthenticateException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(e.Message);
            }catch (EmailExistException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }catch (NotFoundException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }catch (ValidationShopException e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(e.Message);
            }


        }
    }
}
