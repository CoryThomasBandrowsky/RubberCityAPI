var builder = WebApplication.CreateBuilder(args);
var allowOrigins = "_allowOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200/home",
                                              "http://localhost:4200");
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(allowOrigins);
app.UseAuthorization();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
