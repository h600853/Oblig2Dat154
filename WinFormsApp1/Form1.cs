using SpaceSim;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Star sun = new Star("Sun", 0, 0, 696340, 27, "yellow");
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
           
            g.FillEllipse(Brushes.Yellow,0,0,696340*2, 696340*2);
        }
    }
}