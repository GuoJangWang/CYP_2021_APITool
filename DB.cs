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

        public static void DB_Connect()
        {
            String tagDB_connect_str = @"Data Source=IOT-IIS\SQLEXPRESS;Initial Catalog=CYP_Intouch;Persist Security Info=True;User ID=sa;Password=123456-s";
            SqlConnection SQLCC = new SqlConnection(tagDB_connect_str);
            SQLCC.Open();

            if (SQLCC.State == ConnectionState.Open)
            {
                
            }


            //要連接資料庫的位置
            //Initial Catalog = ArrangeSubjectDB   這是欲連接的資料庫
            //server = (Local)                               server的位置



            //SQL INSERT 語法
            // INSERT INTO  [table] ([欄位名1],[欄位名2],[欄位名3],....) VALUES (@值1, @值2, @值3,...)
            /*string strMsgInsert = @"INSERT INTO Arrangement 
            ([teachID],[CS_ID],[classDate],[classSession],[classStartTime],[classEndTime]) 
            VALUES(@value1, @value2, @value3,@value4, @value5, @value6) ";

            //C# SQL Command 物件 SqlCommand( SQL語法 , SqlConnection )   
            SqlCommand mySqlCmd = new SqlCommand();*/
        }

    }
}
