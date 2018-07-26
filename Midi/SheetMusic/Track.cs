using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$.SheetMusic
//{
    public class Track
    {
        public int InstrumentIndex;
        public List<Note> Notes;

        public Track(Instruments instrument) : this((int)instrument, new List<Note>()) { }
        public Track(Instruments instrument, List<Note> notes) : this((int)instrument, notes) { }
        public Track(int instrumentIdx, List<Note> notes)
        {
            InstrumentIndex = instrumentIdx;
            Notes = notes;
        }

        public int TrackLength
        {
            get
            {
                Note n=Notes.OrderByDescending(x=>x.TimeDown+x.DurationMS).FirstOrDefault();
                if (n == null) return 0;
                return n.TimeDown + n.DurationMS;
            }
        }
        public void AppendBar(Bar b)
        {
            int appendStartTime = 0;
            Note lastNote = Notes.OrderByDescending(x => x.TimeDown + x.DurationMS).FirstOrDefault<Note>();
            if (lastNote != null) appendStartTime = lastNote.TimeDown + lastNote.DurationMS;
            foreach (Note n in b.notes)
                Notes.Add(new Note(appendStartTime + n.TimeDown, n.MidiIndex, n.DurationMS, n.Volume));
            //return inc;
        }
    }

//}
