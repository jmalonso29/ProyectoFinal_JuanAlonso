using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoFinal_JuanAlonso.database;
using ProyectoFinal_JuanAlonso.Mapper;
using ProyectoFinal_JuanAlonso.Service;

namespace ProyectoFinal_JuanAlonso
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

            //inyectar las dependencias
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<ProductoVendidoService>();
            builder.Services.AddScoped<VentaService>();

            builder.Services.AddScoped<UsuarioMapper>();
            builder.Services.AddScoped<ProductoMapper>();
            builder.Services.AddScoped<ProductoVendidoMapper>();
            builder.Services.AddScoped<VentaMapper>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<CoderContext>(options =>
            {
                options.UseSqlServer("Server=JQS\\SQLEXPRESS01; Database=coderhouse; Trusted_Connection= True;");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            //app.UseExceptionHandler();
            app.MapControllers();

            app.Run();
        }
    }
}
