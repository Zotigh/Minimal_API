/******************************************************
* Programmer: Lance Zotigh (lzotigh1@cnm.edu/lzotigh1@gmail.com)
* Program: API Demo
* Purpose: Demo that shows how to create a Minimal API
*******************************************************/


/*
 * ****You can use the url localhost7101 then the methods file path****
 * Ex: https ://localhost7160/api/coupon/ what ever the id is
 * in this example 3 -> https ://localhost7160/api/coupon/3 -> (remove space)
 * The local host url will be in the Request URL field once the website is ran.
*/

using DemoAPI.Data;
using DemoAPI.Models;
using DemoAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

//Here is where you would use a logger function if it is not available.
//You can add the service here then use it within the methods below.

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
//Learn more about configuring Swagger/OpenAPI at https ://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
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

//Same as above but this one explicitly says that the type needs to be an int.
//This is the better way since the other throws a 400 instead of a 404 like it should when using a string.
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
//Added the WithName function as well
app.MapGet("/api/coupon", (ILogger<Program> _logger) => {
    //A logger method that will tell the console what is happening via a logged message.
    _logger.Log(LogLevel.Information, "Get all Coupons");
    return Results.Ok(CouponStore.couponList);
}).WithName("GetCoupons").Produces<IEnumerable<Coupon>>(200);
//Since this one is reteiveing a list the IEnumerable keyword needs to be used.

//This MapGet function returns the coupon with the request specific ID when ran and requested.
//Added the Get name so we can call this endpoint.
app.MapGet("/api/coupon/{id:int}", (int id) => {
    return Results.Ok(CouponStore.couponList.FirstOrDefault(u=>u.Id==id));
}).WithName("GetCoupon").Produces<Coupon>(200);

// Creates a post requests that creates a coupon and posts it to the server.
app.MapPost("/api/coupon", ([FromBody] CouponCreateDTO coupon_C_DTO) => {
   //Tells Server that if the ID is not 0 (which it should be everytime since the DataBase(DB) or server is
   //responsible for adding) or there is no name to return an error message/code. 
    if (string.IsNullOrEmpty(coupon_C_DTO.Name))
    {
        return Results.BadRequest("Invalid Id or Coupon Name");
    }

    //Safe guard to check if the name of the coupon already exists to prevent duplicates.
    if (CouponStore.couponList.FirstOrDefault(u => u.Name.ToLower() == coupon_C_DTO.Name.ToLower()) != null) 
    {
        return Results.BadRequest("Coupon Name Already Exists");
    }

    //This creates a full fledged coupon object that can use the other needed properties
    //such as ID. This makes it so the user does not see the other fields and can edit them.
    //This is because the other fields are already generated automatically and should not be edited.
    Coupon coupon = new()
    {
        IsActive = coupon_C_DTO.IsActive,
        Name = coupon_C_DTO.Name,
        Percent = coupon_C_DTO.Percent
    };

    //finds the list of coupons and adds it to that list as the next object (+1).
    coupon.Id = CouponStore.couponList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

    //Adds the coupon to the coupon list
    CouponStore.couponList.Add(coupon);

    //This works but is usually not the proper way to return. 
    //return Results.Ok(coupon);

    //This is the same as the above instead it utilizes the couponDTO which does not show the date modified field.
    CouponDTO couponDTO = new()
    {
        Id = coupon.Id,
        IsActive = coupon.IsActive,
        Name = coupon.Name,
        Percent = coupon.Percent,
        Created = coupon.Created
    };

    //We have to write the route it was saved.
    //TODO the '$' is string interpolation look that up
    //This is the proper way the response should be handled as it is a created instance but Ok does work.
    //This example is with out the WithName function
    //return Results.Created($"/api/coupon {coupon.Id}", coupon);


    //Used the WithName function to return the fill end point in the generated URL so you dont have to maually enter.
    //This is useful to generate the url to plug n play.
    return Results.CreatedAtRoute("GetCoupon", new {id= coupon.Id}, couponDTO);

}).WithName("CreateCoupon").Accepts<CouponCreateDTO>("application.json").Produces<CouponDTO>(201).Produces(400);
//Above the produces is used to specify the status code that can be produced. These can be added as needed.
//The Accepts keyword is used to specify the specific type of request the method will accept.

app.MapPut("/api/coupon", () => {

});

app.MapDelete("/api/coupon/{id:int}", (int id) => {

});

app.UseHttpsRedirection();

app.Run();
