using System;
namespace ArtemisAPI
{
    public struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Coordinates(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Coordinates pos)
            {
                throw new System.Exception("dumbass");
            }

            return (this.X == pos.X) && (this.Y == pos.Y) && (this.Z == pos.Z);
        }

        public override int GetHashCode() => Tuple.Create(X, Y, Z).GetHashCode();
        
        public static bool operator ==(Coordinates a, Coordinates b) => a.Equals(b);
        public static bool operator !=(Coordinates a, Coordinates b) => !a.Equals(b);
    }
}