using System.Globalization;
using RestApiAnimals.Models;
using Microsoft.Data.SqlClient;

namespace RestApiAnimals.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public IEnumerable<Animal> GetAnimals()
    {
        try
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            using var connect = new SqlConnection(_configuration["ConnectionStrings:Connection"]);
            connect.Open();

            using var command = new SqlCommand();
            command.Connection = connect;
            command.CommandText = "Select IdAnimal,Name,Category,Description,Area from Animal";

            var dr = command.ExecuteReader();
            var animals = new List<Animal>();

            while (dr.Read())
            {
                var animal = new Animal()
                {
                    IdAnimal = (int)dr["IdAnimal"],
                    Name = dr["Name"].ToString(),
                    Category = dr["Category"].ToString(),
                    Description = dr["Description"].ToString(),
                    Area = dr["Area"].ToString()
                };
                animals.Add(animal);
            }

            return animals;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Animal GetAnimal(int id)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:Connection"]);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select IdAnimal,Name,Category,Description,Area from Animal where IdAnimal=@IdAnimal ";
        command.Parameters.AddWithValue("@IdAnimal",id);

        var dr = command.ExecuteReader();
        if (!dr.Read()) return null;

        var animal = new Animal()
        {
            IdAnimal = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Category = dr["Category"].ToString(),
            Description = dr["Description"].ToString(),
            Area = dr["Area"].ToString()
        };
        return animal;
    }

    public int CreateAnimal(Animal animal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:Connection"]);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "INSERT INTO Animal(Name,Category,Description,Area) values (@Name,@Category,@Description,@Area)";
        command.Parameters.AddWithValue("@Name",animal.Name);
        command.Parameters.AddWithValue("@Category", animal.Category);
        command.Parameters.AddWithValue("@Description", animal.Description);
        command.Parameters.AddWithValue("@Category", animal.Area);
        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:Connection"]);
        connection.Open();

        using var command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "UPDATE Animal set Name=@Name,Category=@Category,Description=@Description,Area=@Area where IdAnimal=@IdAnimal";
        command.Parameters.AddWithValue("@IdAnimal",id);
        command.Parameters.AddWithValue("@Name",animal.Name);
        command.Parameters.AddWithValue("@Category",animal.Category);
        command.Parameters.AddWithValue("@Description",animal.Description);
        command.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int id)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:Connection"]);
        connection.Open();

        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Delete from Animal where @IdAnimal=id";
        command.Parameters.AddWithValue("@IdAnimal",id);

        var affectedCount = command.ExecuteNonQuery();
        return affectedCount;
    }
}