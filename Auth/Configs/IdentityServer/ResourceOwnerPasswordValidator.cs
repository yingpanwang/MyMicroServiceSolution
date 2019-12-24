using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Auth.Configs.IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IAccountService accountService;
        public ResourceOwnerPasswordValidator(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            //根据context.UserName和context.Password与数据库的数据做校验，判断是否合法
            if (true)
            {
                context.Result = new GrantValidationResult(
                subject: context.UserName,
                authenticationMethod: "custom");//,
                //claims: new Claim[]
                // {
                    
                //}.ToList());
            }
            else
            {
                //验证失败
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
            }
        }
    }
}
