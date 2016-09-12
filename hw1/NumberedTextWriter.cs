using System;
using System.IO;

namespace CS422 {

	public class NumberedTextWriter : TextWriter {

		private TextWriter m_writer;
		private int m_lineNumber;

		public NumberedTextWriter(TextWriter writer){

			m_writer = writer;
			m_lineNumber = 1;
		}

		public NumberedTextWriter(TextWriter writer, int startingLineNumber){
			
			m_writer = writer;
			m_lineNumber = startingLineNumber;
		}

		public override void Write(String s){
		
			m_writer.Write(s);
		}

		public override void WriteLine(String s){

			m_writer.Write(m_lineNumber + ": ");
			m_writer.WriteLine(s);
			m_lineNumber++;
		}

		 public override System.Text.Encoding Encoding{

        	get { return m_writer.Encoding; }
    	}
	}
}
