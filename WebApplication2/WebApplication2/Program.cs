
using WebApplication2;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var companiesXml = builder.Configuration.GetSection("Companies").Get<List<CompanyInfo>>();
var companiesJson = builder.Configuration.GetSection("Companies").Get<List<CompanyInfo>>();
var companiesIni = builder.Configuration.GetSection("Companies").Get<List<CompanyInfo>>();
var userConfig = builder.Configuration.GetSection("MyInformation").Get<MyInfo>();

var maxNumberOfEmployees = companiesXml.Concat(companiesJson).Concat(companiesIni).OrderByDescending(c => c.NumberOfEmployees).FirstOrDefault();

app.MapGet("/", () => $"Company with the highest number of employees: {maxNumberOfEmployees?.Name}\n\n" +
$"My name and surname: {userConfig?.Name} {userConfig?.Surname}, Age: {userConfig?.Age}, Phone Number: {userConfig?.PhoneNumber}");
app.Run();