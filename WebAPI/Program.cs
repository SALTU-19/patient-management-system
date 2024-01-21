using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.Dto.Response;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPatientService, PatientManager>();
builder.Services.AddTransient<IPatientDal, EfPatientRepository>();
builder.Services.AddTransient<IOrganizationService, OrganizationManager>();
builder.Services.AddTransient<IOrganizationDal, EfOrganizationRepository>();
builder.Services.AddTransient<IDiseaseHistoryService, DiseaseHistoryManager>();
builder.Services.AddTransient<IDiseaseHistoryDal, EfDiseaseHistoryRepository>();

builder.Services.AddTransient<IDrugHistoryService, DrugHistoryManager>();
builder.Services.AddTransient<IDrugHistoryDal, EfDrugHistoryRepository>();
builder.Services.AddTransient<IHospitalService, HospitalManager>();
builder.Services.AddTransient<IHospitalDal, EfHospitalRepository>();
builder.Services.AddTransient<IIrregularVisitHistoryService, IrregularVisitHistoryManager>();
builder.Services.AddTransient<IIrregularVisitHistoryDal, EfIrregularVisitHistoryRepository>();

builder.Services.AddTransient<IPeriodicVisitHistoryService, PeriodicVisitHistoryManager>();
builder.Services.AddTransient<IPeriodicVisitHistoryDal, EfPeriodicVisitHistoryRepository>();
builder.Services.AddTransient<IPostOpService, PostOpManager>();
builder.Services.AddTransient<IPostOpDal, EfPostOpRepository>();

builder.Services.AddTransient<IPreOpService, PreOpManager>();
builder.Services.AddTransient<IPreOpDal, EfPreOpRepository>();
builder.Services.AddTransient<ISessionService, SessionManager>();
builder.Services.AddTransient<ISessionDal, EfSessionRepository>();
builder.Services.AddTransient<ISurgeryHistoryService, SurgeryHistoryManager>();
builder.Services.AddTransient<ISurgeryHistoryDal, EfSurgeryHistoryRepository>();

builder.Services.AddTransient<IUserService, UserManager>();
builder.Services.AddTransient<IUserDal, EfUserRepository>();



builder.Services.AddTransient<ILoginAttemptDal, EfLoginAttemptRepository>();

builder.Services.AddTransient<IAuthService, AuthManager>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
        ValidAudience = builder.Configuration["AppSettings:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:8080",
                                              "http://www.contoso.com")
                                                          .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

//builder.Services.AddTransient<ResponseModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
