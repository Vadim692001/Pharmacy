using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public DeliveriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select IdOperation,IdEmployees,IdGoods,IdSupplier,CountDeliveries,PricePurchase,convert(varchar(10),Data,120) as Data from dbo.Deliveries";
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
        public JsonResult Post(Deliveries del)
        {
            string query = @"
                    insert into dbo.Deliveries 
                    (Data,PricePurchase,CountDeliveries)
                    values 
                    (
                    '"  +  del.Data + @"'
                    ,'" + del.PricePurchase + @"'
                    ,'" + del.CountDeliveries+ @"'
              
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
        public JsonResult Put(Deliveries del)
        {
            string query = @"
                    update dbo.Deliveries set 
                     IdEmployees = '" + del.IdEmployees + @"'
                    ,IdGoods = '" + del.IdGoods + @"'
                    ,IdSupplier = '" + del.IdSupplier + @"'
                    ,PricePurchase = '" + del.PricePurchase + @"' 
                    ,CountDeliveries = '" + del.CountDeliveries + @"'
                    ,Data = '" + del.Data + @"'
                    where IdOperation = " + del.IdOperation + @"
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
                    delete from dbo.Deliveries
                    where IdOperation = " + id + @" 
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

        [Route("GetAllSupplier")]
        public JsonResult GetAllDeliveries()
        {
            string query = @"
                    select NameSupplier from dbo.Supplier
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
        [Route("GetAllGoods")]
        public JsonResult GetAllGoods()
        {
            string query = @"
                    select NameGoods from dbo.Goods
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
        [Route("GetAllEmployees")]
        public JsonResult GetAllEmployees()
        {
            string query = @"
                    select SuernameEmployees from dbo.Employees
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

