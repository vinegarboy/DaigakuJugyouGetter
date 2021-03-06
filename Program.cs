
using System;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.IO;
namespace Opencv
{
	class ImgCompare{
		public bool Compare(Bitmap bp1,Bitmap bp2){
			bool result = false;
			for(int x = 0;x<bp1.Width;x++){
				for(int y = 0;y<bp1.Height;y++){
					if(bp1.GetPixel(x,y)!=bp2.GetPixel(x,y)){
						result = true;
						break;
					}
				}
			}
			return result;
		}
	}
    class Program
    {
        static void Main(string[] args)
        {
			ImgCompare ic = new ImgCompare();
			string path,savepath;
			VideoCapture vc;
			Mat mt = new Mat(),_mt = new Mat();
			DirectoryInfo di;
			Console.WriteLine("動画のパスを入力してください。");
			path=Console.ReadLine();
			Console.WriteLine($"このパスでよろしいですか？大丈夫な場合は1を入力してください。\n{path}");
			while(Console.ReadLine()!="1"){
				Console.WriteLine("動画のパスを入力してください。");
				path=Console.ReadLine();
				Console.WriteLine($"このパスでよろしいですか？大丈夫な場合は1を入力してください。\n{path}");
			}
			di = new DirectoryInfo("./saves");
			di.Create();
			di = null;
			savepath=$"./saves/{Path.GetFileNameWithoutExtension(path)}";
			di = new DirectoryInfo(savepath);
			di.Create();
			vc = new VideoCapture(path);
			Console.WriteLine($"AllFrames:{vc.FrameCount}\npath{savepath}");
			for(int i = 0;i<vc.FrameCount;i++){
				vc.PosFrames = i;
				if(i!=0){
					vc.Read(_mt);
					if(ic.Compare(BitmapConverter.ToBitmap(mt),BitmapConverter.ToBitmap(_mt))){
						vc.Read(mt);
						BitmapConverter.ToBitmap(mt).Save($"{savepath}/{i}.jpg");
						Console.WriteLine($"SaveFrame:{i+1}Frame.");
					}else{
						Console.WriteLine($"NotSaves:{i+1}Frame.");
					}
				}else{
					vc.Read(mt);
					BitmapConverter.ToBitmap(mt).Save($"{savepath}/{i}.jpg");
					Console.WriteLine($"SaveFrame:{i+1}Frame.");
				}
				Console.WriteLine($"CompleteTask:{vc.FrameCount-i}...{100*(1-((float)(vc.FrameCount-i)/vc.FrameCount))}%\n");
			}
        }
    }
}
