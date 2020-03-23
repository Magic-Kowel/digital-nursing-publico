using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.IO;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using System.Threading;
namespace WindowsFormsApp33
{
    public partial class Form1 : Form
    {
        //private IconButton currentBtn;
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (checkBox1.Checked == true && textBox1.Text != "USER NAME")
                {
                    TextWriter archivo;
                    archivo = new StreamWriter("cache_login.txt");
                    archivo.WriteLine(textBox1.Text);
                    archivo.Close();
                }
            }
            catch (Exception ex)
            {

            }
           
            try
            {
                MySqlConnection conectar = new MySqlConnection("server=127.0.0.1;user id=root;database=enfermeria_utem;persistsecurityinfo=True");
                conectar.Open();
                MySqlCommand comando = conectar.CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from usuarios where nombre_usuario='" + textBox1.Text + "'and contraseña='" + textBox2.Text + "'";
                comando.ExecuteNonQuery();
                DataTable data = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                adapter.Fill(data);
                int i = Convert.ToInt32(data.Rows.Count.ToString());
                if (i != 0)
                {
                    this.Hide();
                    Form2 frm = new Form2();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña invalido." + " Intente de nuevo", "ERROR DE AUTENTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                conectar.Close();
            }
            catch (Exception ex)
            {
               
            }


        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            iconPictureBox1.IconColor=Color.FromArgb(255, 255, 255);
            textBox1.ForeColor = Color.FromArgb(255, 255, 255);
            panel1.BackColor = Color.FromArgb(255, 255, 255);

           
            iconPictureBox2.IconColor = Color.FromArgb(255, 255, 255);
            textBox2.ForeColor = Color.FromArgb(255, 255, 255);
            panel2.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
            panel2.BackColor = Color.FromArgb(255, 255, 255);
            iconPictureBox2.IconColor = Color.FromArgb(255, 255, 255);
            textBox2.ForeColor = Color.FromArgb(255, 255, 255);

            iconPictureBox1.IconColor = Color.FromArgb(255,255, 255);
            textBox1.ForeColor = Color.FromArgb(255,255,255);
            panel1.BackColor = Color.FromArgb(255,255,255);

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;user id=root;database=enfermeria_utem;persistsecurityinfo=True"))
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                ProcessStartInfo info = new ProcessStartInfo();

                info.UseShellExecute = true;
                info.FileName = "xampp_start.exe";
                info.WorkingDirectory = "C:\\xampp";

                Process.Start(info);
                
            }
          
            try
            {
                StreamReader sr = new StreamReader("cache_login.txt", Encoding.ASCII);

                   textBox1.Text = sr.ReadToEnd().Trim(); ;
                   sr.Close();
            }
            catch(Exception)
            {
                TextWriter archivo;
                archivo = new StreamWriter("cache_login.txt");
                archivo.Close();
            }
           
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
         //   System.Diagnostics.Process.Start("https://www.facebook.com/publicentermzlo/");
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TextWriter archivo;
                archivo = new StreamWriter("cache_login.txt");
                archivo.WriteLine("USER NAME");
                archivo.Close();
                textBox1.Text = "USER NAME";
            }
            catch (Exception)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
