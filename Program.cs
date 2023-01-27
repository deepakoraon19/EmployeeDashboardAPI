using EmployeeDashboard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddCors(o => o.AddPolicy("AllowAll", p =>
//{
//    p.AllowCredentials()
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .SetIsOriginAllowed(org => true);
//}));
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200"
                                              ).AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EmployeeService, EmployeeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
