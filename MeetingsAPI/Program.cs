using MediatR;
using MeetingCore;
using MeetingInfrastructure;
using MeetingsMediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MeetingsContext>();
builder.Services.AddScoped<IRepoEmployee, EmployeeRepository>();
builder.Services.AddScoped<IRepoEntity, EntityRepository>();
builder.Services.AddScoped<IRepoMeeting, MeetingRepository>();
builder.Services.AddScoped<IRepoPosition, PositionRepository>();
builder.Services.AddScoped<IRepoSubject, SubjectRepository>();

builder.Services.AddMediatR(typeof(MediatREntryPoint).Assembly);
builder.Services.AddAutoMapper(typeof(MediatREntryPoint).Assembly);

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
