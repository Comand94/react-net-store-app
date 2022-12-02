using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using react_net_store_core.Services;
using react_net_store_database;
using react_net_store_database.Classes;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
void ConfigureServices() 
{
    services.AddDbContext<AppDbContext>();
    //services.AddDbContext<AppDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DB_CONNECTION_STRING")));

    services.AddControllers();

    services.AddDbContext<AppDbContext>();

    services.AddTransient<IAddressesServices, AddressesServices>();
    services.AddTransient<ICartsServices, CartsServices>();
    services.AddTransient<IProductBrandsServices, ProductBrandsServices>();
    services.AddTransient<IProductCategoriesServices, ProductCategoriesServices>();
    services.AddTransient<IProductImagesServices, ProductImagesServices>();
    services.AddTransient<IProductsServices, ProductsServices>();
    services.AddTransient<IProductsInCartsServices, ProductsInCartsServices>();
    services.AddTransient<IReviewsServices, ReviewsServices>();
    services.AddTransient<IUsersServices, UsersServices>();

    services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
    services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddCors(options =>
    {
        options.AddPolicy("StorePolicy",
            builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
    });

    var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
    var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");

    services.AddAuthentication(opts =>
    {
        opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret))
        };
    });
}

// Call function declared above
ConfigureServices(); 

// Configure the HTTP request pipeline.
void Configure() 
{
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseCors("StorePolicy");

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

// Call function declared above
Configure();
