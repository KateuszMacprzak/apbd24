using WarehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace WarehouseApp.Controllers;

// kontroler warehouse
[Route("api/warehouses")]
[ApiController]
public class WarehousesController: ControllerBase
{
	[HttpPost]
	public IActionResult ChangeWarehouse(WarehouseRequest request)
	{
		using (SqlConnection con = new SqlConnection("Data Source=db-mssql.pjwstk.edu.pl; Initial Catalog=2019SBD;Integrated Security=True;TrustServerCertificate=True;User=s25367;"))
	{
		using (SqlCommand cmd = new SqlCommand("sp_Add_contact",con))
		{
			    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdProduct", SqlDbType.Int).Value = request.IdProduct;
                cmd.Parameters.Add("@IdWarehouse", SqlDbType.Int).Value = request.IdWarehouse;
                cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = request.Amount;
                cmd.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = request.CreatedAt;
                return Ok("DONE");		
			}
		}	
	}
}