using System;
using System.IO;
namespace LAB7
{
    class Program
    {
        static void Main(string[] args)
        {
            string readPath = @"C:\4TO-TO\ReadMe.txt";
            string writePath =@"C:\4TO-TO\ReadMe2.txt";
            char[] text = new char [300];
            char[] text1 = new char[100];
            char[] text2 = new char[100];
            char[] text3 = new char[100];

            string[] wp = new string[60];
            int r = 0;
            string gg = "";
            try
            {
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default))
                {
                    gg = sr.ReadToEnd();

                    int index = 0;
                    int len = gg.Length;
                    //while (len > 0)
                    //{
                    
                        //if (r < index + 5)
                        //{
                           // if (len <= 0)
                          //      break;
                            sr.Read(text, index, 5);
                         //   r += 5;
                       //     len -= 5;
                     //   }
                    Console.WriteLine(text);
                       // index += 5;
                        //r += 5;
                        //    if (r <  index+15)
                        //    {
                        //        if (len <= 0)
                        //            break;
                        //        sr.Read(text, index, 10);
                        //        r+=10;
                        //        len-=10;
                        //    }
                        //    index += 10;
                        //    r -= 15;
                        //    if(r<index - 10)
                        //    {
                        //        if (len <= 0)
                        //            break;
                        //        sr.Read(text, index, 5);
                        //        len-=5;
                        //        r+=5;
                        //    }
                        //    index +=5;
                        //    r += 10;
                        //    if (r < index+10)
                        //    {if (len <= 0)
                        //            break;
                        //        sr.Read(text, index, 10);
                        //        len-=10;
                        //        r+=10;
                        //    }
                        //    index += 10;
                        //}
                    }
                    using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                    {
                      
                        Console.WriteLine(text);
                        sw.Write(text);
                        Console.ReadKey();
                    }
                //}
            }
            //  }          
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
