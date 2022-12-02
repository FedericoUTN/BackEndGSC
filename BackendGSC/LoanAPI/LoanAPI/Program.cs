using LoanAPI.Configuration;
using LoanAPI.DataAccess;
using LoanAPI.Extensions;
using LoanAPI.Handlers;
using LoanAPI.Protos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureCors();

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();

builder.Services.AddDbContext<LoanContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnLocalLoanApi"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JWT"));
builder.Services.AddScoped<IJwtHandler, JwtHandler>();

builder.Services.AddGrpc(opt => {
    opt.EnableDetailedErrors = true; //Esto nos permite tener errores detallados
});
builder.Services.AddGrpcReflection();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcService<GrpcLoanService>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home }/{action=Index}/{id?}");

app.Run();
