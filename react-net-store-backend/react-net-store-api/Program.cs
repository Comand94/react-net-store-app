using Microsoft.AspNetCore.Identity;
using react_net_store_core.Services;
using react_net_store_database;
using react_net_store_database.Classes;

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

    services.AddCors(options =>
    {
        options.AddPolicy("ExpensesPolicy",
            builder =>
            {
                builder.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
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

    app.UseCors("ExpensesPolicy");

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

// Call function declared above
Configure();
