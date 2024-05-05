using TechECommerce.API.Extentions;
using TechECommerce.Business.ConfigurationService;
using TechECommerce.DataAccess.ConfigurationService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseSevice(builder.Configuration);
builder.Services.AddRepositoriesService();

builder.Services.AddBusinessServices();
builder.Services.AddCustomServices();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenService();

    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddExceptionHandlerService();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
