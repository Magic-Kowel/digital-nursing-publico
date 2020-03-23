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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp33
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        string MyConnection2 = "server=127.0.0.1;user id=root;database=enfermeria_utem;persistsecurityinfo=True";
        string tipo_user;
        string carrera;
        string carera_query = "SELECT  `nombre_carrera` FROM `carreras`";
        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {

                //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                string Query = "select pasiente.id_pasient AS ID, pasiente.nombres AS NOMBRE,pasiente.apellidos AS APELLIDOS , pasiente.numero_control AS'NUMERO DE CONTROL', pasiente.fecha_atendida AS 'FECHA DE ATENCION', pasiente.tipo AS 'TIPO DE PACIENTE' ,carreras.nombre_carrera AS CARRERA ,pasiente.motivo AS 'MOTIVO' ,medicamento.medicamento AS MEDICAMENTO ,servicios.curacion AS 'CURACION' ,servicios.toma_TA AS 'TOMA DE TA',servicios.inyeccion AS 'INYECCION' ,servicios.toma_glucosa AS GLUCOSA " +
                    " from medicamento inner join pasiente on pasiente.fk_medicamento = medicamento.id_medicamento INNER JOIN servicios on servicios.id_servicio= pasiente.fk_servicio INNER JOIN carreras on pasiente.fk_carrera=carreras.id_carrera";
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
            combo_box_show_carreras();
        }

        private void iconButton1_Click(object sender, EventArgs e)
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
                        for (int i = 1; i <= this.dataGridView1.Columns.Count; i++)
                        {
                            hoja_trabajo.Cells[1, i] = this.dataGridView1.Columns[i - 1].HeaderText;
                        }

                        //Recorremos el DataGridView rellenando la hoja de trabajo con los datos
                        for (int i = 0; i < this.dataGridView1.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                            {
                                hoja_trabajo.Cells[i + 2, j + 1] = this.dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Ecxelcreado ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "alumno")
                {
                    tipo_user = "pasiente.tipo = 'alumno'";
                }
                if (comboBox2.Text == "administrativo")
                {
                    tipo_user = "pasiente.tipo = 'administrativo'";
                }
                if (comboBox2.Text == "docente")
                {
                    tipo_user = "pasiente.tipo = 'docente'";
                }
                if (comboBox2.Text == "externo")
                {
                    tipo_user = "pasiente.tipo = 'externo'";
                }
                if (comboBox2.Text == "Todos")
                {
                    tipo_user = " pasiente.tipo != 'Todos' ";
                }
                if (comboBox1.Text == "Todos")
                {
                    carrera = " carreras.nombre_carrera!='Todos";
                }
                else
                {
                    carrera = "carreras.nombre_carrera='" + comboBox1.SelectedItem.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            try
            {

               // string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                string Query = "select pasiente.id_pasient as ID, pasiente.nombres AS NOMBRE,pasiente.apellidos AS APELLIDOS, pasiente.numero_control AS 'NUMERO DE CONTROL', pasiente.fecha_atendida AS 'FECHA DE ATENCION', pasiente.tipo AS  'TIPO DE PASIENTE' ,carreras.nombre_carrera AS CARRERA ,pasiente.motivo AS MOTIVO ,medicamento.medicamento AS MEDICAMENTO ,servicios.curacion AS CURACION ,servicios.toma_TA AS 'TOMA DE T/A' ,servicios.inyeccion ,servicios.toma_glucosa AS GLUCOSA  " +
                    "from medicamento inner join pasiente on pasiente.fk_medicamento = medicamento.id_medicamento INNER JOIN servicios on servicios.id_servicio= pasiente.fk_servicio INNER JOIN carreras on pasiente.fk_carrera=carreras.id_carrera WHERE pasiente.fecha_atendida>='" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida<='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'and "+carrera+ "'and "+ tipo_user + "and "+ tipo_user + ";";
               //textBox1.Text = Query;
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedItem.ToString() == "docente")
            {
                comboBox1.DataSource = null;
                comboBox1.Items.Clear();
                carera_query = "SELECT nombre_carrera FROM `carreras` " +
                    "WHERE nombre_carrera='Mantenimiento Industrial' or nombre_carrera='Ingeniería en Energía Renovables' or nombre_carrera='Ingeniería en Energía Renovables' or nombre_carrera='Financiera Fiscal' or nombre_carrera='Diseño y Gestión en Redes Logísticas' or nombre_carrera='Logística Comercial Global' or nombre_carrera='Procesos Químicos' or nombre_carrera='ING.Tecnologías de la Información' " +
                    "or nombre_carrera='Licenciatura en Gastronomía'";
                combo_box_show_carreras();
            }
            else
            {
                comboBox1.DataSource = null;
                comboBox1.Items.Clear();
                carera_query = "SELECT  `nombre_carrera` FROM `carreras`";
                combo_box_show_carreras();
            }
            if (this.comboBox2.SelectedItem.ToString() == "administrativo" || this.comboBox2.SelectedItem.ToString() == "externo")
            {
                this.comboBox1.Enabled = false;
                this.comboBox1.Text = "No Aplica";
               
            }
            else
            {
                this.comboBox1.Enabled = true;
            }
            
        }
        public void combo_box_show_carreras()
        {
            comboBox1.Items.Add("Todos");
            try
            {
                MySqlConnection connection = new MySqlConnection(MyConnection2);

                
                connection.Open();
                MySqlCommand command = new MySqlCommand(carera_query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("nombre_carrera"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//in abilita las moduficasiones
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//in abilita las moduficasiones
        }
    }
}
