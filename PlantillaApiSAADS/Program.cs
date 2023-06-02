using PlantillaApiSAADS.Configuration;
using PlantillaApiSAADS.Helpers;
using PlantillaApiSAADS.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews()
 .AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAutoMapper(typeof(Program));
//CONFIGURACION SWAGGER
builder.Services.AddConfSwagger();

builder.Services.AddControllers().AddNewtonsoftJson(option => {
    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    option.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    option.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
    option.SerializerSettings.ContractResolver = new EmptyCollectionContractResolver();
})
.AddJsonOptions(option => option.JsonSerializerOptions.PropertyNamingPolicy = null);
//CONFIGURACION AUTH
builder.Services.AddConfAuthentication(configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<UserJWT>();
//CONFIGURACION DBCONTEX
builder.Services.AddConfDbContextLog(configuration);
builder.Services.AddConfDbContext(configuration);
//CONGURACION CORS
builder.Services.AddconfCors();
//builder.Services.AddConfDbContextSAADS(configuration);
//CONFIGURACION HTTP 
builder.Services.AddConfRepositorioHTTP(configuration);

//CONFIGURACION MID

var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseLoguearHTTPMiddleware();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
