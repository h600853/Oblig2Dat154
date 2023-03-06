using SpaceSim;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        
        Star sun = new Star("Sun", 0, 0, 696340, 27, "yellow");
        Planet mercury = new Planet("Mercury", 2439.7, 87.97, 2.440, 59, "DarkGray");
        Planet venus = new Planet("Venus", 108000000, 224.7, 6.052, -243, "Yellow");
        Planet earth = new Planet("Earth", 6371.0, 365.2, 6.371, 24, "Blue");
        Planet mars = new Planet("Mars", 228000000, 687.0, 3.390, 25, "Red");
        Planet jupiter = new Planet("Jupiter", 71.492, 4331.0, 69.911, 10, "Orange");
        Planet saturn = new Planet("Saturn", 58232.0, 10747.0, 58.232, 11, "Yellow");
        Planet uranus = new Planet("Uranus", 25362.0, 30589.0, 25.362, -17, "LightBlue");
        Planet neptune = new Planet("Neptune", 24622.0, 59800.0, 24.622, 16, "DarkBlue");

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(Brushes.Yellow, 0, 0 ,(int) sun.ObjectRadius * 2, (int) sun.ObjectRadius * 2);
        }
    }
}