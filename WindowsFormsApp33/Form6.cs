using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp33
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        string Query;
        private void Form6_Load(object sender, EventArgs e)
        {
            
        }
        string MyConnection2 = "server=127.0.0.1;user id=root;database=enfermeria_utem;persistsecurityinfo=True";
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "alumno")
            {
                alumnos();
                
            }
            else if(comboBox2.Text == "docente"){
                docente();
              
            }
            else if (comboBox2.Text == "administrativo")
            {
                administrativo();
              
            }
            else if (comboBox2.Text == "externo")
            {
                externos();
                
            }
            else
            {

            }
        }

        public void alumnos()
        {
            try
            {

               /// string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                 Query = "SELECT carreras.nombre_carrera as Carrera , count(*) as Cantidad " +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 1 and pasiente.tipo = 'alumno'  " + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT  carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 2 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 3 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 4 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 5 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 6 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 7 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 8 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT  carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 9 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT  carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 10 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT  carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 11 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 12 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT   carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 13 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT  carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 14 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT  carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 15 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
" SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 16 and pasiente.tipo = 'alumno'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "' ;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource= dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                   // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void docente()
        {
            try
            {

            //    string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                  Query =
"SELECT carreras.nombre_carrera as Carrera , count(*) as Cantidad " +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 2 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 4 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 6 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 8 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 10 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 13 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 15 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'" +
"UNION all " +
"SELECT carreras.nombre_carrera  , count(*)" +
"from pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE carreras.id_carrera = 16 and pasiente.tipo = 'docente'" + "and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'  ; ";
               
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

        public void administrativo()
        {
            try
            {

                //string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                 Query ="SELECT carreras.nombre_carrera as Carrera , count(*) as Cantidad from " +
                    "pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE" +
                    " carreras.id_carrera = 17 and pasiente.tipo = 'administrativo' and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'; ";
                
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
        public void externos()
        {
            try
            {

              //  string MyConnection2 = "server=127.0.0.1; database=enfermeria_utem; Uid=root; pwd=;SslMode = none";
                //Display query  
                  Query = "SELECT carreras.nombre_carrera as Carrera , count(*) as Cantidad from " +
                    "pasiente INNER JOIN carreras on pasiente.fk_carrera = carreras.id_carrera WHERE" +
                    " carreras.id_carrera = 17 and pasiente.tipo = 'externo' and pasiente.fecha_atendida >= '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim() + "' and pasiente.fecha_atendida <='" + this.dateTimePicker2.Value.ToString("yyyy-MM-dd").Trim() + "'; ";

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

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;//in abilita las moduficasiones
        }
    }
}
