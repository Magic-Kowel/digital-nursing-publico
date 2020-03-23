using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp33
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }
        string MyConnection2 = "server=127.0.0.1;user id=root;database=enfermeria_utem;persistsecurityinfo=True";
        string idLocRemv;
        private void iconButton1_Click(object sender, EventArgs e)   
        {
            if (textBox1.Text.Trim() != "" || textBox2.Text.Trim() != "" || textBox3.Text.Trim() != "")
            {
                if (textBox2.Text.Trim() == textBox3.Text.Trim())
                {

                    MySqlConnection conectar = new MySqlConnection(MyConnection2);
                    conectar.Open();
                    MySqlCommand comando = conectar.CreateCommand();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "select * from usuarios where nombre_usuario='" + textBox1.Text.Trim() + "'";
                    comando.ExecuteNonQuery();
                    DataTable data = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    adapter.Fill(data);
                    int i = Convert.ToInt32(data.Rows.Count.ToString());
                    if (i == 0)
                    {
                        try
                        {
                            //This is my connection string i have assigned the database file address path  
                            //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                            //This is my insert query in which i am taking input from the user through windows forms  
                            string Query = "INSERT INTO `usuarios`(`nombre_usuario`, `contraseña`) VALUES ('" + this.textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "'); ";
                            //This is  MySqlConnection here i have created the object and pass my connection string.  
                            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                            //This is command class which will handle the query and connection object.  
                            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                            MySqlDataReader MyReader2;
                            MyConn2.Open();
                            MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                            MessageBox.Show("Registro echo ", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox3.Clear();

                            while (MyReader2.Read())
                            {
                            }
                            MyConn2.Close();
                            show_usuarios();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe un usuario con ese nombre", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conectar.Close();

                }
                else
                {
                    MessageBox.Show("las contraseñas no coinsiden", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show("rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            show_usuarios();
        }
        public void show_usuarios()
        {
            try
            {

              //  string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                string Query = "SELECT `nombre_usuario` AS NOMBRE FROM `usuarios`;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                   // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro De Eliminar ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                try
                {
                   // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                    string Query = "DELETE FROM `usuarios` WHERE nombre_usuario='" + idLocRemv + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                    show_usuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void clear() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("selecione bien la casilla", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Guardar Cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (textBox2.Text.Trim() == textBox3.Text.Trim())
                {
                    try
                    {
                        idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    try
                    {
                        //This is my connection string i have assigned the database file address path  
                       // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                        //This is my update query in which i am taking input from the user through windows forms and update the record.  
                        string Query = "UPDATE `usuarios` SET `nombre_usuario`='" + this.textBox1.Text.Trim() + "',`contraseña`='" + textBox2.Text.Trim() + "' where nombre_usuario='" + idLocRemv + "';";
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        MyConn2.Close();//Connection closed here  
                        show_usuarios();
                        clear();
                        MessageBox.Show("Usuario Actualisado Con Exito ", "", MessageBoxButtons.OK, MessageBoxIcon.None);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("las contraseñas no coinsiden", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
