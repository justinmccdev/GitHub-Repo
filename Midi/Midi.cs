using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$
//{
    public class Midi
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        private static extern int mciSendStringA(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, IntPtr hwndCallback);

    //StreamReader sr = new StreamReader(stream);
    //var fileStream = File.Create("C:\\testmidi.txt");
    //stream.Seek(0, SeekOrigin.Begin);
    //stream.CopyTo(fileStream);
    //fileStream.Close();

    public static void SaveMidiFile(string midiFile)
    {
        //JM    this creates the midi file on your hard drive! Yay, finally got this working
        if (File.Exists(midiFile))
        {
            DateTime timestamp = DateTime.Now;
            string timeStampFormat = "yyyyMMddHHmmssfff";
            String dateTimeAppend = timestamp.ToString(timeStampFormat);
            dateTimeAppend.Replace(":", "");
            dateTimeAppend.Replace(";", "");
            dateTimeAppend.Replace("-", "");
            File.Copy(midiFile, "C:\\TestFolder\\testmidi" + dateTimeAppend + ".midi", true);
        }
    }
        public static bool PlayMidiFile(string midiFile)
        {
            String retStr = String.Empty;
            if (File.Exists(midiFile))
            {
                mciSendString("stop midi", retStr, 0, 0);
                //Console.WriteLine(retStr);
                mciSendString("close midi", retStr, 0, 0);
                //Console.WriteLine(retStr);
                mciSendString("open sequencer!" + midiFile + " alias midi", retStr, 0, 0);
                //Console.WriteLine(retStr);
                int rtn = mciSendString("play midi", retStr, 0, 0);
                //Console.WriteLine(retStr);
                return (rtn == 0);
            }
            else
                return false;
        }

        public static void StopMidiFile()
        {
            mciSendString("stop midi", "", 0, 0);
            mciSendString("close midi", "", 0, 0);
        }

        public static String Status()
        {
            StringBuilder sBuffer = new StringBuilder(128);
            mciSendStringA("status " + "midi" + " mode", sBuffer, sBuffer.Capacity, IntPtr.Zero);
            return sBuffer.ToString();
        }

    }

//}
