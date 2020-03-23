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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string MyConnection2 = "server=127.0.0.1;user id=root;database=enfermeria_utem;persistsecurityinfo=True";
        string idLocRemv;
        int pk_medicamento;
        int codigo;
        int fk_servisio;
        int fk_carrera;
        string curacion;
        string toma_TA;
        string toma_Glucosa;
        string inyeccion;
        string carera_query = "SELECT `nombre_carrera` FROM `carreras` WHERE `nombre_carrera`!='No Aplica'";
        bool estado_control;
        private void iconButton1_Click(object sender, EventArgs e)
        {
          // saber si elos que tienen que poner su numero de control lo pongan
            if ((textBox3.Text.Trim()=="" && (comboBox1.Text == "docente" || comboBox1.Text == "alumno" || comboBox1.Text == "administrativo")) || (textBox3.Text.Trim() != "" && comboBox1.Text.Trim() == "externo"))
            {
                estado_control = true; 
            }
            else
            {
                estado_control = false;
               // MessageBox.Show("Tipo de Usuario Invalido", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
                //comprobar los campos
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || richTextBox1.Text == "" || comboBox2.Text == ""|| estado_control == true)
                {
                    MessageBox.Show("rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    servisios();
                    get_keys();
                    try
                    {
                      //  string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                        //This is my insert query in which i am taking input from the user through windows forms  
                        string Query = "INSERT INTO `pasiente`( `nombres`, `apellidos`, `numero_control`, `tipo`, `motivo`, `fk_medicamento`, `fk_servicio`, `fk_carrera`) VALUES ('" + this.textBox1.Text.Trim() + "','" + this.textBox2.Text.Trim() + "','" + this.textBox3.Text.Trim() + "','" + this.comboBox1.SelectedItem.ToString() + "','" + richTextBox1.Text.Trim() + "','" + pk_medicamento + "','" + codigo + "','" + fk_carrera + "'); ";
                        //This is  MySqlConnection here i have created the object and pass my connection string. 

                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        //This is command class which will handle the query and connection object.  
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                      //  MessageBox.Show("Registro echo ", "", MessageBoxButtons.OK, MessageBoxIcon.None);

                        while (MyReader2.Read())
                        {
                        }
                        MyConn2.Close();
                        MessageBox.Show("Registro echo ", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                        show_pasientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
          
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            show_pasientes();
            combo_box_show_medicamentos();
            combo_box_show_carreras();

        }
        public void show_pasientes()
        {
            try
            {
               // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                string Query = "select pasiente.id_pasient as ID, pasiente.nombres AS NOMBRE,pasiente.apellidos AS APELLIDOS, pasiente.numero_control AS 'NUMERO DE CONTROL', pasiente.fecha_atendida AS 'FECHA DE ATENCION', pasiente.tipo AS 'TIPO DE PACIENTE',carreras.nombre_carrera AS CARRERA ,pasiente.motivo AS MOTIVO ,medicamento.medicamento AS MEDICAMENTO ,servicios.curacion AS CURACION ,servicios.toma_TA AS 'TOMA DE TA',servicios.inyeccion AS INYECCION,servicios.toma_glucosa AS GLUCOSA from medicamento inner join pasiente on pasiente.fk_medicamento = medicamento.id_medicamento INNER JOIN servicios on servicios.id_servicio= pasiente.fk_servicio INNER JOIN carreras on pasiente.fk_carrera=carreras.id_carrera ORDER BY `FECHA DE ATENCION` DESC";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
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
                    string Query = "delete from pasiente where id_pasient='" + idLocRemv + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                    show_pasientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
        }
        public void combo_box_show_medicamentos()
        {
            comboBox2.Items.Add("No Aplica");
            try
            {
                MySqlConnection connection = new MySqlConnection(MyConnection2);

                string selectQuery = "SELECT DISTINCT  `medicamento` FROM `medicamento` where medicamento.activo=1 and medicamento != 'No Aplica' ";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("medicamento"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void combo_box_show_carreras()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(MyConnection2);

            //    carera_query  = "SELECT `nombre_carrera` FROM `carreras` WHERE `nombre_carrera`!='No Aplica'";
                connection.Open();
                MySqlCommand command = new MySqlCommand(carera_query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader.GetString("nombre_carrera"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                try
                {

                   // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                    //Display query  
                    string Query = "select pasiente.id_pasient as ID, pasiente.nombres AS NOMBRE,pasiente.apellidos AS APELLIDOS, pasiente.numero_control AS 'NUMERO DE CONTROL', pasiente.fecha_atendida AS 'FECHA DE ATENCION' , pasiente.tipo AS 'TIPO DE PACIENTE',pasiente.motivo as  MOTIVO ,medicamento.medicamento AS MEDICAMENTO ,servicios.curacion AS CURACION ,servicios.toma_TA AS 'TOMA DE TA',servicios.inyeccion AS INYECCION,servicios.toma_glucosa AS GLUCOSA" +
                    " from medicamento inner join pasiente on pasiente.fk_medicamento = medicamento.id_medicamento INNER JOIN servicios on servicios.id_servicio= pasiente.fk_servicio WHERE pasiente.numero_control ='" + this.textBox4.Text.Trim() + "' ORDER BY `FECHA DE ATENCION` DESC; ";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    //  MyConn2.Open();  
                    //For offline connection we weill use  MySqlDataAdapter class.  
                    MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                    MyAdapter.SelectCommand = MyCommand2;
                    DataTable dTable = new DataTable();
                    MyAdapter.Fill(dTable);
                    dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                show_pasientes();
            }
        }
      private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                show_pasientes();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                MySqlConnection myConn = new MySqlConnection(MyConnection2);
    
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "SELECT fk_medicamento FROM `pasiente` WHERE nombres='" + idLocRemv + "';";
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        pk_medicamento = Convert.ToInt32( myReader[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                myConn.Close();  
            }
            catch (Exception)
            {
                MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                MySqlConnection myConn = new MySqlConnection(MyConnection2);
                MySqlConnection myConn2 = new MySqlConnection(MyConnection2);
                MySqlConnection myConn3 = new MySqlConnection(MyConnection2);
                MySqlConnection myConn4 = new MySqlConnection(MyConnection2);
                MySqlConnection myConn5 = new MySqlConnection(MyConnection2);
                MySqlConnection myConn6 = new MySqlConnection(MyConnection2);
                MySqlConnection myConn7 = new MySqlConnection(MyConnection2);

                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "SELECT nombres FROM `pasiente` WHERE id_pasient='" + idLocRemv + "';";

                MySqlCommand command2 = myConn2.CreateCommand();
                command2.CommandText = "SELECT apellidos FROM `pasiente` WHERE id_pasient='" + idLocRemv + "';";

                MySqlCommand command3 = myConn3.CreateCommand();
                command3.CommandText = "SELECT numero_control FROM `pasiente` WHERE id_pasient='" + idLocRemv + "';";

                MySqlCommand command4 = myConn4.CreateCommand();
                command4.CommandText = "SELECT tipo FROM `pasiente` WHERE id_pasient='" + idLocRemv + "';";

                MySqlCommand command5 = myConn5.CreateCommand();
                command5.CommandText = "SELECT motivo FROM `pasiente` WHERE id_pasient='" + idLocRemv + "';";
                MySqlCommand command7 = myConn7.CreateCommand();
                command7.CommandText = "SELECT medicamento from medicamento INNER join pasiente on   medicamento.id_medicamento= pasiente.fk_medicamento where  medicamento.medicamento='" + pk_medicamento + "'and pasiente.id_pasient='"+ idLocRemv + "';";
               
                MySqlDataReader myReader;

                try
                {
                    myConn.Open();
                    myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        textBox1.Text = myReader[0].ToString();
                    }
                    myConn2.Open();
                    myReader = command2.ExecuteReader();
                    while (myReader.Read())
                    {

                        textBox2.Text = myReader[0].ToString();

                    }
                    myConn3.Open();
                    myReader = command3.ExecuteReader();
                    while (myReader.Read())
                    {

                        textBox3.Text = myReader[0].ToString();
                    }
                    myConn4.Open();
                    myReader = command4.ExecuteReader();
                    while (myReader.Read())
                    {

                        comboBox1.Text = myReader[0].ToString();
                    }
                    myConn5.Open();
                    myReader = command5.ExecuteReader();
                    while (myReader.Read())
                    {

                        richTextBox1.Text = myReader[0].ToString();
                    }
                    myConn7.Open();  
                    myReader = command7.ExecuteReader();
                    while (myReader.Read())
                    {
                        comboBox2.Text = myReader[0].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                myConn.Close();
                myConn2.Close();
                myConn3.Close();
                myConn4.Close();
                myConn5.Close();
                myConn7.Close();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                comboBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch (Exception)
            {
              //  MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            show_servisios();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || richTextBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Deseas Guardar Cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    get_keys();
                    try
                    {

                       // string myConnection = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                        MySqlConnection myConn = new MySqlConnection(MyConnection2);

                        MySqlCommand command = myConn.CreateCommand();
                        command.CommandText = "SELECT fk_servicio FROM `pasiente` WHERE id_pasient='" + idLocRemv + "';";
                        MySqlDataReader myReader;
                        try
                        {
                            myConn.Open();

                            myReader = command.ExecuteReader();

                            while (myReader.Read())
                            {
                                fk_servisio = Convert.ToInt32(myReader[0].ToString());
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        myConn.Close();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

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
                      //  string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";

                        string Query = "UPDATE `pasiente` SET `id_pasient`='" + idLocRemv + "',`nombres`='" + this.textBox1.Text.Trim() + "',`apellidos`='" + this.textBox2.Text.Trim() + "',`numero_control`='" + this.textBox3.Text.Trim() + "',`tipo`='" + this.comboBox1.SelectedItem.ToString() + "',motivo='" + richTextBox1.Text + "',fk_medicamento='" + pk_medicamento + "',fk_servicio='" + fk_servisio + "',fk_carrera='" + fk_carrera + "' where id_pasient='" + idLocRemv + "';";
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        while (MyReader2.Read())
                        {
                        }
                        MyConn2.Close();//Connection closed here   

                        MessageBox.Show("Usuario Actualisado Con Exito ", "", MessageBoxButtons.OK, MessageBoxIcon.None);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    update_servisios();
                    show_pasientes();
                }
            }
        }
        public void servisios()
        {
          
            if (checkBox1.Checked==true)
            {
                curacion = "si";
            }
            else
            {
                curacion ="no";
            }
         
            if (checkBox3.Checked == true)
            {
                inyeccion="si";
            }
            else
            {
                inyeccion = "no";
            }
            if (textBox5.Text=="")
            {
                toma_Glucosa = "no";
            }
            else
            {
                toma_Glucosa = textBox5.Text; 
            }
            if (textBox6.Text == "")
            {
                toma_TA = "no";
            }
            else
            {
                toma_TA = textBox6.Text;
            }
            try
            {
                //This is my connection string i have assigned the database file address path  
               // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "INSERT INTO `servicios`( `curacion`, `toma_TA`, `inyeccion`, `toma_glucosa`) VALUES ('" + curacion.Trim() + "','" + toma_TA.Trim() + "','" + inyeccion.Trim() + "','" + toma_Glucosa.Trim() + "');SELECT LAST_INSERT_ID(); ";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
               
                MyConn2.Open();
                codigo = Convert.ToInt32(MyCommand2.ExecuteScalar());
             //   textBox4.Text = textBox4.Text + codigo;
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
               
             
               

                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void show_servisios()
        {
            try
            {
                idLocRemv = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                if (idLocRemv.Trim() == "si")
                {
                    checkBox1.Checked = true;
                    curacion = "si";
                }
                else
                {
                    checkBox1.Checked = false;
                    curacion = "no";
                }

                idLocRemv = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

                idLocRemv = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                if (idLocRemv.Trim() == "si")
                {
                    checkBox3.Checked = true;
                    inyeccion = "si";
                }
                else
                {
                    checkBox3.Checked = false;
                    inyeccion = "no";
                }
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

            }
            catch ( Exception ex)
            {

            }
        }
        public void update_servisios()
        {
            try
            {
                idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                MySqlConnection myConn = new MySqlConnection(MyConnection2);
       
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "SELECT fk_servicio FROM `pasiente` WHERE id_pasient='" + idLocRemv + "';";

                MySqlDataReader myReader;

                try
                {
                    myConn.Open();
                    myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        fk_servisio =Convert.ToInt32( myReader[0].ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                myConn.Close();
            
            }
            catch (Exception)
            {
              
            }

            if (checkBox1.Checked == true)
            {
            
                curacion = "si";
            }
            else
            {
               
                curacion = "no";
            }

            if (checkBox3.Checked == true)
            {
                inyeccion = "si";
            }
            else
            {
                inyeccion = "no";
            }
            if (textBox5.Text == "")
            {
                toma_Glucosa = "no";
            }
            else
            {
                toma_Glucosa = textBox5.Text.Trim();
            }
            if (textBox6.Text == "")
            {
                toma_TA = "no";
            }
            else
            {
                toma_TA = textBox6.Text.Trim();
            }
            try
            {
                idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //This is my connection string i have assigned the database file address path  
                //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                string Query = "UPDATE `servicios` SET `id_servicio`='" + fk_servisio + "',`curacion`='" + curacion + "',`toma_TA`='" + toma_TA.Trim() + "',`inyeccion`='" + inyeccion + "',`toma_glucosa`='" + toma_Glucosa.Trim() + "' where id_servicio='" + fk_servisio + "';";
               //  textBox4.Text = Query;
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
              //  MessageBox.Show("Usuario Actualisado Con Exito ", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                show_pasientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void get_keys()
        {
            try
            {

               // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                MySqlConnection myConn = new MySqlConnection(MyConnection2);
                MySqlConnection myConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "SELECT id_medicamento FROM `medicamento` WHERE medicamento='" + comboBox2.SelectedItem.ToString() + "';";

                MySqlCommand command2 = myConn2.CreateCommand();
                command2.CommandText = "SELECT `id_carrera` FROM `carreras` WHERE nombre_carrera='" + comboBox4.SelectedItem.ToString().Trim() + "';";

                MySqlDataReader myReader;

                try
                {
                    myConn.Open();
                    myConn2.Close();
                    myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        pk_medicamento = Convert.ToInt32(myReader[0].ToString());
                    }
                    myConn2.Open();
                    myReader = command2.ExecuteReader();
                    while (myReader.Read())
                    {
                        fk_carrera = Convert.ToInt32(myReader[0].ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                myConn.Close();
                myConn2.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)

        {
            if (this.comboBox1.SelectedItem.ToString() == "docente")
            {
                textBox3.Enabled = true;
                comboBox4.DataSource = null;
                comboBox4.Items.Clear();
                carera_query = "SELECT nombre_carrera FROM `carreras` " +
                    "WHERE nombre_carrera='Mantenimiento Industrial' or nombre_carrera='Ingeniería en Energía Renovables' or nombre_carrera='Ingeniería en Energía Renovables' or nombre_carrera='Financiera Fiscal' or nombre_carrera='Diseño y Gestión en Redes Logísticas' or nombre_carrera='Logística Comercial Global' or nombre_carrera='Procesos Químicos' or nombre_carrera='ING.Tecnologías de la Información' " +
                    "or nombre_carrera='Licenciatura en Gastronomía'";
                combo_box_show_carreras();
            }
            else if (this.comboBox1.SelectedItem.ToString() == "alumno")
            {
                textBox3.Enabled = true;
                comboBox4.DataSource = null;
                comboBox4.Items.Clear();
                carera_query = "SELECT `nombre_carrera` FROM `carreras` WHERE `nombre_carrera`!='No Aplica'";
                combo_box_show_carreras();
            }

            if (this.comboBox1.SelectedItem.ToString()== "administrativo" || this.comboBox1.SelectedItem.ToString() == "externo")
            {
                textBox3.Enabled = false;
                this.comboBox4.Enabled = false;
                comboBox4.Items.Add("No Aplica");
                comboBox4.Text = "No Aplica";
            }
            else
            {
                textBox3.Enabled = false;
                this.comboBox4.Enabled = true;
                comboBox4.Items.Remove("No Aplica");

            }
            if (this.comboBox1.SelectedItem.ToString() == "externo")
            {
                this.textBox3.Enabled = false;
                this.textBox3.Clear();
                
            }
            else
            {
                this.textBox3.Enabled = true;

            }
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '/') && ((sender as TextBox).Text.IndexOf('/') > -1))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//in abilita las moduficasiones
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//in abilita las moduficasiones
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//in abilita las moduficasiones
        }
    }
}
