using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection connect = new NpgsqlConnection("server=localHost;port=5432; UserId=postgres; password=4198brl-; database=Hospital");

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command1 = new NpgsqlCommand("insert into \"Doctor\" values(@doctorID,@name)", connect);
            command1.Parameters.AddWithValue("@doctorID", int.Parse(textBox1.Text));
            command1.Parameters.AddWithValue("@name", textBox2.Text);
            command1.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Doctor insert operation has been done succesfully");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("update \"Doctor\" set \"name\"=@name where \"doctorID\"=@doctorID", connect);
            command2.Parameters.AddWithValue("@doctorID", int.Parse(textBox1.Text));
            command2.Parameters.AddWithValue("@name", textBox2.Text);
            command2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Doctor update operation has been done succesfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from \"Doctor\"";
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter(query, connect);
            DataSet ds = new DataSet();
            adapt.Fill(ds, "Doctor");
            //connect.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            NpgsqlCommand command2 = new NpgsqlCommand("delete from \"Doctor\" where \"doctorID\"=@doctorID", connect);
            command2.Parameters.AddWithValue("@doctorID", int.Parse(textBox1.Text));
            command2.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Doctor delete operation has been done succesfully");
        }
    }
}
