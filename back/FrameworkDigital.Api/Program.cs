using FrameworkDigital.Application.Leads.Service;
using FrameworkDigital.Domain.Leads.Repository;
using FrameworkDigital.Domain.Leads.Services;
using FrameworkDigital.Domain.Notification;
using FrameworkDigital.Domain.UoW;
using FrameworkDigital.Infra.Data.Context;
using FrameworkDigital.Infra.Data.Leads.Repository;
using FrameworkDigital.Infra.Data.UoW;
using FrameworkDigital.Infra.SendEmail;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infra - Data
builder.Services.AddScoped<MyContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Infra - Email
builder.Services.AddTransient<IEmailService, EmailService>();

// Repository
builder.Services.AddTransient<ILeadRepository, LeadRepository>();

// Services
builder.Services.AddTransient<ILeadService, LeadService>();

// Domain
builder.Services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

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

// Run Migrations on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MyContext>();
    context.Database.Migrate();
}

app.Run();
