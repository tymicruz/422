using System;
using System.IO;

namespace CS422 {

	public class IndexedNumsStream : Stream {

		private long m_length;
		private long m_position;

		public IndexedNumsStream (long length) {

			SetLength(length);
			m_position = 0;
		}

		public override int Read (byte[] buffer, int offset, int count) {

			int i = 0;

			//i < count : read desired number of bytes
			//m_pos < m_length : can't read beyond stream length
			//i + offset : can't store bytes beyond buffer boundary

			for(i = 0; i < count && m_position < m_length && i + offset < buffer.Length; i++, m_position++) {

				buffer[i + offset] = (byte)((m_position) % 256);
			}

			return i;
		}

		public override bool CanRead { 

			get { return true; }
		}

		public override bool CanSeek { 

			get { return true; }
		}

		public override bool CanWrite { 

			get { return false; }
		}

		public override long Length {

			get { return m_length; }
		}

		public override long Position {

			get { return m_position; }

			set {

				if(value < 0) {

					m_position =  0;

				}else if(value > m_length) {

					m_position = m_length;

				}else {

					m_position = value;
				}
			}
		}

		public override void Flush() { 

			m_position = 0;
			m_length = 0;
		}

		public override long Seek(long offset, SeekOrigin origin){
			
			m_position += offset;

			if (m_position > m_length){

				m_position = m_length;
			}

			return m_position;
		}

		public override void SetLength(long length){

			if(length < 0){ 

				m_length = 0;

			} else { 

				m_length = length;
			}
		}

		public override void Write(byte[] buffer, int offset, int count){

		}
	}
}
