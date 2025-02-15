var builder = WebApplication.CreateBuilder(args);

Assembly membershipAssembly = typeof(MembershipModule).Assembly;

builder.Services.AddCarterWithAssemblies(membershipAssembly);

builder.Services.AddMediatRWithAssemblies(membershipAssembly);

builder.Services.AddMembershipModule(builder.Configuration);

builder.Services.AddOpenApi();

builder.Services.AddSwagger();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "all",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI Modified V.2");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("all");

app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseMembershipModule();

app.Run();
