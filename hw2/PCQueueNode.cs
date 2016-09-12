// Tyler Cruz
// Homework 2 Thread safe non-locking queue implementation
// 9-6-2016 thru 9-8-2016

using System;

namespace CS422
{
	public abstract class PCQueueNode
	{
		public int Data;
		public PCQueueNode Next;
	}

	public class PCQueueNodeNull : PCQueueNode
	{
		//null node which we use as the "dummy node for this thread safe implementation"
		public PCQueueNodeNull() {
			
			Data = 0;
			Next = this;
		}
	}

	public class PCQueueNodeData: PCQueueNode
	{
		//public PCQueueNodeData(int data) {
		//	
		//	Data = data;
		//	Next = new PCQueueNodeNull ();
		//}

		//only one contructor which we pass in our version of null which is this dummy node for this implementation
		public PCQueueNodeData(int data, PCQueueNodeNull dummy)
		{
			Data = data;
			Next = dummy;
		}
	}

}

