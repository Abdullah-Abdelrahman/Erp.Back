
using Erp.Api.middleware;
using Erp.Data.Entities.HumanResources.Staff;
using Erp.Data.Entities.MainModule;
using Erp.Infrastructure;
using Erp.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Name.Core;
using Name.Core.Middleware;
using Name.Infrastructure;
using Name.Infrastructure.Data;
using Name.Service;
using Name.Service.Abstracts;
using Name.Service.Implementations;
using System.Text;

namespace Name.Api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();



      builder.Services.AddDbContext<ApplicationDBContext>(options =>
      {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Conction")
                  );

      });

      builder.Services.AddDbContext<TenantDBContext>(options =>
      {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Conction")
                  );

      });


      builder.Services.AddIdentity<UserBase, ApplicationRole>(options =>
      {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;

        options.User.RequireUniqueEmail = true;

        options.SignIn.RequireConfirmedEmail = true;


      }).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

      #region my custom Dependency injection
      builder.Services
          .AddInfrastructureDependencies()
          .AddServiceDependencies()
          .AddCoreDependencies().
          AddRegisterationService();

      #endregion


      builder.Services.AddAuthentication(x =>
      {
        //only check valid token
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

      })
     .AddJwtBearer(x =>
     {
       //check on claims
       x.RequireHttpsMetadata = false;
       //not expired yet
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters
       {
         //wether to check for the issuer or no
         ValidateIssuer = true,
         ValidIssuer = builder.Configuration["JWT:Issuer"],
         ValidateAudience = true,
         ValidAudience = builder.Configuration["JWT:Audience"],
         IssuerSigningKey =
                 new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:securityKey"]))


       };
     });

      //Custmize Swagger
      builder.Services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Erp Project", Version = "v1" });
        c.EnableAnnotations();

        c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
          Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = JwtBearerDefaults.AuthenticationScheme
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
            }
     });
      });


      //Enable All
      builder.Services.AddCors(options =>
      {
        options.AddPolicy("MyPolicy", builder =>
              {
                builder.AllowAnyOrigin()    // Allow all origins
                             .AllowAnyMethod()    // Allow all HTTP methods
                             .AllowAnyHeader();   // Allow all headers
              });
      });


      //My Policy
      builder.Services.AddAuthorization(option =>
      {
        option.AddPolicy("CreateCourse", policy =>
              {
                policy.RequireClaim("Create Course", "true");
              });

      });

      builder.Services.AddHttpClient<IFileService, FileService>(client =>
      {
        client.BaseAddress = new Uri("http://localhost:5049/"); // Use the base URL of Name.Api
      });

      builder.Services.AddScoped<DataSeeder>(); // Register the seeder service


      //Build
      var app = builder.Build();


      using (var scope = app.Services.CreateScope())
      {
        var TdbContext = scope.ServiceProvider.GetRequiredService<TenantDBContext>();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();

        // Apply migrations (if not applied)
        dbContext.Database.Migrate();

        // Fetch all tenant IDs from the database
        var tenantIds = TdbContext.tenants.Select(t => t.Id).ToList();

        // Seed data for each tenant
        var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        foreach (var tenantId in tenantIds)
        {
          seeder.Seed(tenantId).GetAwaiter().GetResult();
        }
      }

      // Configure the HTTP request pipeline.
      //if (app.Environment.IsDevelopment())
      //{
      app.UseSwagger();
      app.UseSwaggerUI();
      //}
      app.UseMiddleware<ErrorHandlerMiddleware>();


      app.UseCors("MyPolicy");
      app.UseAuthentication();

      app.UseAuthorization();

      app.UseMiddleware<TenantResolver>();
      app.MapControllers();

      app.Run();
    }
  }
}
