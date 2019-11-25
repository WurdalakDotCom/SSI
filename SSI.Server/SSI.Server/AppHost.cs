using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using SSI.Server.ServiceInterface;
using SSI.Server.ServiceModel.ClientModels;
using SSI.Server.ServiceModel.DeliveryModels;
using SSI.Server.ServiceModel.ProductModels;
using SSI.Server.ServiceModel.TransportModels;
using System;
using System.Collections.Generic;
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
            : base("SSI.Server", typeof(UserServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            var dbFactory = container.Register<IDbConnectionFactory>(c =>
                new OrmLiteConnectionFactory(ConfigurationManager.AppSettings.Get("IDB"), PostgreSqlDialect.Provider));

            Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[] {
                new CredentialsAuthProvider() { SessionExpiry = System.TimeSpan.FromHours(AppSettings.Get<int>("SessionLifeTimeInHours")) }}));


            container.Register<IAuthRepository>(arg =>
                new OrmLiteAuthRepository(container.Resolve<IDbConnectionFactory>()) { UseDistinctRoleTables = true, ForceCaseInsensitiveUserNameSearch = true });

            container.Resolve<IAuthRepository>().InitSchema();

            InitBase(container);
        }

        public void InitBase(Container container)
        {
            var authRepository = container.Resolve<IAuthRepository>();

            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                var user = db.Single<UserAuth>(x => x.UserName == "Admin");

                if(user == null)
                {
                    authRepository.CreateUserAuth(new UserAuth() { UserName = "Admin", Roles = new List<string>() { "Admin" }, CreatedDate = DateTime.Now }, "12qwasZX");
                }
            
                db.CreateTableIfNotExists<Client>();
                db.CreateTableIfNotExists<Transport>();
                db.CreateTableIfNotExists<Product>();
                db.CreateTableIfNotExists<Accounting>();
                db.CreateTableIfNotExists<Delivery>();
                db.CreateTableIfNotExists<Party>();
            }
        }
    }
}
