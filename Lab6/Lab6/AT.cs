using System;
namespace Lab6
{
    [AttributeUsage(AttributeTargets.Property,
    AllowMultiple = false,
    Inherited = false)
    ]
    public class AT : Attribute
    {
        public AT() { }
        public AT(string mDescription)
        {
            Description = mDescription;
        }
        public string Description { get; set; }
    }
}
