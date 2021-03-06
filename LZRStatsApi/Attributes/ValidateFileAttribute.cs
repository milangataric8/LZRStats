﻿using LZRStatsApi.Helpers;
using LZRStatsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LZRStatsApi.Attributes
{
    public class ValidateFileAttribute : ActionFilterAttribute
    {
        private readonly IGameService _gameService;
        public ValidateFileAttribute(IGameService gameService)
        {
            _gameService = gameService;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var file = context.HttpContext.Request.Form.Files[0]; //TODO handle multiple upload
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            fileName = fileName.ReplaceBadMinusCharacter();
            var matchData = fileName.Split('-');

            var gameImported = await _gameService.IsGameImported(int.Parse(matchData[0]), int.Parse(matchData[1]), matchData[2].Split('.')[0]);
            if (gameImported)
                context.Result = new BadRequestResult();
            await next.Invoke();
        }
    }
}
