using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace $safeprojectname$.SheetMusic
//{

    /// <summary>
    /// Describes a note that is played
    /// </summary>
    public class Note
    {
        public const int STEPS_PER_OCTAVE = 12;
        internal Note(int timeDown, byte midiIdx, int durationMs, byte volume)
        {
            this.TimeDown = timeDown;
            this.MidiIndex = midiIdx;
            this.DurationMS = durationMs;
            this.Volume = volume;
        }

        /// <summary>
        /// The time when the note was pressed
        /// </summary>
        //public DateTime TimeDown { get; set; }
        public int TimeDown { get; set; }

        /// <summary>
        /// The midi index of the note
        /// </summary>
        public byte MidiIndex { get; set; }

        /// <summary>
        /// The duration the note has to be pressed
        /// </summary>
        public int DurationMS { get; set; }

        /// <summary>
        /// The volume at which to play the note at 
        /// </summary>
        public byte Volume { get; set; }


        public List<PitchBend> PitchBends { get; set; }

        public static byte GetNoteIndex(String note)
        {
            return (byte)(notesByMidiIndex.IndexOf(note));
        }
        public static String GetNoteByIndex(int indx)
        {
            if (indx < 0 || indx > notesByMidiIndex.Count) return String.Empty;
            return notesByMidiIndex[indx];
        }




        public static int NoteCount { get { return notesByMidiIndex.Count; } }
        public static List<string> notesByMidiIndex = new List<string>
        {
            "A-1", "A#-1", "B-1", "C-1", "C#-1", "D-1", "D#-1", "E-1", "F-1", "F#-1", "G-1", "G#-1",
            "A0", "A#0", "B0", "C0", "C#0", "D0", "D#0", "E0", "F0", "F#0", "G0", "G#0",
            "A1", "A#1", "B1", "C1", "C#1", "D1", "D#1", "E1", "F1", "F#1", "G1", "G#1",
            "A2", "A#2", "B2", "C2", "C#2", "D2", "D#2", "E2", "F2", "F#2", "G2", "G#2",
            "A3", "A#3", "B3", "C3", "C#3", "D3", "D#3", "E3", "F3", "F#3", "G3", "G#3",
            "A4", "A#4", "B4", "C4", "C#4", "D4", "D#4", "E4", "F4", "F#4", "G4", "G#4",
            "A5", "A#5", "B5", "C5", "C#5", "D5", "D#5", "E5", "F5", "F#5", "G5", "G#5",
            "A6", "A#6", "B6", "C6", "C#6", "D6", "D#6", "E6", "F6", "F#6", "G6", "G#6",
            "A7", "A#7", "B7", "C7", "C#7", "D7", "D#7", "E7", "F7", "F#7", "G7", "G#7",
            "A8", "A#8", "B8", "C8", "C#8", "D8", "D#8", "E8", "F8", "F#8", "G8", "G#8",
            "A9", "A#9", "B9", "C9", "C#9", "D9", "D#9", "E9", "F9", "F#9", "G9", "G#9",
        };
    }
//}
