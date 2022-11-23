using Microsoft.EntityFrameworkCore;
using Minimal_APis_Sample.Data;
using Minimal_APis_Sample.Models;
using Minimal_APis_Sample.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

builder.Services.AddScoped<IEmployeeService,EmployeeServices>(); 

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

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//       new WeatherForecast
//       (
//           DateTime.Now.AddDays(index),
//           Random.Shared.Next(-20, 55),
//           summaries[Random.Shared.Next(summaries.Length)]
//       ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

//app.MapGet("/employee", (Func<Employee>)(() => {

//    return new Employee()
//    {
//        EmpId = "1",
//        EmpName = "Anil Kumar",
//        Salary = 25000
//    };
//}));

//app.MapGet("/employees", (Func<List<Employee>>)(() =>
//         {

//            return new EmployeeCollection().GetEmployees();
//         }

//));

//app.MapGet("/employee/{id}", async (http) =>
// {
//     if(!http.Request.RouteValues.TryGetValue("id",out var id))
//     {
//         http.Response.StatusCode = 400;
//         return;
//     }
//     else
//     {
//         await http.Response.WriteAsJsonAsync(new EmployeeCollection()
//             .GetEmployees()
//             .FirstOrDefault( x => x.EmpId ==(string)id));
//     }
// });


app.MapPost("/Employee/AddEmp",

(Employee employee, IEmployeeService service)=> CreateEmp(employee, service));

app.MapGet("/Employee/GetEmp/{id}",
    (int id, IEmployeeService service) => GetEmp(id, service));

app.MapGet("/Employee/GetEmps",
    (IEmployeeService service) => GetAllEmps(service));


app.MapPut("/Employee/UpdateEmp",
(Employee employee, IEmployeeService service) => UpdateEmp(employee, service));


app.MapDelete("/Employee/DeleteEmp",
(int id, IEmployeeService service) => DeleteEmp(id, service));



IResult CreateEmp(Employee employee, IEmployeeService service)
{
    var result = service.AddEmployee(employee);
    return Results.Ok(result);
}

IResult GetEmp(int id, IEmployeeService service)
{
    var emp = service.GetEmployee(id);
    if (emp is null) return Results.NotFound("Employee Not Found");
    return Results.Ok(emp);
} 

IResult GetAllEmps(IEmployeeService service)
{
    var emps = service.GetEmployees();    

    return Results.Ok(emps);
}

IResult UpdateEmp(Employee newemp, IEmployeeService service)
{
    var updatedEmployee = service.UpdateEmployee(newemp);
    if (updatedEmployee is null) return Results.NotFound("movie Not Found");
    return Results.Ok(updatedEmployee);
}

IResult DeleteEmp(int id, IEmployeeService service)
{
    var result = service.DeleteEmployee(id);
    if (!result) return Results.BadRequest("Something went wrong");
    return Results.Ok(result);
}

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}