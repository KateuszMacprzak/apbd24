using System.Data.SqlClient;
using AnimalApp.Models;

namespace WarehouseApp.Repositories;

public class WarehousesRepository : IWarehousesRepository
{
    private IConfiguration _configuration;

    public WarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Product> GetProduct(int idProduct)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdProduct, Name, Description, Price FROM Product WHERE IdProduct = @IdProduct";
        cmd.Parameters.AddWithValue("@IdProduct", idProduct);
        
        var dr = cmd.ExecuteReader();
        if (!dr) = cmd.ExecuteReader();
        var products = new List<Product>();
        while (dr.Read())
        {
            var grade = new Product()
            {
                IdProduct = (int)dr["IdProduct"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Price"].ToString(),
                Area = dr["Area"].ToString(),
                
            };
            products.Add(grade);
        }
        
        return products;
    }
    
    public Animal GetWarehouse(int idWarehouse)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open(); 
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdWarehouse, Name, Address FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
        cmd.Parameters.AddWithValue("@IdWarehouse", idWarehouse);
        
        var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;

        var warehouses = new List<Warehouse>();
        while (dr.Read())
        {
            var grade = new Warehouse()
            {
                IdWarehouse = (int)dr["IdWarehouse"],
                Name = dr["Name"].ToString(),
                Address = dr["Address"].ToString(),
            };
            warehouses.Add(grade);
        }
        
        return warehouses;
    }
    
    public int CreateWarehouse(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Warehouse(IdWarehouse,Name,Address) VALUES(@IdWarehouse,@Name,@Address)";
        cmd.Parameters.AddWithValue("@IdWarehouse", warehouse.IdWarehouse);
        cmd.Parameters.AddWithValue("@Name", warehouse.Name);
        cmd.Parameters.AddWithValue("@Address", warehouse.Address);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    
    public int DeleteWarehouse(int id)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
        cmd.Parameters.AddWithValue("@IdWarehouse", id);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateWarehouse(Warehouse warehouse)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Warehouse SET Name=Name, Address=@Address WHERE IdWarehouse = @IdWarehouse";
        cmd.Parameters.AddWithValue("@IdWarehouse", warehouse.IdWarehouse);
        cmd.Parameters.AddWithValue("@Name", warehouse.Name);
        cmd.Parameters.AddWithValue(",@Address", warehouse.Address);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}