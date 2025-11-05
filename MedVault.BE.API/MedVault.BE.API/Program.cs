using MedVault.BE.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

ApplicationConfigurator.RegisterServices(builder);

var app = builder.Build();

ApplicationConfigurator.Configure(app);

app.Run();