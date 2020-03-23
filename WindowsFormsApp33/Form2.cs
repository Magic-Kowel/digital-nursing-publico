using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Drawing;

namespace WindowsFormsApp33
{
    public partial class Form2 : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(2, 171, 138);
            public static Color color2 = Color.FromArgb(2, 171, 138);
            public static Color color3 = Color.FromArgb(2, 171, 138);
            public static Color color4 = Color.FromArgb(2, 171, 138);
            public static Color color5 = Color.FromArgb(2, 171, 138);
        }
        public Form2()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,60);
            panel1.Controls.Add(leftBorderBtn);
            //from
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void ActivateButton(object senderBtn,Color color)
        {
            if (senderBtn!= null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(24,24,24);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                // borde isquierdo del boton
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconPictureBox1.IconChar = currentBtn.IconChar;
                iconPictureBox1.IconColor = color;


            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            { 
                currentBtn.BackColor = Color.FromArgb(24,24,24);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;


        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender,RGBColors.color1);
            OpenChildForm(new Form3() );
        }

      
        private void Form2_Load(object sender, EventArgs e)
        {
            OpenChildForm(new Form4());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Form4());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            // label1.Text = iconButton1.Text;
            OpenChildForm(new Form5());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Usuarios());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new Informacion());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            //icono pequeño
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = Color.MediumPurple;
            label1.Text = "HOME";
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            calculadora.calculadora x = new calculadora.calculadora();
            x.Show();
        }

        public Bitmap BinaryImage(Bitmap source, int umb)
        {
            // Bitmap con la imagen binaria
            Bitmap target = new Bitmap(source.Width, source.Height, source.PixelFormat);
            // Recorrer pixel de la imagen
            for (int i = 0; i < source.Width; i++)
            {
                for (int e = 0; e < source.Height; e++)
                {
                    // Color del pixel
                    Color col = source.GetPixel(i, e);
                    // Escala de grises
                    byte gray = (byte)(col.R * 0.3f + col.G * 0.59f + col.B * 0.11f);
                    // Blanco o negro
                    byte value = 0;
                    if (gray > umb)
                    {
                        value = 255;
                    }
                    // Asginar nuevo color
                    Color newColor = System.Drawing.Color.FromArgb(value, value, value);
                    target.SetPixel(i, e, newColor);

                }
            }

            return target;
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Form6());
        }
    }
}
