using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
	public class KeyIndexedCounting
	{
        private const int SECTIONs = 5;
		private KeyIndexedCountingRecord[] _records;
        private int[] _count = new int[SECTIONs + 1];
        public KeyIndexedCounting()
        {
            _records = new KeyIndexedCountingRecord[]
            {
                new(2, "Anderson"),
                new(3, "Brown"),
                new(3, "Davis"),
                new(4, "Osama"),
                new(1, "Moghazy"),
                new(3, "Serry"),
                new(4, "Hazem"),
                new(3, "Neameh"),
                new(1, "Rasheed"),
                new(2, "Anas"),
                new(2, "Sami"),
            };
        }

        private void ComputerFrequency()
        {
            for (int i = 0; i < _records.Length; i++)
            {
                _count[_records[i].Key + 1]++;
            }
        }

        private void TransformCountToIndices()
        {
            for(int i = 0;i < SECTIONs; i++)
            {
                _count[i + 1] += _count[i];
            }
        }

        private void Distribute()
        {
            KeyIndexedCountingRecord[] aux = new KeyIndexedCountingRecord[_records.Length];
			for(int i = 0; i < _records.Length; i++)
            {
                aux[_count[_records[i].Key]++] = _records[i];
			}
			_records = aux;
		}

        public void Sort()
        {
			ComputerFrequency();
			TransformCountToIndices();
			Distribute();
		}

		public void Print()
        {
			foreach (var item in _records)
            {
				Console.WriteLine($"{item.Key} {item.Value}");
			}
		}
    }

	public record KeyIndexedCountingRecord(int Key, string Value);
}
