﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CYP_2021_APITool
{
    public class DB
    {

        public static string DB_Insert()
        {
            String tagDB_connect_str = @"Data Source=IOT-IIS\SQLEXPRESS;Initial Catalog=CYP_Intouch;Persist Security Info=True;User ID=John;Password=80138305jJ";
            SqlConnection SQLCC = new SqlConnection(tagDB_connect_str);
            SQLCC.Open();

            if (SQLCC.State == ConnectionState.Open)
            {
                SqlTransaction t = SQLCC.BeginTransaction(); //BeginTransaction為SqlTransaction方法
                SqlCommand cinsert = new SqlCommand("INSERT INTO BarCode (intime,barcode,instatus) VALUES(20201109,'no001','true'),(20201110,'no001','true'); COMMIT TRANSACTION", SQLCC, t);
                SqlCommand cdelete = new SqlCommand("DELETE FROM BarCode",SQLCC,t);

                try
                {
                    cinsert.ExecuteNonQuery();
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

        public static string DB_Read_Web()
        {

            String tagDB_connect_str = @"Data Source=IOT-IIS\SQLEXPRESS;Initial Catalog=CYP_Intouch;Persist Security Info=True;User ID=John;Password=80138305jJ";
            SqlConnection SQLCC = new SqlConnection(tagDB_connect_str);
            SQLCC.Open();

            if (SQLCC.State == ConnectionState.Open)
            {
                SqlTransaction t = SQLCC.BeginTransaction(); //BeginTransaction為SqlTransaction方法
                SqlCommand cread = new SqlCommand("SELECT intime, barcode, instatus FROM BarCode;COMMIT TRANSACTION", SQLCC,t);

                try
                {
                    SqlDataReader reader = cread.ExecuteReader();

                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        ReadSingleRow((IDataRecord)reader);
                    }

                    // Call Close when done reading.
                    reader.Close();

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

        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

    }
}
