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
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                    select IdEmployees, SuernameEmployees, NameEmployees, MiddleNameEmployees, Posada 
                    from dbo.Employees";
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
        public JsonResult Post(Employees emp)
        {
            string query = @"
                    insert into dbo.Employees 
                    (SuernameEmployees,NameEmployees,MiddleNameEmployees,Posada)
                    values 
                    (
                    '" + emp.SuernameEmployees + @"'
                    ,'" + emp.NameEmployees + @"'
                    ,'" + emp.MiddleNameEmployees + @"'
                    ,'" + emp.Posada + @"'
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
        public JsonResult Put(Employees emp)
        {
            string query = @"
                    update dbo.Employees set 
                     SuernameEmployees = '" + emp.SuernameEmployees + @"'
                    ,NameEmployees = '" + emp.NameEmployees + @"'
                    ,MiddleNameEmployees = '" + emp.MiddleNameEmployees + @"'
                    ,Posada = '" + emp.Posada + @"'
                    
                    where IdEmployees = " + emp.IdEmployees + @"
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
                    delete from dbo.Employees
                    where IdEmployees = " + id + @" 
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
        [Route("GetSortSuernameEmployees")]
        public JsonResult GetSortSuernameEmployees()
        {
            string query = @"
                select IdEmployees, SuernameEmployees, NameEmployees, MiddleNameEmployees, Posada from dbo.Employees
                 order by SuernameEmployees
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
        [Route("GetSortPosadaEmployees")]
        public JsonResult GetSortPosadaEmployees()
        {
            string query = @"
                select IdEmployees, SuernameEmployees, NameEmployees, MiddleNameEmployees, Posada from dbo.Employees
                 
                 order by Posada";
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