using SQLiteDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace hrad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Class1 pr = new Class1();
        SQLiteConnection sqlite_conn;

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlite_conn= pr.CreateConnection();
            pr.CreateTable(sqlite_conn);
            vytvoritProhlidky();
            zobrazitProhlidky();
        }

        private void vytvoritProhlidky()
        {
            for (int i = 10; i < 19; i += 2)
            {
                for (int j = 1; j < 4; j++)
                {
                    pr.InsertProhlidky(sqlite_conn, j, i, 30);
                }
            }
        }

        private void zobrazitProhlidky()
        {
         
            
            dataGridView1.Columns.Add("Okruh", "okruh");
            dataGridView1.Columns.Add("Čas", "cas");

            dataGridView1.Columns.Add("Volná místa", "mista");
            List<string> tab = new List<string>();
            tab = pr.ReadProhlidky(sqlite_conn);
            foreach (string radek in tab)
            {
                string[] data = radek.Split(';');
                dataGridView1.Rows.Add(data);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ahoj");
        }
    }

   
}
