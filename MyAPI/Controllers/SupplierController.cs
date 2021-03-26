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
    public class SupplierController : ControllerBase
    {
            private readonly IConfiguration _configuration;

            public SupplierController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet]
            public JsonResult Get()
            {
                string query = @"
                    select IdSupplier, NameSupplier,CitySupplier,CountrySupplier from dbo.Supplier";
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
            public JsonResult Post(Supplier sup)
            {
                string query = @"
                    insert into dbo.Supplier 
                    (NameSupplier,CitySupplier,CountrySupplier)
                    values 
                    (
                    '" + sup.NameSupplier + @"'
                    ,'" + sup.CitySupplier + @"'
                    ,'" + sup.CountrySupplier + @"'
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
            public JsonResult Put(Supplier sup)
            {
                string query = @"
                    update dbo.Supplier set 
                     NameSupplier = '" + sup.NameSupplier + @"'
                    ,CitySupplier = '" + sup.CitySupplier + @"'
                    ,CountrySupplier = '" + sup.CountrySupplier + @"'
                    where IdSupplier = " + sup.IdSupplier + @"
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
                    delete from dbo.Supplier
                    where IdSupplier = " + id + @" 
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
        }
    }

