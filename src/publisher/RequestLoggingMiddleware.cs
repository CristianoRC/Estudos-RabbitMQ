using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace publisher
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISendMessageService _sendMessageService;

        public RequestLoggingMiddleware(RequestDelegate next, ISendMessageService sendMessageService)
        {
            _next = next;
            _sendMessageService = sendMessageService;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                var requestId = Guid.NewGuid().ToString();
                var message = new
                {
                    Id = context.TraceIdentifier,
                    context.Request.Method,
                    context.Request.Protocol,
                    Path = context.Request.Path.Value,
                    context.Request.Host.Host,
                    context.Request.Host.Port,
                    context.Request.IsHttps,
                };
                _sendMessageService.SendMessage(message, "register", $"{requestId}.log");
            }
        }
    }
}