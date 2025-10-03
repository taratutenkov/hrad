using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo
{
    class Program
    {

        

        public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
           // Open the connection:
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = @"CREATE TABLE prohlidky
               (id INTEGER, okruh INT, cas INT, nastevnici INT)";
           string Createsql1 = @"CREATE TABLE vstupenky
            (id INTEGER, okruh INT, cas INT, navstevnici INT, cena INT)";
           sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();

        }
        static void InsertProhlidky(SQLiteConnection conn, int okruh, int cas, int navstevnici)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"INSERT INTO prohlidky
               (okruh, cas, navstevnici) VALUES("+okruh+","+cas+","+navstevnici+"); ";
            sqlite_cmd.ExecuteNonQuery();
            

        }
        static void InsertVstupenky(SQLiteConnection conn, int okruh, int cas, int navstevnici, int cena)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"INSERT INTO vstupenky
               (okruh,cas,navstevnici,cena) VALUES("+okruh+","+cas+","+navstevnici+","+cena+"); ";
           sqlite_cmd.ExecuteNonQuery();
            

        }

        static void ReadProhlidky(SQLiteConnection conn ,int okruh,int cas, int nastevnici)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM prohlidky";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            
        }
    }
}
