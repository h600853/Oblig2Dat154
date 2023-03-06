using SpaceSim;
using System.Security.Cryptography.Xml;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {


        Star sun = new Star("Sun", 0, 0, 696.340, 26, "yellow");

        List<SpaceObject> planets = new List<SpaceObject>() {
    new Planet("Mercury", 57.91, 87.97, 2.440, 59, "DarkGray"),
        new Planet("Venus", 108.2, 224.7, 6.052, -243, "Yellow"),
         new Planet("Earth", 149.6, 365.2, 6.371, 24, "Blue"),
        new Planet("Mars", 228, 687, 3.390, 25, "Red"),
       new Planet("Jupiter", 778.5, 4.331, 69.911, 10, "Orange"),
        new Planet("Saturn", 1400000, 10747.0, 58.232, 11, "Yellow"),
         new Planet("Uranus", 2870000, 30.589, 25.362, -17, "LightBlue"),
        new Planet("Neptune", 4500000, 59800.0, 24.622, 16, "DarkBlue")




    };

        private int zoom = 1;

        public Form1()
        {
            InitializeComponent();
            vScrollBar1.Value = zoom;
           
             
           
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            int time = 1;
            int middleX = (this.Width) / 2;
            int middleY = (this.Height) / 2;

            foreach (SpaceObject oneplanet in planets)
            {
                oneplanet.CalculatePosition(time);
            }
            int scaleup = zoom;
            int scaledown = zoom;
            Graphics g = e.Graphics;
            
            g.FillEllipse(Brushes.Yellow, middleX - (int)(sun.X /scaledown) - (int)(sun.ObjectRadius / scaledown)/2,
                (int)(middleY - (sun.Y / scaledown)) - (int)(sun.ObjectRadius / scaledown) / 2, (int)(sun.ObjectRadius/scaledown), 
                (int)(sun.ObjectRadius/scaledown));
            
            foreach (SpaceObject oneplanet in planets)
            {
                Brush b = new SolidBrush(Color.FromName(oneplanet.ObjectColour));
               

                g.FillEllipse(b, oneplanet.CalculateCordniateX(scaleup, middleX), oneplanet.CalculateCordniateY(scaleup, middleY),
                    oneplanet.CalculateWidth(scaleup), oneplanet.CalculateHeigth(scaleup));
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
    }
}