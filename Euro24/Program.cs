using Euro24.Model;
using Euro24.Model.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<IPredictionMap, PredictMap>();
builder.Services.AddSingleton<IClientSessionManager, ClientSessionManager>();
builder.Services.AddSingleton<IGenerateScore, GenerateScore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();

