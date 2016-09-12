using System;
using CS422;

public class typrogram {

	public static void Main(){
		Console.WriteLine("hello, hw1");
		CS422.NumberedTextWriter writer = new CS422.NumberedTextWriter(Console.Out);

		Console.WriteLine("--- NumberedTextWriter Test 1 Constructor ---");
		writer.WriteLine("one");
		writer.WriteLine("two");
		writer.WriteLine("three");
		writer.WriteLine("four");
		writer.WriteLine("five");
		writer.WriteLine("siz");
		writer.WriteLine("seven");
		writer.WriteLine("eight");

		writer = new CS422.NumberedTextWriter(Console.Out, 5);

		Console.WriteLine("--- NumberedTextWriter Test 2 Constructor ---");
		writer.WriteLine("five");
		writer.WriteLine("six");
		writer.WriteLine("seven");
		writer.WriteLine("eight");
		writer.WriteLine("nine");
		writer.WriteLine("ten");
		writer.WriteLine("eleven");
		writer.WriteLine("twelve");

		CS422.IndexedNumsStream stream = new CS422.IndexedNumsStream(256);
		byte[] barry = new byte[5];

		Console.WriteLine("--- IndexedNumsStream Tests ---");
		
		Console.WriteLine("byte array: ");

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		Console.WriteLine("--- read 5 from beginning of stream ---");

		stream.Read(barry, 0, 5);

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		Console.WriteLine("--- read another 5 ---");

		stream.Read(barry, 0, 5);

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		Console.WriteLine("--- read another 4 ---");

		stream.Read(barry, 0, 4);

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		Console.WriteLine("--- read another 2 into last 2 ---");

		stream.Read(barry, barry.Length - 2, 2);

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		Console.WriteLine("--- pos = 253, but read 5 (first 3 should change only)---");
		stream.Position = 253;

		stream.Read(barry, 0, 5);

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		Console.WriteLine("--- try read 5 from end, no change ---");

		stream.Read(barry, 0, 5);

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		Console.WriteLine("--- change stream Length, read 5 ---");
		stream.SetLength(512);
		stream.Read(barry, 0, 5);

		for(int i = 0; i < barry.Length; i++){
			Console.WriteLine(barry[i]);
		}

		

	}
}
