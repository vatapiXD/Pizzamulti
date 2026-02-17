using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pizza
{
	internal class SzinkronPuffer<T>
	{
		private Queue<T> sor;
		private int meret;
		private readonly object zar = new object();

		public SzinkronPuffer(int meret)
		{
			this.meret = meret;
			sor = new Queue<T>();
		}

		public void Hozzaad(T elem)
		{
			lock (zar)
			{
				while (sor.Count == meret)
				{
					Monitor.Wait(zar);
				}

				sor.Enqueue(elem);
				Monitor.PulseAll(zar);
			}
		}

		public T Kivesz()
		{
			lock (zar)
			{
				while (sor.Count == 0)
				{
					Monitor.Wait(zar);
				}

				T elem = sor.Dequeue();
				Monitor.PulseAll(zar);
				return elem;
			}
		}
	}
	

}
