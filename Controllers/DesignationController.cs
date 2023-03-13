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
    public class DesignationController : Controller
    {
        [HttpGet("GetDesignation")]
        public IActionResult GetDesignation()
        {
            var Ins = new List<Designation>();
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                Ins = con.Query<Designation>("select  DesignationId,OfficeTypeId,DesignationName,DesignationShort,DesignationOrderId,isActive,Updateby,Updateon,IPAddress from Tbl_Master_Designation").ToList();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Ok(Ins);

        }

        [HttpPost("SetDesignation")]
        public IActionResult SetDesignation(Designation designation)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                var rowsaffected = con.Execute("insert into Tbl_Master_Designation(OfficeTypeId,DesignationName,DesignationShort,DesignationOrderId,isActive,IPAddress,Updateby,Updateon) values(@OfficeTypeId,@DesignationName,@DesignationShort,@DesignationOrderId,@isActive, @IPAddress,@Updateby,@Updateon)", designation);
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
        [HttpPost("UpdateDesignation")]
        public IActionResult UpdateDesignation(Designation designation)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Update  Tbl_Master_Designation set  OfficeTypeId = @OfficeTypeId, isActive = @isActive,DesignationName=@DesignationName,IPAddress=@IPAddress,DistShortName=@DistShortName,DesignationOrderId=@DesignationOrderId,Updateby=@Updateby,Updateon=@Updateon  WHERE DesignationId = @DesignationId", designation);
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

        [HttpDelete("DeleteDesignation")]
        public IActionResult DeleteDesignation(int id)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Delete From Tbl_Master_Designation  where DesignationId=@DesignationId", new { DesignationId = id });
            }
            return Ok(result);
        }
    }
}
