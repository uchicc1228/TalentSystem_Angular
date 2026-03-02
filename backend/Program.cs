var builder = WebApplication.CreateBuilder(args);

// 加入 Controller 服務
builder.Services.AddControllers();


// 加入 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular 開發伺服器
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// 如果需要 Swagger (OpenAPI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TalentApi.Services.TalentService>();
var app = builder.Build();

// 開發環境啟用 Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
// 啟用 CORS
app.UseCors("AllowAngular");

// 啟用 Controller 路由
app.MapControllers();

app.Run();
