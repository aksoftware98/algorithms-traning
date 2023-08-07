using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
	public class SeparateChainingHashST<TKey, TValue> 
	{

		private int _m;
		private SequentialSearchSymbolTable<TKey, TValue>[] _symbolTable;

        public SeparateChainingHashST(int m)
        {
            _m = m;
            _symbolTable = new SequentialSearchSymbolTable<TKey, TValue>[m];
        }

        public int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % _m;
        }

        public TValue? Get(TKey key)
        {
			return _symbolTable[Hash(key)].Get(key);
		}

        public void Put(TKey key, TValue value)
        {
            _symbolTable[Hash(key)].Put(key, value);
        }

    }
}
