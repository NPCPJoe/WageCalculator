using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Wage_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string connectionString = "Data Source=JOE\\SQLEXPRESS;Initial Catalog = Wages; Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        
        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                Multiply();
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string q = (@" INSERT INTO Wage (Date, Hours,Total) VALUES('" + DTP.Text + "', '" + textBox2.Text + "', '" + tbtTotal.Text + "')");
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred: {0}", ex.Message));
            }
            Display();
        }



            void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Wage", connectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Date"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Multiply()
        {
            double a, b;

            bool isAValid = double.TryParse(textBox2.Text, out a);
            bool isBValid = double.TryParse(textBox1.Text, out b);

            if (isAValid && isBValid)
                tbtTotal.Text = (a * b).ToString();

            else
                tbtTotal.Text = "Invalid input";
        }

        private void tbtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection(str);

            OleDbCommand cmd = new OleDbCommand();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow dr = dataGridView1.Rows[i];
                if (dr.Selected == true)
                {
                    dataGridView1.Rows.RemoveAt(i);
                    try
                    {
                        con.Open();
                        cmd.CommandText = "Delete from company where ID=" + i + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }










        private void textBox3_TextChanged(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i =0; i < dataGridView1.Rows.Count;++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                
            }
            textBox3.Text = sum.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
        }
    

    


