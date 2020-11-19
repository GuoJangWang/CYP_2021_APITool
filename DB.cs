using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CYP_2021_APITool
{
    public class DB
    {

        public static string DB_Connect()
        {
            String tagDB_connect_str = @"Data Source=IOT-IIS\SQLEXPRESS;Initial Catalog=CYP_Intouch;Persist Security Info=True;User ID=John;Password=80138305jJ";
            SqlConnection SQLCC = new SqlConnection(tagDB_connect_str);
            SQLCC.Open();

            if (SQLCC.State == ConnectionState.Open)
            {
                SqlTransaction t = SQLCC.BeginTransaction(); //BeginTransaction為SqlTransaction方法
                SqlCommand cmd = new SqlCommand("INSERT INTO BarCode (intime,barcode,instatus) VALUES(20201109,'no001','true') COMMIT TRANSACTION", SQLCC, t);
                SqlCommand cmd2 = new SqlCommand("DELETE FROM BarCode",SQLCC,t);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("OK");
                    SQLCC.Close();
                    return "true";
                }
                catch
                {
                    Console.WriteLine("fail");
                    SQLCC.Close();
                    return "fail";
                }
                
            }
            else
            {
                SQLCC.Close();
                return "fail";
            }


        }

    }
}
