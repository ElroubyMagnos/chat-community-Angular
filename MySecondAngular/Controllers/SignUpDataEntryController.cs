using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MySecondAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpDataEntryController : ControllerBase
    {
        public static SqlConnection con = new SqlConnection("Data Source=ELROUBY;Initial Catalog=communitychat;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private readonly ILogger<SignUpDataEntryController> _logger;

        public SignUpDataEntryController(ILogger<SignUpDataEntryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            if (con.State != ConnectionState.Open)
                con.Open();


            string username = Request.Query["username"];
            string password = Request.Query["password"];

            if (username.Length > 4 && password.Length > 4)
            {
            new SqlCommand($@"INSERT INTO [dbo].[Accounts]
                ([username]
                ,[password])
            VALUES
                ('{username}'
                ,'{password}')", con).ExecuteNonQuery();

                return "SignedUp";
            }
            else return "Error";
        }
    }
}