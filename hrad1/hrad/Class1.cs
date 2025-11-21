using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo
{
    internal class Class1
    {

        

        public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database1.db; Version = 3; New = True; Compress = True; ");
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

        public void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = @"CREATE TABLE IF NOT EXISTS prohlidky
               (id INTEGER, okruh INT, cas INT, navstevnici INT)";
           string Createsql1 = @"CREATE TABLE IF NOT EXISTS vstupenky
            (id INTEGER, okruh INT, cas INT, navstevnici INT, cena INT)";
           sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
            sqlite_cmd.CommandText = Createsql1;
            sqlite_cmd.ExecuteNonQuery();

        }
        public void InsertProhlidky(SQLiteConnection conn, int okruh, int cas, int navstevnici)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"INSERT INTO prohlidky
               (okruh, cas, navstevnici) VALUES("+okruh+","+cas+","+navstevnici+"); ";
            sqlite_cmd.ExecuteNonQuery();
            

        }
        public void InsertVstupenky(SQLiteConnection conn, int okruh, int cas, int navstevnici, int cena)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"INSERT INTO vstupenky
               (okruh,cas,navstevnici,cena) VALUES("+okruh+","+cas+","+navstevnici+","+cena+"); ";
           sqlite_cmd.ExecuteNonQuery();
            

        }

        public List<string> ReadProhlidky(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM prohlidky";
            List<string> tabulka = new List<string>();
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            string radek = "";
            while (sqlite_datareader.Read())
            {
                radek = sqlite_datareader.GetInt16(1).ToString()+";";
                radek += sqlite_datareader.GetInt16(2).ToString()+";";
                radek += sqlite_datareader.GetInt16(3).ToString();
                tabulka.Add(radek);
                radek = "";
            }
            return (tabulka);
        }
    }
}
