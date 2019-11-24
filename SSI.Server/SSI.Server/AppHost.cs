using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceInterface;
using System.Configuration;

namespace SSI.Server
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptySelfHost
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("SSI.Server", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            var dbFactory = container.Register<IDbConnectionFactory>(c =>
                new OrmLiteConnectionFactory(ConfigurationManager.AppSettings.Get("IDB"), PostgreSqlDialect.Provider));

            Plugins.Add(new AuthFeature(
                    () => new AuthUserSession()
                    , new IAuthProvider[]
                    {
                        new CredentialsAuthProvider() { SessionExpiry = System.TimeSpan.FromHours(AppSettings.Get<int>("SessionLifeTimeInHours")) }
                    }
                ));


            container.Register<IAuthRepository>(arg =>
                new OrmLiteAuthRepository(container.Resolve<IDbConnectionFactory>()) { UseDistinctRoleTables = true, ForceCaseInsensitiveUserNameSearch = true });

            container.Resolve<IAuthRepository>().InitSchema();
        }
    }
}
