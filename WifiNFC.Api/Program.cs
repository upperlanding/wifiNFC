using WifiNFC.Api.Services.Mapper;
using WifiNFC.Api.TokenCreator;

namespace WifiNFC.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            Wifi.Infrastructure.DInjection.RegisterRepositories(builder.Services);
            Services.Token.BearerConfig.AddBearerConfig(builder.Services, builder.Configuration);
            builder.Services.AddTransient<ITokenCreator, TokenCreator.TokenCreator>();
            builder.Services.AddTransient<IDTOMapper, DTOMapper>();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}