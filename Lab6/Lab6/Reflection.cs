using System;
namespace Lab6
{
    public class Reflection
    {
        public Reflection() { }
        public Reflection(int i) { }
        public Reflection(string str) { }

        public int Plus(int x, int y) { return x + y; }
        public int Minus(int x, int y) { return x - y; }

        [AT("паблик стринг проперти4 гет и сет")]
        public string property1 { get { return _property1; } set { _property1 = value; } }
        private string _property1;


        [AT("паблик инт проперти2 гет и сет")]
        public int property2 { get; set; }


        public double property3 { get; set; }

        [AT("паблик флоат проперти4 гет и сет")]
        public float property4 { get; set; }

        public short property5 { get; set; }

        public int field1; public float field2;
    }

}

