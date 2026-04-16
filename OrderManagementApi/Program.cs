var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Order Management Api v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

var orders = new List<string> { "order1", "order2" };

app.MapGet("/orders", () => orders);

app.MapPost("/orders", (string order) =>
{
    orders.Add(order);
    return Results.Ok(order);
});

app.Run();