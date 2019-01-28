using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCApplication.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVCApplication.Models
{
    public class Car_Search1
    {
        public string conn_string = "Data Source=VABXSQLD45\\FINANCE;Initial Catalog=devInternShubham;Integrated Security=True";
        public List<Car> detail = new List<Car>();


        public List<Car> getData(string category = "Sedan", string Car1 = "SX4", string Region = "North"
            , string Color = "Matt-Black", string Range="20" )
        {
           try
            {
                
                SqlConnection conn = new SqlConnection(conn_string);
                conn.Open();
                string cmd = "select * from Manufacture where category =" + category + " and Car= " + Car1
                    + " and Region =" + Region + " and color=" + Color + " and Price<=" + Range;

                SqlCommand command = new SqlCommand(cmd,conn);              
                
                SqlDataReader read = command.ExecuteReader();
                Car c= new Car();
                while (read.Read())
                {
                    try
                    {
                        c.id = Convert.ToInt32(read.GetValue(0));
                    }
                    catch (Exception e)
                    {                        
                        c.id = 911;                                           
                    }
                    
                    c.Name = read.GetValue(2).ToString();
                    c.price = read.GetValue(5).ToString();
                    c.color = read.GetValue(4).ToString();
                    c.region = read.GetValue(3).ToString();
                    c.category = read.GetValue(1).ToString();                    
                    detail.Add(c);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return detail;
        }
    }
}