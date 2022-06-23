using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SDM.Common.Response;
using SDM.Controllers.BankMaster;
using SDM.Controllers.CostCenter;
using SDM.Controllers.Customer;
using SDM.Controllers.EmployeeMaster;
using SDM.Controllers.InsuranceMaster;
using SDM.Controllers.SubAccount;
using SDM.Controllers.Supplier;
using SDM.Controllers.Transaction;
using SDM.Controllers.VehicleMaster;
using SDM.Interfaces;
using SDM.TModels;
using SDM.Repository;
using SDM.Repository.BankMaster;
using SDM.Repository.CostCenter;
using SDM.Repository.CustomerMaster;
using SDM.Repository.InsuranceMaster;
using SDM.Repository.SubAccount;
using SDM.Repository.SupplierMaster;
using SDM.Repository.Transaction;
using SDM.Repository.Vehicle;
using SDM.Repository.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDM.Controllers.Report;

namespace SDM
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
            services.AddControllers();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICostCenterRepository, CostCenterRepository>();
            services.AddTransient<ISubAccountRepository, SubAccountRepository>();
            services.AddTransient<IVehicle, VehicleRepository>();
            services.AddTransient<ISupplier, SupplierRepositry>();
            services.AddTransient<IBankMaster, BankMasterRepository>();
            services.AddTransient<IInsuranceMaster, InsuranceRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IReport, ReportRepository>();
            services.AddTransient<BankController>();
            services.AddTransient<InsuranceMaserController>();
            services.AddTransient<CostCenterController>();
            services.AddTransient<EmployeeController>();
            services.AddTransient<CustomerController>();
            services.AddTransient<SubAccountController>();
            services.AddTransient<VehicleMasterController>();
            services.AddTransient<SupplierMasterController>();
            services.AddTransient<TransactionController>();
            services.AddTransient<ReportController>();
            services.AddTransient<SDMContext>();
            services.AddTransient<EmployeeMasterResponse>();
            services.AddTransient<ToasterMessages>();
            services.AddTransient<Response>();
            services.AddTransient<CustomerMasterResponse>();
            services.AddMvc()
             .AddJsonOptions(options => {
                 options.JsonSerializerOptions.IgnoreNullValues = false;
             });
           services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
