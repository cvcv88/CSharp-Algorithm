using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey> // 같은지 안같은지 확인
	{
		private const int DefaultCapacity = 1000; // 테이블 크기가 소수일 수록 분산 더 잘됨

		private struct Entry
		{
			public enum State { None, Using, Deleted } // 테이블 상태(사용x, 사용중, 지워진)

			public State state;
			public TKey key;
			public TValue value;
		}

		private Entry[] table;
		private int count;

		public Dictionary()
		{
			table = new Entry[DefaultCapacity];
			count = 0;
		}

		public TValue this[TKey key]
		{
			get
			{
				if (Find(key, out int index))
				{
					return table[index].value;
				}
				else
				{
					throw new KeyNotFoundException();
				}
			}
			set
			{
				if (Find(key, out int index))
				{
					table[index].value = value;
				}
				else
				{
					if (count > table.Length * 0.7f)
					{
						ReHashing();
					}

					table[index].key = key;
					table[index].value = value;
					table[index].state = Entry.State.Using;
					count++;
				}
			}
		}

		public void Add(TKey key, TValue value)
		{
			if (Find(key, out int index))
			{
				throw new InvalidOperationException("Already exist key");
			}
			else
			{
				if (count > table.Length * 0.7f)
				{
					ReHashing();
				}

				table[index].key = key;
				table[index].value = value;
				table[index].state = Entry.State.Using;
				count++;
			}
		}

		public void Clear()
		{
			table = new Entry[DefaultCapacity];
			count = 0;
		}

		public bool ContainsKey(TKey key)
		{
			if (Find(key, out int index))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool Remove(TKey key)
		{
			if (Find(key, out int index))
			{
				table[index].state = Entry.State.Deleted;
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool Find(TKey key, out int index)
		{
			if (key == null)
				throw new ArgumentNullException();

			index = Hash(key); // 해싱
			for (int i = 0; i < table.Length; i++)
			{
				if (table[index].state == Entry.State.None)
				{
					return false;
				}
				else if (table[index].state == Entry.State.Using)
				{
					if (key.Equals(table[index].key))
					{
						return true;
					}
					else
					{
						// 다음칸
						index = Hash2(index);
					}
				}
				else // if(table[index].state == Entry.State.Deleted)
				{
					// 다음칸
					index = Hash2(index);
				}
			}
				index = -1;
				throw new InvalidOperationException();
			
		}
		private int Hash(TKey key)
		{
			return Math.Abs(key.GetHashCode() % table.Length);
		}

		private int Hash2(int index)
		{
			// 선형 탐사
			return (index + 1) % table.Length;

			// 제곱 탐사
			// return (index + 1) * (index + 1) % table.Length;

			// 이중 해싱
			// return Math.Abs((index + 1).GetHashCode() % table.Length);
		}

		private void ReHashing()
		{
			Entry[] oldTable = table;
			table = new Entry[table.Length * 2];
			count = 0;

			for (int i = 0; i < oldTable.Length; i++)
			{
				Entry entry = oldTable[i];
				if (entry.state == Entry.State.Using)
				{
					Add(entry.key, entry.value);
				}
			}
		}
	}
}