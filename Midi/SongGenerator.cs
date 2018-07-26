using System;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace humanmusic
{
    public class SongGenerator
    {

        static List<Char> keys = new List<Char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
        static List<Char> Octives = new List<Char>() { '3', '4', '5', '6' };

        StringBuilder sb = new StringBuilder("");

        public StringBuilder getSongInfo()
        {
            return sb;
        }

        public SongGenerator()
        {

        }

        public void stop()
        {
            Midi.StopMidiFile();
        }

        public static void PlayScale()
        {
            List<String> NotesInScale = new List<string>() { "C4", "D4", "E4", "F4", "G4", "A5", "B5", "C5" };

            //Time measured in milliseconds since start of song
            int currTime = 0;

            //Create a place to store the notes
            List<Note> notes = new List<Note>();


            //Play the scale ascending
            foreach (String s in NotesInScale)
            {
                //TimeDown: When to press the key, measured in milliseconds since beginning of song
                //midiIndex: Index of key to press. Mapped
                //durationMS: numer of miliseconds to hold the key down for
                //volume   :Forcefulness to play the key. 0=Silent -> 127=Max volume
                Note n = new Note(currTime, Note.GetNoteIndex(s), 100, 64);
                notes.Add(n);
                currTime += 100;
            }


            //Play the scale descending
            NotesInScale.Reverse();
            foreach (String s in NotesInScale)
            {
                notes.Add(new Note(currTime, Note.GetNoteIndex(s), 100, 64));
                currTime += 100;
            }

            //Play a chord
            foreach (int offSet in Chord.chords[0].offsets)
            {
                int indx = (Note.GetNoteIndex("C4") + offSet);
                notes.Add(new Note(currTime, (byte)indx, 200, 64));
            }
            //Console.WriteLine();
            currTime += 200;

            //Play another chord
            foreach (int offSet in Chord.chords[4].offsets)
            {
                int indx = (Note.GetNoteIndex("C4") + offSet);
                notes.Add(new Note(currTime, (byte)indx, 200, 64));
            }
            //Console.WriteLine();
            currTime += 200;

            //Play the first chord again
            foreach (int offSet in Chord.chords[0].offsets)
            {
                int indx = (Note.GetNoteIndex("C4") + offSet);
                notes.Add(new Note(currTime, (byte)indx, 400, 64));
            }
            //Console.WriteLine();
            currTime += 400;

            //Create a track
            List<Track> tracks = new List<Track>() { new Track(Instruments.Rock_Organ, notes) };

            //Write the midifile with the selected tracks
            String fName = @"test1.midi";
            MidiWriter.Write(fName, tracks);


            //Start playing the midifile [The Midi Object is not thread safe. Ensure that all Midi functions are called from the same thread. only becomes an issue with multi-threading or GUIs]            
              Midi.PlayMidiFile(fName);

            //Wait for it to complete
            while (Midi.Status() != "stopped")
                System.Threading.Thread.Sleep(10);

            //Stop playing the midi file.
            Midi.StopMidiFile();


        }

        public void GenerateSong()
        {
            
            MovementInfo info = new MovementInfo()
            {
                //Chord = Chord.chords.GetRandomElement(),
                Chord = Chord.chords[0],
                //Root = Note.GetNoteIndex(String.Format("{0}{1}", keys.GetRandomElement(), Octives.GetRandomElement())),
                Root = Note.GetNoteIndex(String.Format("{0}{1}", 'G', '4')),
                //Tempo = Tempo.Tempos.GetRandomElement(),
                Tempo = Tempo.Tempos[127],
                //TimeSignature = TimeSignature.TimeSignatures.GetRandomElement(),
                TimeSignature = TimeSignature.TimeSignatures[3],
                Volume = 120
            };


            Track t = new Track(Instruments.Electric_Piano_2, new List<Note>());
            Track t2 = new Track(Instruments.Fiddle, new List<Note>());
            Track m = new Track(Instruments.Steel_Drums, new List<Note>());
            Track m2 = new Track(Instruments.Banjo, new List<Note>());
            Track x = new Track(Instruments.Church_Organ, new List<Note>());
            
            Bar chordBar = Bar.GenerateBar(info, Bar.BarType.Chord);
            Bar chordBar2 = Bar.GenerateBar(info, Bar.BarType.Chord2);
            Bar PercussInstrument1Bar = Bar.GenerateBar(info, Bar.BarType.PercussInstrument1);
            Bar PercussInstrument2Bar = Bar.GenerateBar(info, Bar.BarType.PercussInst2);
            Bar GenerateBassBar = Bar.GenerateBar(info, Bar.BarType.BassLine);
            //
            //info.Volume = 0;
            t.AppendBar(chordBar);
            //info.Volume = 30;
            t2.AppendBar(chordBar2);
            //info.Volume = 45;
            m.AppendBar(PercussInstrument1Bar);
            m2.AppendBar(PercussInstrument2Bar);
            //info.Volume = 120;
            x.AppendBar(GenerateBassBar);
            // m2.AppendBar(Bar.GenerateBar(info, Bar.BarType.Melody));


            /* Left for later reference, WIP
            //switching chord to D
            info.Root = Note.GetNoteIndex(String.Format("{0}{1}", 'D', '4'));
            chordBar = Bar.GenerateBar(info, Bar.BarType.Chord);
            for (int i = 0; i < 1; i++)
            {
                t.AppendBar(chordBar);                         
            }

            //Switching chord to Em
            info.Root = Note.GetNoteIndex(String.Format("{0}{1}", 'E', '4'));
            //Minor Chord
            info.Chord = Chord.chords[1];
            chordBar = Bar.GenerateBar(info, Bar.BarType.Chord);
            for (int i = 0; i < 1; i++)
            {
                t.AppendBar(chordBar);
            }

            //Switching chord to C
            info.Root = Note.GetNoteIndex(String.Format("{0}{1}", 'C', '4'));
            //Major Chord
            info.Chord = Chord.chords[0];
            chordBar = Bar.GenerateBar(info, Bar.BarType.Chord);
            for (int i = 0; i < 1; i++)
            {
                t.AppendBar(chordBar);
            }
            */

            List<Track> tracks = new List<Track>() { t, t2, m, m2, x};
            foreach (Track tt in tracks)
            {
                //Console.WriteLine("Track len {0}", tt.TrackLength);
                //Form1.programInfo.Text("test");
                sb.AppendLine("Track length" + tt.TrackLength);
            }

            String fName = @"test1.midi";            


            MidiWriter.Write(fName, tracks);
            try
            {
                Midi.SaveMidiFile(fName);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Please create a folder on your C:/ drive called 'TestFolder' which the program will write the MIDI files to.");
                System.Windows.Forms.Application.Exit();
            }
            Midi.PlayMidiFile(fName);
        }
    }
}
