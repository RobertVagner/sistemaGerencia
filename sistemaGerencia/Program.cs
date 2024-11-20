using Microsoft.EntityFrameworkCore;
using sistemaGerencia.Data;
using sistemaGerencia.Repositorios;
using sistemaGerencia.Repositorios.Interfaces;

namespace sistemaGerencia
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

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaGerenciamentoDBContext>(
                    options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IPermissaoRepositorio, PermissaoRepositorio>();
            builder.Services.AddScoped<IGrupoRepositorio, GrupoRepositorio>();
            builder.Services.AddScoped<ISistemaRepositorio, SistemaRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
