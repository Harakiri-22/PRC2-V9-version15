using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace LibMas
{
    public class Array
    {
        private readonly Random _random = new Random();
        private int[] _array;
        public int Length => _array.Length;

        public Array(int length)
        {
            _array = new int[length];
        }

        public void Fill(int min = -20, int max = 20)
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _random.Next(min, max);
            }
        }

        public void Import(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                _array = new int[int.Parse(reader.ReadLine())];

                for (int i = 0; i < Length; i++)
                {
                    _array[i] = int.Parse(reader.ReadLine());
                }
            }
        }
        public void Export(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(Length);

                for (int i = 0; i < Length; i++)
                {
                    writer.WriteLine(_array[i]);
                }
            }
        }

        public DataTable ToTableData()
        {
            var result = new DataTable();
            for (int i = 0; i < _array.Length; i++)
            {
                result.Columns.Add("Col" + (i + 1));
            }
            var row = result.NewRow();
            for (int i = 0; i < Length; i++)
            {
                row[i] = _array[i];
            }
            result.Rows.Add(row);
            return result;
        }

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public void Clear()
        {
            Fill(0, 0);
        }
    }
}
