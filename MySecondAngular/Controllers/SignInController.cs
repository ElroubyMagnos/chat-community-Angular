using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MySecondAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignInController : ControllerBase
    {
        public static SqlConnection con = new SqlConnection("Data Source=ELROUBY;Initial Catalog=communitychat;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private readonly ILogger<SignInController> _logger;

        public SignInController(ILogger<SignInController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public bool Get()
        {
            if (con.State != ConnectionState.Open)
                con.Open();


            string username = Request.Query["username"];
            string password = Request.Query["password"];
            SqlDataReader Reader = new SqlCommand($"Select * From Accounts Where username = '{username}' and password = '{password}'", con).ExecuteReader();
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