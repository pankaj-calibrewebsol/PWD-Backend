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
    public class TitleController : ControllerBase
    {
        [HttpGet("GetTitle")]
        public IActionResult GetTitle()
        {
            var Ins = new List<Title>();
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                Ins = con.Query<Title>("select  TitleId,TitleName,isActive,Updateby,Updateon,IPAddress from Tbl_Master_Title").ToList();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Ok(Ins);

        }

        [HttpGet("GetTitle/{id}")]
        public IActionResult Get(int id)
        {
            var title = new Title();
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                title = con.QuerySingle<Title>("select * from Tbl_Master_Title where titleId =@titleId", new { titleId = id });
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return Ok(title);
        }

        [HttpPost("SetTitle")]
        public IActionResult SetTitle(Title title)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();

                }
                var rowsaffected = con.Execute("insert into Tbl_Master_Title(TitleName,isActive,IPAddress,Updateby,Updateon) values(@TitleName,@isActive, @IPAddress,@Updateby,@Updateon)", title);
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
        [HttpPost("UpdateTitle")]
        public IActionResult UpdateTitle(Title title)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Update  Tbl_Master_Title set  TitleName = @TitleName, isActive = @isActive,IPAddress=@IPAddress,Updateby=@Updateby,Updateon=@Updateon  WHERE TitleId = @TitleId", title);
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

         [HttpDelete("DeleteTitle/{id}")]
        public IActionResult DeleteTitle(int id)
        {
            String result = "";
            using (System.Data.IDbConnection con = new SqlConnection(Global.ConnectionString))
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                var rowsAffected = con.Execute("Delete From Tbl_Master_Title where titleId=@titleId", new { titleId = id });
            }
            return Ok(result);
        }
    }
}

