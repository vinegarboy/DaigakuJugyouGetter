using System;
using OpenCvSharp;
using OpenCvSharp.Extensions;
namespace Opencv
{
    class Program
    {
        static void Main(string[] args)
        {
			string path;
			VideoCapture vc;
			Console.WriteLine("動画のパスを入力してください。");
			path=Console.ReadLine();
			Console.WriteLine($"このパスでよろしいですか？大丈夫な場合は1を入力してください。\n{path}");
			while(Console.ReadLine()!="1"){
				Console.WriteLine("動画のパスを入力してください。");
				path=Console.ReadLine();
				Console.WriteLine($"このパスでよろしいですか？大丈夫な場合は1を入力してください。\n{path}");
			}
			vc = new VideoCapture(path);
			for(int i = 0;i<vc.FrameCount;i++){

			}
        }
    }
}
