using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListArray
{
    public class CustomList
    {
        static long Capacity = 0;

        public long[] Data = new long[2];

        long _count;

        public long Count
        {
            get { return _count; }
            set { _count = value; }
        }
        public void INSERT(long index, long item)
        {
            if ((index - 1) < Count)
            {
                long[] tempInsert = new long[Count + 1];

                for (int i = 0, j = 0; i < Count + 1; i++)
                {
                    if ((index - 1) != i)
                    {
                        tempInsert[i] = Data[j];
                    }
                    else
                    {
                        i++;
                        tempInsert[i] = Data[j];
                    }
                    j++;
                }
                tempInsert[index - 1] = item;
                Count++;
                Data = tempInsert;
            }
        }
        public void DELETE(long index)
        {
            if ((index - 1) < Count)
            {
                long[] tempDelete = new long[Count - 1];

                for (long i = 0, j = 0; i < Count; i++)
                {
                    if ((index - 1) != i)
                    {
                        tempDelete[j] = Data[i];
                    }
                    else
                        j--;
                    j++;
                }
                Count--;
                Data = tempDelete;
            }
        }

        public long GET(long index)
        {
            if (index < Count)
                return Data[index - 1];
            else
                return long.MinValue;
        }
        public void SET(long index, long value)
        {
            if ((index - 1) < Count)
            {
                Data[index - 1] = value;
            }
            else if ((index - 1) == Count)
            {
                ADD(value);
            }
        }

        public bool CONTAINS(long item)
        {
            bool found = false;
            for (long i = 0; i < Count; i++)
                if (Data[i] == item)
                {
                    found = !found;
                    break;
                }
            return found;
        }
        public void ADD(long item)
        {
            Data[Count] = item;
            Count++;
            RESIZE();
        }

        public void RESIZE()
        {
            if (Count > (Capacity - 2))
            {
                RESIZE(Capacity * 2);
            }
        }
        public void RESIZE(long newSize)
        {
            long[] tempResize = new long[newSize];

            for (long i = 0; i < Count; i++)
            {
                tempResize[i] = Data[i];
            }
            Data = tempResize;
            CAPCITY();
        }
        public void PRINT()
        {
            if (Count == 0)
                Console.WriteLine("No Elements");
            else
            {
                Console.Write("[ ");
                for (long i = 0; i < Count; i++)
                {
                    if ((i + 1) == Count)
                    {
                        Console.Write(Data[i]);
                    }
                    else
                    {
                        Console.Write(Data[i] + ", ");
                    }
                }
                Console.Write(" ]\n");
            }
        }

        public long CAPCITY()
        {
            long l = 0;
            while (true)
            {
                try
                {
                    int temp = (int)Data[l];
                    l++;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Capacity = l;
                    return l;
                }
                catch (NullReferenceException ex)
                {
                    Capacity = 0;
                    return 0;
                }
            }
        }
        public bool ISEMPTY()
        {
            return Count == 0 ? true : false;
        }

        public void DISTINCT()
        {
            long[] tempToDISTINCT = Data;
            long TempCount = Count;
            Data = new long[2];
            Count = 0;
            for (long i = 0; i < TempCount; i++)
            {
                if (!CONTAINS(tempToDISTINCT[i]))
                {
                    ADD(tempToDISTINCT[i]);
                }
            }
        }

        public void SORT()
        {
            for (long i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count - 1; j++)
                {
                    if (Data[j] > Data[j + 1])
                    {
                        long temp = Data[j];
                        Data[j] = Data[j + 1];
                        Data[j + 1] = temp;
                    }
                }
            }
        }

        public CustomList(int defaultValue)
        {
            for (int i = 0; i < Capacity; i++)
            {
                Data[i] = defaultValue;
            }
        }
        public CustomList()
        {

        }
    }
}
