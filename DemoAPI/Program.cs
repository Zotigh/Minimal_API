//Programmer: Lance Zotigh

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Creates HTTP GET End Point
/*app.MapGet("/helloworld", () => "HelloWorld");*/

//Creates HTTP GET End Point with multiple facets of information.
app.MapGet("/helloworld", () =>
{

});



//Creates HTTP POST End Point
app.MapPost("/helloworld2", () => "Hello World 2");
//All of the basic methods such as MAP, DELETE etc.. can be envoked the same way.

app.UseHttpsRedirection();

app.Run();
