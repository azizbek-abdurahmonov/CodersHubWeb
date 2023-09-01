using Backend.CodersHub.Files;
using Backend.CodersHub.Services.BlogPostServices.Concrete;
using Backend.CodersHub.Services.RegistrationServices;
using Backend.CodersHub.Services.UserServices.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFileContext, FileContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();


//// temp adding cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


////

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//// temp
app.UseCors("AllowAllOrigins");
//// temp

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
