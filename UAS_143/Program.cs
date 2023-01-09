using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_143
{
    class Node
    {
        public int rollNumber;
        public string name;
        public int Jumlah;
        public int tanggal;
        public Node next;
    }
    class CircularList
    { 
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public void addNode()
        {
            int rollNo, Jmlh, Date;
            string nama;
            Console.Write("\nMasukan nomor buku: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nJudul buku: ");
            nama = Console.ReadLine();
            Console.Write("\nJumlah buku: ");
            Jmlh = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukan tahun terbit (DD/MM/YYYY): ");
            Date = Convert.ToInt32(Console.ReadLine());
            Node newNode = new Node();
            newNode.rollNumber = rollNo;
            newNode.name = nama;
            newNode.Jumlah = Jmlh;
            newNode.tanggal = Date;

            
            if (LAST == null)
            {
                LAST = newNode;
                newNode.next = LAST;
                return;
            }
            Node previous, current;
            previous = LAST;
            current = LAST;
           
            if (Date < LAST.next.tanggal)
            {
                newNode.next = LAST.next;
                LAST.next = newNode;
                return;
            }
            
            if (Date <= LAST.tanggal)
            {
                if (LAST != null && Date == LAST.tanggal)
                {
                    Console.WriteLine("\nBAHAYA DUPLIKAT!!!!\n");
                    return;
                }
                current = LAST.next;
                previous = current;
                while (Date > current.tanggal || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = newNode;
                newNode.next = current;
                return;
            }
            if (Date > LAST.tanggal)
            {
                newNode.next = LAST.next;
                LAST.next = LAST = newNode;
                return;
            }
            newNode.next = current;
            previous.next = newNode;
        }
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
            {
                return false;
            }

            if (rollNo == LAST.next.rollNumber) 
            {
                current = LAST.next;
                LAST.next = current.next;
                return true;
            }

            if (rollNo == LAST.rollNumber) 
            {
                current = LAST;
                previous = current.next;
                while (previous.next != LAST)
                {
                    previous = previous.next;
                }
                previous.next = LAST.next;
                LAST = previous;
                return true;
            }

            if (rollNo <= LAST.rollNumber) 
            {
                current = previous = LAST.next;
                while (rollNo > current.rollNumber || previous == LAST)
                {
                    previous = current;
                    current = current.next;
                }
                previous.next = current.next;
            }
            return true;

        }
        public bool Search(int tgl, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (tgl == current.tanggal)
                    return (true);
            }
            if (tgl == LAST.tanggal)
                return true;
            else
                return (false);
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are:\n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.WriteLine("\n     Data ditemukan ");
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("\nTahun terbit: " + currentNode.tanggal);
                    Console.WriteLine("\nNomor buku: " + currentNode.rollNumber);
                    Console.WriteLine("\nJudul buku: " + currentNode.name);
                    Console.WriteLine("\nJumlah: " + currentNode.Jumlah);
                    Console.WriteLine("----------------------------------");
                    currentNode = currentNode.next;
                }
                Console.WriteLine("\nTahun terbit: " + LAST.tanggal);
                Console.WriteLine("\nNomor buku: " + LAST.rollNumber);
                Console.WriteLine("\nJudul buku: " + LAST.name);
                Console.WriteLine("\nJumlah: " + LAST.Jumlah);
                Console.WriteLine("----------------------------------");
            }
        }

        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Masukan Data");
                    Console.WriteLine("2. Hapus Data");
                    Console.WriteLine("3. Menampilkan semua data");
                    Console.WriteLine("4. Mencari data");
                    Console.WriteLine("5. Keluar");
                    Console.WriteLine("\nEnter your choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the Item number of" + " the Item whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                    Console.WriteLine("Record with Item number" + rollNo + " deleted ");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukan tanggal untuk dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\n     Data of Item found ");
                                    Console.WriteLine("----------------------------------");
                                    Console.WriteLine("\nTahunterbit: " + curr.tanggal);
                                    Console.WriteLine("\nNomorbuku: " + curr.rollNumber);
                                    Console.WriteLine("\nJudulbuku: " + curr.name);
                                    Console.WriteLine("\nJumlah: " + curr.Jumlah);
                                    Console.WriteLine("----------------------------------");
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}


//2.CircularList.
//3.Pop,push.
//4.Push,pop.
//5. a.)Ada 6
//   b.)Postorder yaitu dari anak kanan kekiri abis itu ke parent atau orangtua atas.