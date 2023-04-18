//Programmer: Lance Zotigh

using DemoAPI.Data;
using Microsoft.AspNetCore.Mvc;

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
/*app.MapGet("/helloworld", () =>
{
    //returns Hello World
    return "Hello World";
    //INFO you can add calculations and multiple fields here as well.
});*/


//Creates HTTP GET End Point with a bad request
/*app.MapGet("/helloworld", () =>
{
    //Returns a bad request   
    return Results.BadRequest("Exception");
});*/


/*This is used to pass something to the paramater in a GET request
* such as a int or a string parameter to pass data.
* This will allow the server to add an ID to this data object.
* This only accepts the type you put for example if you use a string
* Swagger will throw an error (for this example).
*/
/*app.MapGet("/helloworld{id}", (int id) =>
{
    return Results.Ok("Id!!" + id);
});*/

// Same as above but this one explicitly says that the type needs to be an int.
// This is the better way since the other throws a 400 instead of a 404 like it should when using a string.
/*app.MapGet("/helloworld{id:int}", (int id) =>
{
    return Results.Ok("Id!!" + id);
});*/

//Keeps this request in the same line by telling the server it is
////You can also do the same thing here with the above get request"Ok".
//app.MapPost("/helloworld2", () => Results.Ok("Hello World 2 example"));

//Creates HTTP POST End Point
//app.MapPost("/helloworld2", () => "Hello World 2");

//All of the basic methods such as MAP, DELETE etc.. can be envoked the same way.

//Returns the list of coupons from the data folder ideal again we want to be using a database.
app.MapGet("/api/coupon", () => {
    return Results.Ok(CouponStore.couponList);
});

//This MapGet function returns the coupon with the request specific ID when ran and requested.
app.MapGet("/api/coupon/{id:int}", (int id) => {
    return Results.Ok(CouponStore.couponList.FirstOrDefault(u=>u.Id==id));
});

// Creates a post requests that creates a coupon and posts it to the server.
app.MapPost("/api/coupon", ([FromBody] Coupon coupon) =>
{
    
});

app.MapPut("/api/coupon", () =>
{

});

app.MapDelete("/api/coupon/{id:int}", (int id) =>
{

});

app.UseHttpsRedirection();

app.Run();
