using System.Text;
using IntegrationAPI.Mapper;
using IntegrationLibrary.BloodBank.Repository;
using IntegrationLibrary.BloodBank.Service;
using IntegrationLibrary.ConfigureGenerateAndSend.Repository;
using IntegrationLibrary.ConfigureGenerateAndSend.Service;
using IntegrationAPI.ScheduleTask;
using IntegrationAPI.ScheduleTask.Service;
using IntegrationLibrary.PDFReports.Service;
using IntegrationLibrary.NewsFromBloodBank.Repository;
using IntegrationLibrary.NewsFromBloodBank.Service;
using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Service;
using IntegrationLibrary.SendMail;
using IntegrationLibrary.SendMail.Services;
using IntegrationLibrary.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IntegrationAPI.ScheduleTask.Service;
using IntegrationAPI.Controllers;
using IntegrationLibrary.Tender.Service;
using IntegrationLibrary.Tender.Repository;
using IntegrationLibrary.HTTP;
using IntegrationLibrary.BloodSubscription.Service;
using IntegrationLibrary.BloodSubscription.Repository;
using IntegrationLibrary.Tender.Service;
using IntegrationLibrary.Tender.Repository;
using IntegrationLibrary.SFTP.Service;
using IntegrationLibrary.BloodStatistic.Service;
using IntegrationLibrary.PDFReportDetails.Service;
using IntegrationLibrary.PDFReportDetails.Repository;

namespace IntegrationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IntegrationDbContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("IntegrationDB")));
            services.Configure<EmailOptions>(Configuration.GetSection(EmailOptions.SendGridEmail));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })

#pragma warning restore CS0618

                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntegrationAPI", Version = "v1" });

            });

            services.AddScoped<IEmailService, EmailService>();
            services.Configure<EmailOptions>(options => Configuration.GetSection("EmailOptions").Bind(options));

            services.AddScoped<ITenderService, TenderService>();
            services.AddScoped<ITenderRepository, TenderRepository>();
            services.AddScoped<IBloodUnitAmountRepository, BloodUnitAmountRepository>();
            services.AddScoped<IBloodBankService, BloodBankService>();
            services.AddScoped<IPDFReportService,PDFReportService>();
            services.AddScoped<PDFReportController>();
            services.AddScoped<IPDFReportDetailsService, PDFReportDetailsService>();
            services.AddScoped<IPDFReportDetailsRepository, PDFReportDetailsRepository>();
          

            services.AddScoped<IBloodBankRepository, BloodBankRepository>();

            services.AddScoped<IConfigureGenerateAndSendRepository, ConfigureGenerateAndSendRepository>();
            services.AddScoped<IConfigureGenerateAndSendService, ConfigureGenerateAndSendService>();
            services.AddScoped<IReportSenderService, ReportSenderService>();

            services.AddSingleton<IHostedService, GenerateAndSendReportTask>();
            services.AddScoped<INewsFromBloodBankService, NewsFromBloodBankService>();
            services.AddScoped<INewsFromBloodBankRepository, NewsFromBloodBankRepository>();
            services.AddScoped<IBloodRequestRepository, BloodRequestRepository>();
            services.AddTransient<IBloodRequestService, BloodRequestService>();
            services.AddTransient<IHttpService, HttpService>();
            services.AddScoped<IBloodRequestService, BloodRequestService>();
            services.AddScoped<IBloodStatisticService, BloodStatisticService>();
            services.AddScoped<IBloodSubscriptionService, BloodSubscriptionService>();
            services.AddScoped<IMounthlyBloodSubscriptionRepository, MounthlyBloodSubscriptionRepository>();
            services.AddScoped<ISFTPService, SFTPService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IntegrationDbContext>();
                context?.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntegrationAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
