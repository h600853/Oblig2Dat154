using SpaceSim;
using System.Security.Cryptography.Xml;
using Timer = System.Windows.Forms.Timer;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {


        Star sun = new Star("Sun", 0, 0, 696.340, 26, "yellow");

            //orbital radius / 10 in million km
            //object radius / 100
        List<SpaceObject> planets = new List<SpaceObject>() {
    new Planet("Mercury", 5.791, 87.97, 2.440, 59, "DarkGray"),
        new Planet("Venus", 10.82, 224.7, 6.052, -243, "Yellow"),
         new Planet("Earth", 14.96, 365.2, 6.371, 24, "Blue"),
        new Planet("Mars", 22.8, 687, 3.390, 25, "Red"),
       new Planet("Jupiter", 77.85, 4331, 69.911, 10, "Orange"),
        new Planet("Saturn", 140.0, 10747, 58.232, 11, "Yellow"),
         new Planet("Uranus", 290.0, 30589, 25.362, -17, "LightBlue"),
        new Planet("Neptune", 450.0, 59800, 24.622, 16, "DarkBlue"),
        new DwarfPlanet("Pluto", 590.0, 90560.0, 1.1883, -6.39, "Brown")

    };

        private int zoom = 1;
        private readonly Timer timer = new();
        private int time = 0;
    
        private int OrbitalSpeed = 1;
        private int scaleup;
        private int scaledown;
        private bool showorbitalradius = false;
        



        public Form1()
        {
            InitializeComponent();
            vScrollBar1.Value = zoom;
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
          
            button1.MouseClick += Button1_MouseClick;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            checkbox.CheckedChanged += Checkbox_CheckedChanged;

            //Rekener ut ein posisjon for alle planetene
            foreach (SpaceObject oneplanet in planets)
            {
                oneplanet.CalculatePosition(time, OrbitalSpeed);
            }
         
        }

        private void Checkbox_CheckedChanged(object? sender, EventArgs e)
        {
            if(checkbox.Checked is true)
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;    
            } else
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
            }
        }
        //Gir brukeren mulighet å endre på Orbital Speed
        private void NumericUpDown1_ValueChanged(object? sender, EventArgs e)
        {
            OrbitalSpeed = (int)numericUpDown1.Value;
            Invalidate();   
         
            
        }
        //For å starte og stoppe animasjonen
        private void Button1_MouseClick(object? sender, MouseEventArgs e)
        {
            if(timer.Enabled is false)
            {
            timer.Start();
            button1.Text = "Stop Animation";
            } else
            {
                timer.Stop();
                button1.Text = "Start Animation";
            }
            

        }
        //Timer event som øker time for hvert intervall.
        private void Timer_Tick(object? sender, EventArgs e)
        {
            time++;
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        } 
        //Tegner opp alt
        protected override void OnPaint(PaintEventArgs e)
        {
            int middleX = (this.Width) / 2;
            int middleY = (this.Height) / 2;

            foreach (SpaceObject oneplanet in planets)
            {
                oneplanet.CalculatePosition(time, OrbitalSpeed);
            }

            scaleup = zoom;
            scaledown = zoom;
            Graphics g = e.Graphics;
            DoubleBuffered = true;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Tegner opp solen, med eller uten bilde 
            try
            {
                TextureBrush brush = new TextureBrush(Image.FromFile(@"C:\Users\sofje\OneDrive\Bilder\bilder\2k_sun.jpg"));
                g.FillEllipse(brush, middleX - (int)(sun.X / scaledown) - (int)(sun.ObjectRadius / scaledown) / 2,
                    (int)(middleY - (sun.Y / scaledown)) - (int)(sun.ObjectRadius / scaledown) / 2, (int)(sun.ObjectRadius / scaledown),
                    (int)(sun.ObjectRadius / scaledown));
            }
            catch (System.IO.FileNotFoundException ex)
            {
                g.FillEllipse(Brushes.Yellow, middleX - (int)(sun.X / scaledown) - (int)(sun.ObjectRadius / scaledown) / 2,
             (int)(middleY - (sun.Y / scaledown)) - (int)(sun.ObjectRadius / scaledown) / 2, (int)(sun.ObjectRadius / scaledown),
             (int)(sun.ObjectRadius / scaledown));
            };

            //Tegner alle planetene
            foreach (SpaceObject oneplanet in planets)
            {
                Brush b = new SolidBrush(Color.FromName(oneplanet.ObjectColour));


                g.FillEllipse(b, oneplanet.CalculateCordniateX(scaleup, middleX), oneplanet.CalculateCordniateY(scaleup, middleY),
                    oneplanet.CalculateWidth(scaleup), oneplanet.CalculateHeigth(scaleup));
            }
            //Sol label
            label2.Location = new Point(middleX - (int)(sun.X / scaledown) - (int)(sun.ObjectRadius / scaledown) / 2,
                (int)(middleY - (sun.Y / scaledown )) - (int)(sun.ObjectRadius / scaledown ) / 2);
            
            //Planet labels
            foreach (SpaceObject planet in planets)
            {
                Point p = new Point(planet.CalculateCordniateX(scaleup, middleX), planet.CalculateCordniateY(scaleup, middleY));
                switch (planet.Name)
                {
                    case "Mercury":
                        label3.Location = p;
                        break;
                    case "Venus":
                        label4.Location = p;
                        break;
                    case "Earth":
                        label5.Location = p;
                        break;
                    case "Mars":
                        label6.Location = p;
                        break;
                    case "Jupiter":
                        label7.Location = p;
                        break;
                    case "Saturn":
                        label8.Location = p;
                        break;
                    case "Uranus":
                        label9.Location = p;
                        break;
                    case "Neptune":
                        label10.Location = p;
                        break;
                    case "Pluto":
                        label11.Location = p;
                        break;
                    default:
                        break;
                }
            }
            //Planetary Orbits
                if(showorbitalradius)
                {
            foreach (SpaceObject planet in planets)
            {
                int orbitSize = (int)(planet.OrbitalRadius * zoom);
                int objectSize = (int)(planet.ObjectRadius * zoom);
                Rectangle rect = new Rectangle(middleX - orbitSize, middleY - orbitSize, orbitSize * 2, orbitSize * 2);
                g.DrawEllipse(Pens.Black, rect);
                }

        }
            }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            zoom = vScrollBar1.Value;
            Invalidate();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showorbitalradius = checkBox1.Checked;
            Invalidate();       
        }
    }
}