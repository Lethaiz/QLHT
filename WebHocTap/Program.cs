using WebHocTap.Respository;
using Microsoft.EntityFrameworkCore;

using WebHocTap;
using WebHocTap.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Context")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ServicesCollection(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEAdminRespository, AdminRespository>();
builder.Services.AddScoped<IECourseRespository, CourseRespository>();
builder.Services.AddScoped<IEDocumentRespository, DocumentRespository>();
builder.Services.AddScoped<IEAdminAccRespository, AdminAccountRespository>();
builder.Services.AddScoped<IEClassRespository, ClassRespository>();
builder.Services.AddScoped<IEGradeRespository, GradeRespository>();
builder.Services.AddScoped<IEClassCourseRespository, ClassCourseRespository>();
builder.Services.AddScoped<IEPositionRespository, PositionRespository>();
builder.Services.AddScoped<IEStudent, StudentRespository>();
builder.Services.AddScoped<IEStudentAccount, StudentAccRespository>();
builder.Services.AddScoped<IETestCate, TestCateRespository>();
builder.Services.AddScoped<IETest, TestRespository>();
builder.Services.AddScoped<IEClassTest, ClassTestRespository>();
builder.Services.AddScoped<IESubject, SubjectRespository>();
builder.Services.AddScoped<IEStudentTest, StudentTestRespository>();
builder.Services.AddScoped<IELearningOutcome, LearningOutcomeRespository>();

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
