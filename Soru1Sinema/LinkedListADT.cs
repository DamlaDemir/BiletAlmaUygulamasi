using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru1Sinema
{
    public abstract class LinkedListADT
    {
        public Node Head;
        public int Size = 0;
        public abstract void InsertFirst(Musteri value);
        public abstract void InsertPos(Musteri value);
        public abstract void DeletePos(Musteri value);
        public abstract Node GetElement(Musteri m);

    }
}
