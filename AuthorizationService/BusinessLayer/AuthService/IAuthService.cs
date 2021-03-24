
using System;
using System.Collections.Generic;
using System.Collections;
using AuthorizationService.Model;

namespace AuthorizationService.BusinessLayer
{
    public interface IAuthService
    {
        ChatUser Authorize(string UserName, string Password);
        void LogOff(string UserName, Guid Token);
    }


}