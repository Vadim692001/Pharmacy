using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public GoodsController(IConfiguration configuration, IWebHostEnvironment evn)
        {
            _configuration = configuration;
            _env = evn;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select IdGoods, NameGoods,CountGoods,PriceGoods from dbo.Goods";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PharmacyAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Goods goo)
        {
            string query = @"
                    insert into dbo.Goods 
                    (NameGoods,PriceGoods,CountGoods)
                    values 
                    (
                    '" +  goo.NameGoods + @"'
                    ,'" + goo.PriceGoods + @"'
                    ,'" + goo.CountGoods + @"'
                 
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PharmacyAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Goods goo)
        {
            string query = @"
                    update dbo.Goods set 
                     NameGoods = '" + goo.NameGoods + @"'
                    ,CountGoods = '" + goo.CountGoods + @"'
                    ,PriceGoods = '" + goo.PriceGoods + @"'
                    where IdGoods = " + goo.IdGoods + @"
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PharmacyAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.Goods
                    where IdGoods = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PharmacyAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [Route("GetSortGoodsName")]
        public JsonResult GetSortGoodsName()
        {
            string query = @"
                    select IdGoods,CountGoods,NameGoods ,PriceGoods from dbo.Goods
                    order by NameGoods
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PharmacyAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [Route("GetSortCountGoods")]
        public JsonResult GetSortCountGoodsName()
        {
            string query = @"
                     select IdGoods,CountGoods,NameGoods ,PriceGoods from dbo.Goods
                    order by CountGoods
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PharmacyAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        

    }
}
