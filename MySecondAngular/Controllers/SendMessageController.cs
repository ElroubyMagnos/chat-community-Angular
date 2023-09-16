using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MySecondAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendMessageController : ControllerBase
    {
        public static SqlConnection con = new SqlConnection("Data Source=ELROUBY;Initial Catalog=communitychat;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private readonly ILogger<SendMessageController> _logger;

        public SendMessageController(ILogger<SendMessageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            string sender = Request.Query["sender"];
            string receiver = Request.Query["receiver"];
            string message = Request.Query["message"];
            
            if (sender.Length == 0 || receiver.Length == 0 || message.Length == 0)
            {
                return "No";
            }

            new SqlCommand($@"INSERT INTO [dbo].[Messages]
           ([Sender]
           ,[Receiver]
           ,[Message])
     VALUES
           ('{sender}'
           ,'{receiver}'
           ,'{message}')", con).ExecuteNonQuery();
           
            return "Yes";
        }
    }
}