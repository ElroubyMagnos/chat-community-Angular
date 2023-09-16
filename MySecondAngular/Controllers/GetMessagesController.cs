using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MySecondAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetMessagesController : ControllerBase
    {
        public static SqlConnection con = new SqlConnection("Data Source=ELROUBY;Initial Catalog=communitychat;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private readonly ILogger<GetMessagesController> _logger;

        public GetMessagesController(ILogger<GetMessagesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<OneMessage> Get()
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            string sender = Request.Query["sender"];
            string receiver = Request.Query["receiver"];

            SqlDataAdapter adapter = new SqlDataAdapter($"Select Top 25 * From Messages Where (Sender = '{sender}' And Receiver = '{receiver}') OR (Sender = '{receiver}' And Receiver = '{sender}')", con);
            DataTable DT = new DataTable();
            adapter.Fill(DT);

            List<OneMessage> MessageDatas = new List<OneMessage>();

            foreach (DataRow row in DT.Rows)
            {
                MessageDatas.Add(new OneMessage
                {
                   ID = int.Parse(row[0].ToString()),
                   Sender = row[1].ToString(),
                   Receiver = row[2].ToString(),
                   Message = row[3].ToString()
                });
            }

            return MessageDatas;
        }
    }
}