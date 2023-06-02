using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using PlantillaApiSAADS.Data;
using PlantillaApiSAADS.Models.RNDS;
using System.Reflection;
using System.Collections;

namespace PlantillaApiSAADS.Configuration;

    public static class DbContextExtensions
    {
        public static IServiceCollection AddConfDbContextLog(this IServiceCollection services, ConfigurationManager configuration)
        {

            return services.AddDbContext<UpdsLogContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Log")));

        }

        public static IServiceCollection AddConfDbContext(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddDb<SistemaCampeonatoContext>(configuration, "SIsCampeonato");

            //services.AddDbDSAADS(configuration);
            return services;

        }
        private static IServiceCollection AddDb<T>(this IServiceCollection services, ConfigurationManager configuration, string connectionString = "Default")
            where T : DbContext
        {
            services.AddDbContext<T>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(connectionString));
            });
            return services;
        }
        //public static IServiceCollection AddConfDbContextSAADS(this IServiceCollection services, ConfigurationManager configuration)
        //{

        //    return services.AddDbContext<SAADSContext>((serviceProvider, dbContextBuilder) =>
        //    {
        //        var connectionStringPlaceHolder = configuration.GetConnectionString("SAADS");
        //        var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        //        var dbName = httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(a => a.Type == "tenantId")!.Value;
        //        var connectionString = connectionStringPlaceHolder.Replace("{dbName}", dbName);
        //        dbContextBuilder.UseSqlServer(connectionString);
        //    });

        //}

    }
    internal class EmptyCollectionContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            Predicate<object> shouldSerialize = property.ShouldSerialize ?? (o => true);
            property.ShouldSerialize = obj => (shouldSerialize == null || shouldSerialize(obj)) && !IsEmptyCollection(property, obj);
            return property;
        }

        private bool IsEmptyCollection(JsonProperty property, object target)
        {
            var value = property.ValueProvider?.GetValue(target);
            var collection = value as ICollection;
            if (collection != null && collection.Count == 0)
                return true;

            if (!typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                return false;

            var countProp = property.PropertyType.GetProperty("Count");
            if (countProp == null)
                return false;

            var count = (int?)countProp.GetValue(value, null);
            return count == 0;
        }
    }
