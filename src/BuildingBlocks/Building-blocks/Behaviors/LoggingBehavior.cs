﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Building_blocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> 
        (ILogger<LoggingBehavior<TRequest,TResponse>> logger): IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull,IRequest<TResponse>
        where TResponse : notnull
    {
        public async  Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] Handle request = {Request} - Response = {Response} - RequestData = {RequestData}",
               typeof(TRequest).Name, typeof(TResponse).Name, request);
            
            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            var timetaken = timer.Elapsed;  
            if(timetaken.Seconds >3) // if the request is greater than 3 seconds,then log the warnings
                logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds.",
                    typeof(TRequest).Name,timetaken.Seconds);

            logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TRequest).Name,typeof(TResponse).Name);
            return response;

            
        }
    }
}
