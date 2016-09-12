// Tyler Cruz
// Homework 2 sleep sort implementation
// 9-6-2016 thru 9-8-2016

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace CS422
{
	public class ThreadPoolSleepSorter : IDisposable
	{
		TextWriter m_writer;
		BlockingCollection<int> coll;
		Thread[] threads;
		int endSleep = 0;

		public ThreadPoolSleepSorter(TextWriter output, ushort threadCount = 64){
			
			m_writer = output;
			coll = new BlockingCollection<int>();

			threads = new Thread[threadCount];

			for (int i = 0; i < threadCount; i++) {
				
				threads[i] = new Thread(() => WorkWorkWorkWorkWork(coll));
				threads[i].Start();
			}
		}

		public void Sort(byte[] values)
		{
			for (int i = 0; i < values.Length; i++)
			{
				coll.Add(values[i]);

				if (values[i] > endSleep)
				{
					endSleep = values[i];
				}
			}

		}
					
		private void WorkWorkWorkWorkWork(BlockingCollection<int> c) {

			while (true)
			{
				int num = c.Take();

				Thread.Sleep(num * 1000);
				m_writer.WriteLine(num);
			}
		}

		public void Dispose()
		{
			for (int i = 0; i < threads.Length; i++)
			{
				threads[i].Abort();
			}
		}
	}
}

