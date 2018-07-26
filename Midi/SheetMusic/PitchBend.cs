using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$.SheetMusic
//{
    public struct PitchBend
    {
        /// <summary>
        /// Number of milliseconds after key was depressed to bend the pitch. 
        /// All TimePitchBends must be less that DurationMS
        /// </summary>
        public int TimePitchBend;
        /// <summary>
        /// -8192=Bend pitch as low as possible
        /// 0=Original Pitch
        /// 8191=Bend pitch as high as possible
        /// </summary>
        public int TrgtPitchBend;
    }
//}
