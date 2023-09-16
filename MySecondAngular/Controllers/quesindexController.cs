using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MySecondAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class quesindexController : ControllerBase
    {
        public static SqlConnection con = new SqlConnection("Data Source=ELROUBY;Initial Catalog=communitychat;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private readonly ILogger<quesindexController> _logger;

        public quesindexController(ILogger<quesindexController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Account> Get()
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("Select Top 10 * From Accounts", con);
            DataTable DT = new DataTable();
            adapter.Fill(DT);

            List<Account> AccountDatas = new List<Account>();

            foreach (DataRow row in DT.Rows)
            {
                AccountDatas.Add(new Account
                {
                   ID = int.Parse(row[0].ToString()),
                   username = row[1].ToString(),
                   password = row[2].ToString()
                }); ;
            }

            return AccountDatas;
        }
    }
}