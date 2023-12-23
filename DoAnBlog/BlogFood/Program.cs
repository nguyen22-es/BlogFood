using API.Repository;
using API.SignalrHub;
using BlogFoodApi.Repositories;
using BlogFoodApi.Service;
using DataAccess;
using DataAccess.Data.Entities;
using DataAccess.SeedData;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

builder.Services.AddDbContext<ManageAppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<IPostService, PostService>();

// repositories
builder.Services.AddTransient<ICategoryDbRepository, CategoryRepository>();
builder.Services.AddTransient<IPostDbRepository, PostRepository>();
builder.Services.AddTransient<ILikePostDbRepository, LikePostRepository>();
builder.Services.AddTransient<ICommentsDbRepository, CommentsRepository>();
builder.Services.AddTransient<IPostCategoryRepository, PostCategoryRepository>();
builder.Services.AddTransient<IFollowDbRepository, FollowRepository>();
builder.Services.AddTransient<IPostContentRepository, PostContentRepository>();
builder.Services.AddIdentity<ManageUser, IdentityRole>()
    .AddEntityFrameworkStores<ManageAppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ITokenService,TokenService>();
builder.Services.AddControllers();

builder.Services.AddSignalR();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer [jwt]'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityRequirement(new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } });
});





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var secret = builder.Configuration["JWT:Secret"];
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true; // lưu chữ token khi được xác thực
    options.TokenValidationParameters = new TokenValidationParameters //Cung cấp các tham số cho quá trình kiểm tra và xác nhận token JWT
    {
        
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        ClockSkew = new TimeSpan(0, 0, 5)

    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context => {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken)
                && path.StartsWithSegments("/SignalrHub"))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});










var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    AppIdentityDbContextSeeder.SeedAsync(app);
}
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/SignalrHub");
});
app.Run();
