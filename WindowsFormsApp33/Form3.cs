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
using FontAwesome.Sharp;
namespace WindowsFormsApp33
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string MyConnection2 = "server=127.0.0.1;user id=root;database=enfermeria_utem;persistsecurityinfo=True";
                              
        string idLocRemv;
        int id_fecha_caducacion;
        int id_medicamento;
        private void Form3_Load(object sender, EventArgs e)
        {
            show_medicamentos();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
              


                    try
                    {
                        //This is my connection string i have assigned the database file address path  
                       // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                        //This is my insert query in which i am taking input from the user through windows forms  
                        string Query = "INSERT INTO `medicamento` (`medicamento`) VALUES ('" + this.textBox1.Text + "');SELECT LAST_INSERT_ID(); ";
                        //This is  MySqlConnection here i have created the object and pass my connection string.  
                        MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                        //This is command class which will handle the query and connection object.  
                        MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;

                        MyConn2.Open();
                        id_medicamento = Convert.ToInt32(MyCommand2.ExecuteScalar());

                        MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  


                        MessageBox.Show("Registro echo ", "", MessageBoxButtons.OK, MessageBoxIcon.None);

                        while (MyReader2.Read())
                        {
                        }
                        MyConn2.Close();
                        lote_add();
                        show_medicamentos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                
            }
            else
            {
                MessageBox.Show("Es Nesesario Agregar Nombre Del Medicamento ", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        public void show_medicamentos()
        {
            try
            {

               // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                string Query = "select medicamento.medicamento as MEDICAMENTO, fecha_caducidad.fecha_caducidad as CADUCIDAD ,fecha_caducidad.cantidad AS CANTIDAD  ,fecha_caducidad.unidades AS UNIDADES ,fecha_caducidad.id_fecha_caducidad as 'ID LOTE' " +
                    "from medicamento inner join fecha_caducidad on medicamento.`id_medicamento`= fecha_caducidad.fk_medicamento  WHERE medicamento.activo=1  ORDER BY `CADUCIDAD` ASC; ";
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Guardar Cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    try
                    {
                        //This is my connection string i have assigned the database file address path  
                        //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                        //This is my update query in which i am taking input from the user through windows forms and update the record.  
                        string Query = "UPDATE `medicamento` SET `medicamento`='" + idLocRemv + "',`medicamento`='" + this.textBox1.Text.Trim() + "' where medicamento='" + idLocRemv + "';";
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
                        MessageBox.Show("Usuario Actualisado Con Exito ", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                        show_medicamentos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
               // string myConnection = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                MySqlConnection myConn = new MySqlConnection(MyConnection2);
                MySqlCommand command = myConn.CreateCommand();
                command.CommandText = "SELECT medicamento FROM `medicamento` WHERE medicamento='" + idLocRemv + "'  ;";
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        textBox1.Text = myReader[0].ToString();
                    }
                    get_id_medicamento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                myConn.Close();
                dateTimePicker1.Value =Convert.ToDateTime( dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                numericUpDown1.Value= Convert.ToDecimal( dataGridView1.SelectedRows[0].Cells[2].Value.ToString());

            }
            catch (Exception)
            {
                MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {

                    //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                    //Display query  
                    string Query = "select  medicamento.medicamento as MEDICAMENTO, fecha_caducidad.fecha_caducidad as CADUCIDAD ,fecha_caducidad.cantidad AS CANTIDAD  ,fecha_caducidad.unidades AS UNIDADES ,fecha_caducidad.id_fecha_caducidad as 'ID LOTE' from medicamento inner join" +
                        " fecha_caducidad on medicamento.`id_medicamento`= fecha_caducidad.fk_medicamento where medicamento.activo=1 and  medicamento.medicamento='" + this.textBox2.Text.Trim() + "'ORDER BY `CADUCIDAD` ASC; ";
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
            else
            {
                show_medicamentos();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro De Eliminar ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
              
                try
                {
                   // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                    string Query = "UPDATE `medicamento` SET `activo`=0 WHERE medicamento='" + idLocRemv + "';";
                       
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                    show_medicamentos();
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.Message);
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                show_medicamentos();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource != null)
                {
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "Excel (*.xls)|*.xls";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add();
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                        //exportar cabeceras dgvLog
                        for (int i = 1; i <= this.dataGridView1.Columns.Count-1; i++)
                        {
                            hoja_trabajo.Cells[1, i] = this.dataGridView1.Columns[i - 1].HeaderText;
                        }

                        //Recorremos el DataGridView rellenando la hoja de trabajo con los datos
                        for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < this.dataGridView1.Columns.Count-1; j++)
                            {
                                hoja_trabajo.Cells[i + 2, j + 1] = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                    }
                }
                MessageBox.Show("Ecxelcreado ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void caducasion_fechas()
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
             //   string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "INSERT INTO `fecha_caducidad`( `fecha_caducidad`, `cantidad`, `unidades`,fk_medicamento) VALUES ('" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "','" + this.numericUpDown1.Value + "','" + this.comboBox1.SelectedItem.ToString() +"','"+id_medicamento+"'); ";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;

                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  


                MessageBox.Show("Registro echo ", "", MessageBoxButtons.OK, MessageBoxIcon.None);

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

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || numericUpDown1.Value == 0)
            {
                MessageBox.Show("Rellene Todos Los Campos ", "", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            { 
            get_id_medicamento();
            caducasion_fechas();
            show_medicamentos();
            }
        }
           
        public void get_id_medicamento()
        {
            try
            {
                idLocRemv = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception ex) {
                MessageBox.Show("selecione bien la casilla si va añadir un lote en un medicamento existente" + ex+ MessageBoxButtons.OK+ MessageBoxIcon.Stop);

            }
            //string myConnection = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
            MySqlConnection myConn = new MySqlConnection(MyConnection2);


            MySqlCommand command = myConn.CreateCommand();
            command.CommandText = "SELECT `id_medicamento` FROM `medicamento` WHERE medicamento='" + idLocRemv + "';";
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    id_medicamento = Convert.ToInt32(myReader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            myConn.Close();
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas Guardar Cambios?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    id_fecha_caducacion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                    try
                    {

                        //This is my connection string i have assigned the database file address path  
                       // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";

                        string Query = "UPDATE `fecha_caducidad` SET `fecha_caducidad`='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "',cantidad='" + numericUpDown1.Value + "',unidades='" + this.comboBox1.SelectedItem.ToString() + "' where id_fecha_caducidad='" + id_fecha_caducacion + "';";
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
                }
                
                catch (Exception)
                {
                    MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                show_medicamentos();
            }
        }
        public void lote_add()
        {
            try
            {
                //This is my connection string i have assigned the database file address path  
                //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //This is my insert query in which i am taking input from the user through windows forms  
                string Query = "INSERT INTO `fecha_caducidad`( `fecha_caducidad`, `cantidad`, `unidades`, `fk_medicamento`) VALUES ('" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "','"+numericUpDown1.Value+"','"+ this.comboBox1.SelectedItem.ToString() + "','"+ id_medicamento + "');";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                //This is command class which will handle the query and connection object.  
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;

                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  


                MessageBox.Show("Registro echo ", "", MessageBoxButtons.OK, MessageBoxIcon.None);

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

        private void iconButton6_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Seguro De Eliminar ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    id_medicamento = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Selesione la casilla bien ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                try
                {
                   // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                    string Query = "DELETE FROM `fecha_caducidad` WHERE id_fecha_caducidad='" + id_medicamento + "';";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                    show_medicamentos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        { 
                e.Handled = true;//in abilita las moduficasiones
        }
    }
}
