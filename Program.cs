using BenchmarkDataAccessTools.EFCore;
using BenchmarkDataAccessTools.Entity;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
class Program
{
    static void Main()
    {
        BenchmarkRunner.Run<GetConnections>();
        //new GetConnections().GetEFConnection();
    }
}
[MemoryDiagnoser]
public class GetConnections
{
    private string connectionString = "Data Source=DESKTOP-CCKO3F7\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
    [Benchmark]

    public void GetEFConnection()
    {
        var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.LogTo(Console.WriteLine);

        using (var dbContext = new EFContext(optionsBuilder.Options))
        {
            try
            {
                var entity = dbContext.AppUser.ToList();

                foreach (var item in entity)
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to database: {ex.Message}");
            }
        }
    }
    [Benchmark]

    public void GetAdoNetConnection()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string query = "SELECT *  FROM [master].[dbo].[AppUser]";

                SqlCommand command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    [Benchmark]

    public void GetDapperConnection()
    {
        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string query = "SELECT *  FROM [master].[dbo].[AppUser]";

                var result = connection.Query<AppUser>(query);

                foreach (var item in result)
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
