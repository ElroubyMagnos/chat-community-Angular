using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MySecondAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckController : ControllerBase
    {
        public static SqlConnection con = new SqlConnection("Data Source=ELROUBY;Initial Catalog=communitychat;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private readonly ILogger<CheckController> _logger;

        public CheckController(ILogger<CheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public bool Get()
        {
            if (con.State != ConnectionState.Open)
                con.Open();


            string username = Request.Query["username"];
            SqlDataReader Reader = new SqlCommand($"Select * From Accounts Where username = '{username}'", con).ExecuteReader();
            if (Reader.Read())
            {
                Reader.Close();
                return true;
            }
            else Reader.Close();
            
            return false;
        }
    }
}