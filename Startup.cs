using Microsoft.EntityFrameworkCore;
using RestaurantWebAPI.Contexts;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RestaurantWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void ConfigurationService(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["ConnectionStrings:RestaurantDBConnectionString"];
            builder.Services.AddDbContext<RestaurantContext>(o => o.UseSqlServer(connectionString));

            //builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            //builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            //builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            //builder.Services.AddScoped<IOrderMenuRepository, OrderMenuRepository>();
            //builder.Services.AddScoped<IUserRepository, UserRepository>();

            //builder.Services.AddScoped<IOrderUnitOfWork, OrderUnitOfWork>();
            //builder.Services.AddScoped<IMenuUnitOfWork, MenuUnitOfWork>();
            //builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //builder.Services.AddAuthentication(opt =>
            //{
            //    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,

            //        ValidIssuer = "https://localhost:7146",
            //        ValidAudience = "https://localhost:7146",
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKey@2022"))
            //    };
            //});

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddControllers();
        }

        public static void Configure(WebApplication app)
        {
            //Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
