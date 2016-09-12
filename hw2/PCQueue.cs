// Tyler Cruz
// Homework 2 Thread safe non-locking queue implementation
// 9-6-2016 thru 9-8-2016

using System;

namespace CS422
{
	public class PCQueue
	{
		PCQueueNode m_front;
		PCQueueNode m_back;
		PCQueueNode m_dummy;

		public PCQueue(){

			//we have our dummy node which will take the place of null
			m_dummy = new PCQueueNodeNull();
			m_front = m_dummy;
			m_back = m_dummy;

		}

		public bool Dequeue (ref int out_value){

			//in the case the the front is null (points to dummy), our queue is empty, return false
			if (Object.ReferenceEquals(m_front, m_dummy)) //or m_front is PCQueueNodeNull
			{
				return false;
			}

			//otherwise, get front value and advance the pointer
			//the back pointer may change at anytime from here
			out_value = m_front.Data;
			//to here
			m_front = m_front.Next;
			//to here

			//neither of these places concern us because we are only touching the front
			//front will not change in those places
				
			return true;
		}

		public bool Enqueue (int dataValue){
			
			PCQueueNode newNode = new PCQueueNodeData (dataValue, m_dummy as PCQueueNodeNull);

			//insert into empty list // if back is empty, front is empty
			if (Object.ReferenceEquals(m_back, m_dummy))
			{
				//dequeue can't be happening at this point because there is no
				//no case where front is not empty and back is empty
				
				m_back = newNode;
				m_front = newNode; //at this point dequeuing can resume
				return true;

			} 
			//case handles potential enqueue onto invalid node
			else if (Object.ReferenceEquals(m_front, m_dummy) && Object.ReferenceEquals(m_front, m_back.Next))
			{
				//at this point dequeue will only enter and immediately return false
				m_back.Next = newNode;
				m_back = m_back.Next;
				m_front = m_back; //after this line we can dequeue again

				return true;
			}
			else {

				//"normal" enqueue
				//here we just worry about the back
				//in the event that the front advances past of the back, we handle that with the case above
				m_back.Next = newNode;
				m_back = m_back.Next;
				return true;
			}
		}

		public void Print(){
			
			int frontData = -1;
			int backData = -1;
			PCQueueNode p = m_front;
			Console.WriteLine ("queue");

			//get first item in queue
			while (!(p is PCQueueNodeNull)) {

				frontData = p.Data;
				p = p.Next;
				break;
			}

			p = m_front;

			//get last item in queue
			while (!(p is PCQueueNodeNull))
			{
				backData = p.Data;
				p = p.Next;
			}

			//print last and first item of queue
			Console.WriteLine(backData);
			Console.WriteLine(frontData);
		}
	}
}

