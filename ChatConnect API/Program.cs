using ChatConnect_API;
using ChatConnectInterfaces.Access;
using ChatConnectInterfaces.Login;
using ChatConnectRepoClasses;
using ChatConnectRepoClasses.Context;
using ChatConnectRepoInterfaces;
using ChatConnectServices.Access;
using ChatConnectServices.Login;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Classes
builder.Services.AddTransient<ILoginValidate, LoginValidate>();
builder.Services.AddTransient<ILoginCheck, LoginCheck>();
builder.Services.AddTransient<IRegisterUser, RegisterUser>();
builder.Services.AddTransient<IGetAccessService, GetAccessService>();
builder.Services.AddTransient<IAccessCheckService, AccessCheckService>();
builder.Services.AddTransient<IAccessAnonymousService, AccessAnonymousService>();
builder.Services.AddTransient<IInsertControllerName, InsertControllerName>();
builder.Services.AddTransient<IEncryptionService, EncryptionService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Repos
builder.Services.AddTransient<IUserInfoRepo, UserInfoRepo>();
builder.Services.AddTransient<IAccessRepo, AccessRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomAuthorizationMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
