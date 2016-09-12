using System;
using System.Threading;
using System.Collections.Concurrent;

namespace CS422
{
	class MainClass
	{
		static PCQueue queue = new PCQueue ();

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			ThreadPoolSleepSorter tpss = new ThreadPoolSleepSorter(Console.Out, 64);

			tpss.Sort(new byte[]{ 3, 2, 4, 1, 5 , 4, 1, 6});
			//tpss.Sort(new byte[] { 3, 2, 4, 1, 5 });
			//tpss.Dispose();
			//Thread ens = new Thread(() => e(40000));
			//Thread des = new Thread(() => d(100000));
			//queue.Print ();
			//ens.Start();
			//des.Start();

			//Thread.Sleep(10000);
			//queue.Print ();

			//BlockingCollection<int> cs = new BlockingCollection<int>();
		//	cs.Add(6);
			//cs.Take();
			tpss.Dispose();
		//	Console.WriteLine("Hello World!");
		}

		public static void d(int n){
			int data = 0;

			for (int i = 0; i < n; i++) {
				bool tf = queue.Dequeue (ref data);

				//if (tf == false) {
				//	Console.WriteLine ("empty");
				//	Console.ReadLine ();
				//} else {
				//	Console.WriteLine ("pop");
				//}
				//Console.WriteLine (data);
			}
		}

		public static void e(int n){

			for (int i = 0; i < n; i++) {
				queue.Enqueue (i);
			}
		}
	}
}
