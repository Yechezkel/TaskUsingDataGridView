using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUsingDataGridView
{
    public class DBContext
    {


        private readonly string _connectionString;



        public DBContext()
        {
            _connectionString = "Server=DESKTOP-248A3K8;Database=TaskDataGrid;User Id=sa;Password=1234;";
        }





        public DataTable MakeQueryDT(string queryStr)
        {
            DataTable output = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    try
                    {
                        
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(output);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("The Error is: " + ex.Message);
                        //Console.WriteLine("The Error is: " + ex.Message);
                    }
                }
                return output;
            }
        }



        public DataTable MakeQueryDT(string queryStr, SqlParameter[] parameters)
        {
            DataTable output = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(output);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("The Error is: " + ex.Message);
                        //Console.WriteLine("The Error is: " + ex.Message);
                    }
                }
            }
            return output;
        }



        public SqlCommand MakeQueryCMD(string queryStr)
        {
            SqlCommand output = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("The Error is: " + ex.Message);
                        //Console.WriteLine("The Error is: " + ex.Message);
                    }
                }
                return output;
            }
        }



        public SqlCommand MakeQueryCMD(string queryStr, SqlParameter[] parameters)
        {
            SqlCommand output = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("The Error is: " + ex.Message);
                        //Console.WriteLine("The Error is: " + ex.Message);
                    }
                }
                return output;
            }
        }
    }
}