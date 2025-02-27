using Alfateam.Core.Filters.Swagger;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Gateways;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Alfateam.CertificationCenter.Models;
using Alfateam.CertificationCenter.API.Filters;
using Alfateam.CertificationCenter.API.Services;
using Alfateam.DB.Services;
using Alfateam.DB.Services.Jobs;

namespace Alfateam.CertificationCenter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            builder.Services.AddHttpContextAccessor();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddTransient<IMailGateway, MailGateway>();
            builder.Services.AddTransient<ISMSGateway, SMSGateway>();

            // Add services to the container.
            builder.Services.AddDbContext<IDDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddDbContext<DbContext, CertCenterDbContext>(options =>
            {
                options.UseMySql(new MySqlServerVersion(new Version(8, 0, 11)), o =>
                {
                    o.EnableRetryOnFailure();
                    o.EnableStringComparisonTranslations();
                });
            });
            builder.Services.AddTransient<AbsDBService>();
            builder.Services.AddTransient<AbsFilesService>();
            builder.Services.AddTransient<AlfateamIDCodesService>();
            builder.Services.AddTransient<CancellationRequestsService>();
            builder.Services.AddTransient<UploadedFilesService>();
            builder.Services.AddTransient<ControllerParams>();



            builder.Services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "��� API ��� Alfateam - ��������������� ������",
                    Description = "����� ��� ��������� ��� ������ Alfateam �� - ���������������� �����"
                });
                config.DocumentFilter<DTODocumentFilter>();
                config.SchemaFilter<EnumSchemaFilter>();
                config.SchemaFilter<DTOSchemaFilter>();
                config.OperationFilter<SwaggerHeadersFilter>();
                config.OperationFilter<SwaggerMethodsFilter>();
            });


            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            UnusedUploadedFilesJob.Start<CertCenterDbContext>();
            app.Run();
        }
    }
}
