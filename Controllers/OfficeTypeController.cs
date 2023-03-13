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
    public class OfficeTypeController : Controller
    {
        [HttpGet("GetOfficeType")]
        public IActionResult GetOfficeType()
        {
            var Ins = new List<OfficeType>();
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                Ins = con.Query<OfficeType>("select  OfficeTypeId,OfficeTypeName,OfficeTypeNameShort,isActive,Updateby,Updateon,IPAddress from Tbl_Master_OfficeType").ToList();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Ok(Ins);

        }

        [HttpPost("SetOfficeType")]
        public IActionResult SetOfficeType(OfficeType officeType)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                var rowsaffected = con.Execute("insert into Tbl_Master_OfficeType(OfficeTypeName,OfficeTypeNameShort,isActive,IPAddress,Updateby,Updateon) values(@OfficeTypeName,@OfficeTypeNameShort,@isActive, @IPAddress,@Updateby,@Updateon)", officeType);
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
        [HttpPost("UpdateOfficeType")]
        public IActionResult UpdateOfficeType(OfficeType officeType)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Update  Tbl_Master_OfficeType set   isActive = @isActive,OfficeTypeName=@OfficeTypeName,IPAddress=@IPAddress,OfficeTypeNameShort=@OfficeTypeNameShort,Updateby=@Updateby,Updateon=@Updateon  WHERE OfficeTypeId = @OfficeTypeId", officeType);
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

        [HttpDelete("DeleteOfficeType")]
        public IActionResult DeleteDistrict(int id)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Delete From Tbl_Master_OfficeType  where OfficeTypeId=@OfficeTypeId", new { OfficeTypeId = id });
            }
            return Ok(result);
        }
    }
}
