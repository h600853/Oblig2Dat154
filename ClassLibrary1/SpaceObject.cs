using System;
using System.Drawing;
using static System.Formats.Asn1.AsnWriter;

namespace SpaceSim
{
    public class SpaceObject
    {
        private String name;
        private double orbitalRadius;
        private double orbitalPeriod;
        private double objectRadius;
        private double rotationalPeriod;
        private String objectColour;
        private double x;
        private double y;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public double OrbitalRadius
        {
            get { return orbitalRadius; }
            set { orbitalRadius = value; }
        }
        public double OrbitalPeriod
        {
            get { return orbitalPeriod; }
            set { orbitalPeriod = value; }
        }
        public double ObjectRadius
        {
            get { return objectRadius; }
            set { objectRadius = value; }
        }
        public double RotationalPeriod
        {
            get { return rotationalPeriod; }
                set { rotationalPeriod = value; }
        }
        public String ObjectColour
        {
            get { return objectColour; }
                set { objectColour = value; }
        }
        public double X
        {
            get { return x; }
            set { x = value; }  
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }



        public SpaceObject(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour )
        {
           this.name = name;
            this.orbitalRadius = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod; 
            this.objectRadius = objectRadius;   
            this.rotationalPeriod = rotationalPeriod;   
            this.objectColour = objectColour;
            this.x = 0;
            this.y = 0;
            
        }
        public virtual void Draw()
        {
            Console.WriteLine($"Name: {name}, OrbitalRadius: {orbitalRadius}, OrbitalPeriod: {orbitalPeriod}, " +
                  $"ObjectRadius: {objectRadius}, RotationalPeriod: {rotationalPeriod}, ObjectColour: {objectColour}, Position(X = {x}, Y = {y}).");
        }
        public virtual void CalculatePosition(int numberofdays)
        {
            double angle = (numberofdays / orbitalPeriod) * (2 * Math.PI);
            double angleInRadiants = angle * (Math.PI / 100);
             x = orbitalRadius * Math.Cos(angleInRadiants);
             y = orbitalRadius * Math.Sin(angleInRadiants);
        
           
        }
        public virtual int CalculateCordniateX(int scale, int middleX)
        {
            return (middleX + (int)this.X * scale) - ((int)this.ObjectRadius * scale) /2;
        }
        public virtual int CalculateCordniateY(int scale, int middleY)
        {
            return (middleY + (int)this.Y * scale ) - ((int)this.ObjectRadius * scale  )/2 ;
        }
        public virtual int CalculateWidth(int scale)
        {
            return (int)this.ObjectRadius*scale;
        }
        public virtual int CalculateHeigth(int scale)
        {
            return (int)this.ObjectRadius*scale;
        }

    }
    public class Star : SpaceObject
    {
        public Star(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColour)
        {

        }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }

    }
    public class Planet : SpaceObject
    {
        public Planet(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColour) { }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }
    public class Moon : Planet
    {
        public Moon(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColour) { }
        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }
    public class Comet : SpaceObject
    {
        public Comet(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColour)
        {

        }
        public override void Draw()
        {
            Console.Write("Comet : ");
            base.Draw();
        }
    }
    public class Asteroid : SpaceObject
    {
        public Asteroid(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColour)
        {

        }
        public override void Draw()
        {
            Console.Write("Asteroid : ");
            base.Draw();
        }
    }
    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColour)
        {

        }
        public override void Draw()
        {
            Console.Write("AsteroidBelt : ");
            base.Draw();
        }
    }
    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(String name, double orbitalRadius, double orbitalPeriod, double objectRadius, double rotationalPeriod, String objectColour) : base(name, orbitalRadius, orbitalPeriod, objectRadius, rotationalPeriod, objectColour)
        {

        }
        public override void Draw()
        {
            Console.Write("DwarfPlanet : ");
            base.Draw();
        }
    }


}
