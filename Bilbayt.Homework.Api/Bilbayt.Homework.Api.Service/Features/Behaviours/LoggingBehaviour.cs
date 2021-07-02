using Bilbayt.Homework.Api.Service.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Bilbayt.Homework.Api.Service.Features.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                var settings = new JsonSerializerSettings()
                {
                    Error = delegate (object _, ErrorEventArgs args)
                    {
                        args.ErrorContext.Handled = true;
                    }
                };
                _logger.LogInformation($"Handling {typeof(TRequest).Name} ::: Request {JsonConvert.SerializeObject(request, settings)}");

                var response = await next();

                return response;
            }
            catch (Exception ex)
            {
                throw ex switch
                {
                    BadRequestException e => new AutoWrapper.Wrappers.ApiException(e.Message),
                    ValidationException e => new AutoWrapper.Wrappers.ApiException(e.Failures),
                    AuthenticationException e => new AutoWrapper.Wrappers.ApiException(e.Message, 401),
                    NotFoundException e => new AutoWrapper.Wrappers.ApiException(e.Message, 404),
                    DeleteFailureException e => new AutoWrapper.Wrappers.ApiException(e.Message, 500),
                    ConflictException e => new AutoWrapper.Wrappers.ApiException(e.Message, 409),
                    _ => new AutoWrapper.Wrappers.ApiException(ex.Message, 500),// unhandled error
                };
            }
        }
    }
}