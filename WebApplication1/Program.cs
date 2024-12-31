using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Создаем экземпляр Startup и вызываем ConfigureServices
var startup = new Startup();
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Вызываем Configure из Startup
startup.Configure(app);

app.Run();
