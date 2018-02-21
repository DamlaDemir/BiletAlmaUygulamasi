using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soru1Sinema
{
    public  class LinkedList:LinkedListADT
    {
        public override void InsertFirst(Musteri value)
        {
            Node tmpHead = new Node();
            tmpHead.Data = value;
            tmpHead.Data.Ad = value.Ad;
            tmpHead.Data.Soyad = value.Soyad;
            tmpHead.Data.KoltukNo = value.KoltukNo;
     
            if (Head == null)
                Head = tmpHead;
            else
            {
                tmpHead.Next = Head;
                Head = tmpHead;
            }         
        }

        public override void InsertPos( Musteri value)
        {
            int i = 1;
            Node lastPrevNode = null;
            Node posNode = Head;
            Node newNode = new Node();
            newNode.Data = value;
            newNode.Data.Ad = value.Ad;
            newNode.Data.Soyad = value.Soyad;
            newNode.Data.KoltukNo = value.KoltukNo;
            //yeni gelen müşteri newNode düğümüne atandı.
    
            while (true)
            {     
                    if(value.KoltukNo==1)
                    {
                        //Müşterinin koltuk numarası 1 ise Head yeni gelen müşteri oldu.
                        newNode.Next = Head.Next;
                        Head = newNode;
                        Size++;
                        break;    
                    }


                    if (i==value.KoltukNo && i!=1)
                    {
                        //Koltuk numarasına göre gelen müşteri listeye eklendi.
                        lastPrevNode.Next = newNode;
                        newNode.Next = posNode.Next;
                        Size++;
                        break;
                    }

                    lastPrevNode = posNode;
                    posNode = posNode.Next;
                    i++;  
                
            }
        }



        public override void DeletePos(Musteri value)
        {
            Musteri m = new Musteri
            {
                Ad = null,
                Soyad = null,
                KoltukNo = -1
            };

            int i = 1;
            Node oldLast = Head;
            Node lastPrevNode = new Node();
            Node newNode = new Node();
            newNode.Data = m;
            newNode.Data.Ad =m.Ad;
            newNode.Data.Soyad = m.Soyad;
            newNode.Data.KoltukNo = m.KoltukNo;
         

            while (true)
            {
               
                    if (value.KoltukNo == 1)
                    {
                        Head = Head.Next;
                        Size--;
                        break;
                    }

                    if (i == value.KoltukNo && i!=1)
                    {
                        //Koltuk numarasına göre gelen müşteri listeden silindi.
                        lastPrevNode.Next = newNode;
                        newNode.Next = oldLast.Next;
                        Size--;
                        break;
                    }

                    lastPrevNode = oldLast;
                    oldLast = oldLast.Next;
                    i++;
               
            }

        }

     

        
        public override Node GetElement(Musteri m)
        {
            Node retNode = null;
            Node tempNode = Head;

            while (tempNode != null)
            {
                if (tempNode.Data.Ad==m.Ad && tempNode.Data.Soyad==m.Soyad)
                {
                    retNode = tempNode;
                    retNode.Data.Ad = tempNode.Data.Ad;
                    retNode.Data.Soyad = tempNode.Data.Soyad;
                    retNode.Data.KoltukNo = tempNode.Data.KoltukNo;
                    break;
                    //Müşteri ad ve soyada göre listede arama yapıldı ve koltuk numarası bulundu
                }
                tempNode = tempNode.Next;
            }
            return retNode;
        }

    }
}
