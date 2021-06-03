using System;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO;
namespace Opencv
{
    class Program
    {
        static void Main(string[] args)
        {
			string path,savepath;
			VideoCapture vc;
			Mat mp = new Mat();
			DirectoryInfo di;
			Console.WriteLine("動画のパスを入力してください。");
			path=Console.ReadLine();
			Console.WriteLine($"このパスでよろしいですか？大丈夫な場合は1を入力してください。\n{path}");
			while(Console.ReadLine()!="1"){
				Console.WriteLine("動画のパスを入力してください。");
				path=Console.ReadLine();
				Console.WriteLine($"このパスでよろしいですか？大丈夫な場合は1を入力してください。\n{path}");
			}
			savepath=$"./saves/{Path.GetFileNameWithoutExtension(path)}";
			di = new DirectoryInfo(savepath);
			vc = new VideoCapture(path);
			for(int i = 0;i<vc.FrameCount;i++){
				if(i!=0){

				}else{
					vc.Read(mp);
					BitmapConverter.ToBitmap(mp).Save($"{savepath}/{i}.jpg");
				}
			}
        }
    }
}
