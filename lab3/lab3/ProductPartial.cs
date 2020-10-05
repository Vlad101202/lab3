using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    partial class Product
    {
        const int wtf1 = 228;
        static readonly int wtf2;
        private Product(int upc)
        {
            UPC = upc;
            Name = "-";
            Manufacter = "-";
            Price = 0;
            Storage_time = 0;
            Number = 0;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (Name).GetHashCode();
        }

        public override string ToString()
        {
            return $" {Name} ";
        }
    }
}
