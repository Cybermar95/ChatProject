
using System;
using System.Collections.Generic;
using System.Collections;
using AuthorizationService.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.BusinessLayer
{
    public interface IAuthService
    {
        ActionResult<AccessTokens> Authorize(string UserName, string Password);
        void LogOff(string UserName, Guid Token);
    }


}