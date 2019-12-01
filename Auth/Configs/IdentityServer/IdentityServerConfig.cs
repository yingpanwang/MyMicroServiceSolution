using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Configs.IdentityServer
{
    /// <summary>
    /// IdentityServer配置
    /// </summary>
    public class IdentityServerConfig
    {
        /// <summary>
        /// 获取资源
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResourceResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // 定义 api scope
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        // 定义客户端
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1",IdentityServerConstants.StandardScopes.OpenId, //必须要添加，否则报forbidden错误
                  IdentityServerConstants.StandardScopes.Profile},
                },
                new Client
                {
                    ClientId = "pwdClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    //AccessTokenLifetime = 30,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1",IdentityServerConstants.StandardScopes.OpenId, //必须要添加，否则报forbidden错误
                  IdentityServerConstants.StandardScopes.Profile}
                },
                new Client
                {
                    ClientId= "hybrid",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1",IdentityServerConstants.StandardScopes.OpenId, //必须要添加，否则报forbidden错误
                  IdentityServerConstants.StandardScopes.Profile}
                }
            };
        }
    }
}
