using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserModuleApi.Models;
using UserModuleApi.Properties.Common;

namespace UserModuleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        [HttpGet("GetState")]
        public IActionResult GetState()
        {
            var Ins = new List<State>();
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                Ins = con.Query<State>("select  StateId,Country,StateName,isActive,Updateby,Updateon,IPAddress from Tbl_Master_State").ToList();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Ok(Ins);

        }

        [HttpPost("SetState")]
        public IActionResult SetTitle(State state)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                var rowsaffected = con.Execute("insert into Tbl_Master_State(Country,isActive,StateName,IPAddress,Updateby,Updateon) values(@Country,@isActive,@StateName, @IPAddress,@Updateby,@Updateon)", state);
                if (rowsaffected > 0)
                {
                    result = "Success";
                }
                else
                {
                    result = "Failed";
                }

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return Ok(result);

        }
        [HttpPost("UpdateState")]
        public IActionResult UpdateTitle(State state)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Update  Tbl_Master_State set  Country = @Country, isActive = @isActive,StateName=@StateName,IPAddress=@IPAddress,Updateby=@Updateby,Updateon=@Updateon  WHERE StateId = @StateId", state);
                if (rowsAffected > 0)
                {
                    result = "Success";
                }
                else
                {
                    result = "Failed";
                }
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Ok(result);
        }

        [HttpDelete("DeleteState")]
        public IActionResult DeleteTitle(int id)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Delete From Tbl_Master_State  where StateId=@StateId", new { StateId = id });
            }
            return Ok(result);
        }
    }
}
