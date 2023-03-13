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
    public class DistrictController : Controller
    {
        [HttpGet("GetDistrict")]
        public IActionResult GetDistrict()
        {
            var Ins = new List<District>();
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                Ins = con.Query<District>("select  DisttId,StateId,DistName,DistShortName,isActive,Updateby,Updateon,IPAddress from Tbl_Master_District").ToList();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Ok(Ins);

        }

        [HttpPost("SetDistrict")]
        public IActionResult SetDistrict(District district)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                var rowsaffected = con.Execute("insert into Tbl_Master_District(StateId,DistName,DistShortName,isActive,IPAddress,Updateby,Updateon) values(@StateId,@DistName,@DistShortName,@isActive, @IPAddress,@Updateby,@Updateon)", district);
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
        [HttpPost("UpdateDistrict")]
        public IActionResult UpdateDistrict(District district)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Update  Tbl_Master_District set  StateId = @StateId, isActive = @isActive,DistName=@DistName,IPAddress=@IPAddress,DistShortName=@DistShortName,Updateby=@Updateby,Updateon=@Updateon  WHERE DisttId = @DisttId", district);
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

        [HttpDelete("DeleteDistrict")]
        public IActionResult DeleteDistrict(int id)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Delete From Tbl_Master_District  where DisttId=@DisttId", new { DisttId = id });
            }
            return Ok(result);
        }
    }
}
