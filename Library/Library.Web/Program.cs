using Library.Data;
using Library.Data.Repos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// DB connection test
#region
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var db = new Database(connectionString);

try
{
    using var conn = db.GetConnection();
    conn.Open();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("-----------------");
    Console.WriteLine("CONNECTION OPENED");
    Console.WriteLine("-----------------");
    Console.ForegroundColor = ConsoleColor.White;
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("-----------------");
    Console.WriteLine("CONNECTION ERROR");
    Console.WriteLine("-----------------");
    Console.WriteLine("\nERROR: " + ex.Message + "\n");
    Console.ForegroundColor = ConsoleColor.White;
}
#endregion

// DB query test
#region
var userRepo = new UserRepository(connectionString);
var users = userRepo.GetAll();

Console.WriteLine("--- DB query test ---");
foreach (var user in users)
    Console.WriteLine(user);
#endregion

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}"
    );

app.Run();



