using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$.SheetMusic
//{
    public class Bar
    {

        public enum BarType
        {
            Beat=1,
            Chord=2,
            Melody=3,
            PercussInstrument1=4,
            PercussInst2=5,
            PercussInst3=6,
            Chord2=7,
            BassLine=8
    }

        public List<Note> notes { get; set; }
        public Bar() { notes = new List<Note>(); }

        public static Bar GenerateBar(MovementInfo movement, BarType type)
        {
            switch(type)
            {
                case BarType.Beat:
                    return GenerateBeatBar(movement);
                case BarType.Chord:
                    return GenerateChordBar(movement);
                case BarType.Chord2:
                    return GenerateChordBar2(movement);
                case BarType.BassLine:
                    return GenerateBassLine(movement);
                case BarType.Melody:
                    return GenerateMelodyBar(movement);
                case BarType.PercussInstrument1:
                    return GeneratePercussInstrument1(movement);
                case BarType.PercussInst2:
                    return GeneratePercussInst2(movement);
                case BarType.PercussInst3:
                    return GeneratePercussInst3(movement);
        }
            throw new ArgumentOutOfRangeException("type", "Unknown bar type");
        }
    public static Bar GenerateBeatBar(MovementInfo movement)
    {
        return new Bar();
    }
    public static Bar GeneratePercussInstrument1(MovementInfo movement)
    {
        Bar newBar = new Bar();
        int totalBarBeatDuration = movement.Tempo.getTimeSignature("4/4");
        int currentTotalDuration = 0;
        int SongDuration = 0;
        int AccurateSongDuration = 0;
        int Root = movement.Root;
        int n = 0;  //keeps track of rhythm in bar and whether it is rest or not for that rhythm

        List<String> RhythmForBar = new List<String>();
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");


        //Decides whether note is a rest or not, SHOULD MATCH UP WITH EACH ADDITION TO RhythmForBar
        List<int> DecideRest = new List<int>();
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);

        for (int i = 0; i < 4; i++)
        {

            //Declares note to be played
            Root = (byte)(60);
            n = 0;

            //The "-4" is because of the rounding error that occurs with midi. This should make sure that an "almost" full bar 
            //counts as a full bar. 
            //Adjust this number if the exception error occurs for a rhythm you know should fill the bar.
            while (totalBarBeatDuration - 4 > currentTotalDuration)
            {
                foreach (String y in RhythmForBar)
                {
                    if (DecideRest[n] == 1)
                    {
                        //Parameters of the added note: Current place in duration of the bar, a byte decided by notes based in the offset of the chords, the beat duration of the current note to be played, and a byte describing the volume
                        newBar.notes.Add(new Note(AccurateSongDuration, (byte)(Root), movement.Tempo.getNoteDuration(RhythmForBar[n]), (byte)movement.Volume));
                    }
                    currentTotalDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    AccurateSongDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    n += 1;
                }

            }
            currentTotalDuration = 0;
            SongDuration += movement.Tempo.getTimeSignature("4/4");
            AccurateSongDuration = SongDuration;
        }
        return newBar;
        
    }

    public static Bar GeneratePercussInst2(MovementInfo movement)
    {
        Bar newBar = new Bar();
        int totalBarBeatDuration = movement.Tempo.getTimeSignature("4/4");
        int currentTotalDuration = 0;
        int SongDuration = 0;
        int AccurateSongDuration = 0;
        int Root = movement.Root;
        int n = 0;  //keeps track of rhythm in bar and whether it is rest or not for that rhythm

        List<String> RhythmForBar = new List<String>();
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");


        //Decides whether note is a rest or not, SHOULD MATCH UP WITH EACH ADDITION TO RhythmForBar
        List<int> DecideRest = new List<int>();
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(0);

        for (int i = 0; i < 4; i++)
        {

            //Declares note to be played
            Root = (byte)(65);
            n = 0;

            //The "-4" is because of the rounding error that occurs with midi. This should make sure that an "almost" full bar 
            //counts as a full bar. 
            //Adjust this number if the exception error occurs for a rhythm you know should fill the bar.
            while (totalBarBeatDuration - 4 > currentTotalDuration)
            {
                foreach (String y in RhythmForBar)
                {
                    if (DecideRest[n] == 1)
                    {
                        //Parameters of the added note: Current place in duration of the bar, a byte decided by notes based in the offset of the chords, the beat duration of the current note to be played, and a byte describing the volume
                        newBar.notes.Add(new Note(AccurateSongDuration, (byte)(Root), movement.Tempo.getNoteDuration(RhythmForBar[n]), (byte)movement.Volume));
                    }
                    currentTotalDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    AccurateSongDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    n += 1;
                }

            }
            currentTotalDuration = 0;
            SongDuration += movement.Tempo.getTimeSignature("4/4");
            AccurateSongDuration = SongDuration;
        }
        return newBar;

    }

    public static Bar GeneratePercussInst3(MovementInfo movement)
    {
        Bar newBar = new Bar();
        int totalBarBeatDuration = movement.Tempo.getTimeSignature("4/4");
        int currentTotalDuration = 0;
        int SongDuration = 0;
        int AccurateSongDuration = 0;
        int Root = movement.Root;
        int n = 0;  //keeps track of rhythm in bar and whether it is rest or not for that rhythm

        List<String> RhythmForBar = new List<String>();
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");


        //Decides whether note is a rest or not, SHOULD MATCH UP WITH EACH ADDITION TO RhythmForBar
        List<int> DecideRest = new List<int>();
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(0);

        for (int i = 0; i < 4; i++)
        {

            //Declares note to be played
            Root = (byte)(65);
            n = 0;

            //The "-4" is because of the rounding error that occurs with midi. This should make sure that an "almost" full bar 
            //counts as a full bar. 
            //Adjust this number if the exception error occurs for a rhythm you know should fill the bar.
            while (totalBarBeatDuration - 4 > currentTotalDuration)
            {
                foreach (String y in RhythmForBar)
                {
                    if (DecideRest[n] == 1)
                    {
                        //Parameters of the added note: Current place in duration of the bar, a byte decided by notes based in the offset of the chords, the beat duration of the current note to be played, and a byte describing the volume
                        newBar.notes.Add(new Note(AccurateSongDuration, (byte)(Root), movement.Tempo.getNoteDuration(RhythmForBar[n]), (byte)movement.Volume));
                    }
                    currentTotalDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    AccurateSongDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    n += 1;
                }

            }
            currentTotalDuration = 0;
            SongDuration += movement.Tempo.getTimeSignature("4/4");
            AccurateSongDuration = SongDuration;
        }
        return newBar;

    }
    public static Bar GenerateChordBar(MovementInfo movement)
    {
        Bar newBar = new Bar();

        //qnLen is supposed to mean "Quarter Note Length"
        int qnLen = movement.Tempo.BeatDuration;

        //JM- This is the total beat duration  for the bardepending on the Time Signature and Tempo
        int totalBarBeatDuration = movement.Tempo.getTimeSignature("4/4");

        //JM- use this to keep track of where the duration is in the bar
        int currentTotalDuration = 0;

        //This is the Root note decided when you call the movement in SongGenerator
        int Root = movement.Root;
        //using this to keep track of place in song
        int SongDuration = 0;

        //So because midi is just a rough estimate of time, the amount of time per bar slowly degrades when being rounded
        //I created this to get away from the rounding error per bar adding up through the whole song so that other 
        //musical parts would match timewise outside of the chordal harmonies. It just basically sets the time
        //in the song to the next bar by the actual time the bar should take in total
        int AccurateSongDuration = 0;

        // using this to keep track of chord type 
        int m = 0;
        int n = 1;

        //Chord types (major minor etc...) to be added to list for phrase
        List<int> chordTypesForPhrase = new List<int>();

        //List of Chord Types for Phrase
        chordTypesForPhrase.Add(0); //Major
        chordTypesForPhrase.Add(0);//Major
        chordTypesForPhrase.Add(1); //Minor
        chordTypesForPhrase.Add(0); //Major

        //List of Distances from Root
        List<int> intervalForChord = new List<int>();

        //List of Chord distances from Root
        intervalForChord.Add(0); //I
        //intervalForChord.Add(5); //V
        intervalForChord.Add(-7); //V
        intervalForChord.Add(-3); //vi
        intervalForChord.Add(-5); //IV

        List<String> RhythmForBar = new List<String>();
        /*
        RhythmForBar.Add("quarter");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("quarter");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        */
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        //Decides whether note is a rest or not, SHOULD MATCH UP WITH EACH ADDITION TO RhythmForBar
        List<int> DecideRest = new List<int>();
        /*
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        */
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        //When using GetRandomElement to declare the octave, this will randomize the root note up or down an octave
        /*
        if (Rng.Percent(30))
        {
            if (Rng.Percent(50))
                Root += Note.STEPS_PER_OCTAVE;
            else
                Root -= Note.STEPS_PER_OCTAVE;
        }
        */

        foreach (int x in intervalForChord)
        {

            //This declares the Chord type, Major, minor, etc...
            movement.Chord = Chord.chords[chordTypesForPhrase[m]];            
            //This declares how far the chords lie from the Root note. Here, I set it to 60 and added the distances from a list interForChord
            Root = (byte) (60 + intervalForChord[m]);
            //movement.Root = Note.GetNoteIndex(String.Format("{0}{1}", 'G' + intervalForChord[m], '4'));
            m += 1;
            n = 0;

            //The "-4" is because of the rounding error that occurs with midi. This should make sure that an "almost" full bar 
            //counts as a full bar. 
            //Adjust this number if the exception error occurs for a rhythm you know should fill the bar.
            while (totalBarBeatDuration-4 > currentTotalDuration)
            {
                foreach (String y in RhythmForBar) { 
                        if(DecideRest[n] == 1) { 
                            //Uses for loop to add each note in the chord
                            for (int i = 0; i < movement.Chord.offsets.Count(); i++) { 
                                //Parameters of the added note: Current place in duration of the bar, a byte decided by notes based in the offset of the chords, the beat duration of the current note to be played, and a byte describing the volume
                                newBar.notes.Add(new Note(AccurateSongDuration, (byte)(Root + movement.Chord.offsets[i]), movement.Tempo.getNoteDuration(RhythmForBar[n]), (byte)movement.Volume));
                             }
                        }   
                    currentTotalDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    AccurateSongDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    n += 1;
                }
                
            }
            currentTotalDuration = 0;
            SongDuration += movement.Tempo.getTimeSignature("4/4");
            AccurateSongDuration = SongDuration;

        }
        return newBar;
    }

    public static Bar GenerateChordBar2(MovementInfo movement)
    {
        Bar newBar = new Bar();

        //qnLen is supposed to mean "Quarter Note Length"
        int qnLen = movement.Tempo.BeatDuration;

        //JM- This is the total beat duration  for the bardepending on the Time Signature and Tempo
        int totalBarBeatDuration = movement.Tempo.getTimeSignature("4/4");

        //JM- use this to keep track of where the duration is in the bar
        int currentTotalDuration = 0;

        //This is the Root note decided when you call the movement in SongGenerator
        int Root = movement.Root;
        //using this to keep track of place in song
        int SongDuration = 0;

        //So because midi is just a rough estimate of time, the amount of time per bar slowly degrades when being rounded
        //I created this to get away from the rounding error per bar adding up through the whole song so that other 
        //musical parts would match timewise outside of the chordal harmonies. It just basically sets the time
        //in the song to the next bar by the actual time the bar should take in total
        int AccurateSongDuration = 0;

        // using this to keep track of chord type 
        int m = 0;
        int n = 1;

        //Chord types (major minor etc...) to be added to list for phrase
        List<int> chordTypesForPhrase = new List<int>();

        //List of Chord Types for Phrase
        chordTypesForPhrase.Add(0); //Major
        chordTypesForPhrase.Add(0);//Major
        chordTypesForPhrase.Add(1); //Minor
        chordTypesForPhrase.Add(0); //Major

        //List of Distances from Root
        List<int> intervalForChord = new List<int>();

        //List of Chord distances from Root
        intervalForChord.Add(0); //I
        //intervalForChord.Add(5); //V
        intervalForChord.Add(-7); //V
        intervalForChord.Add(-3); //vi
        intervalForChord.Add(-5); //IV

        List<String> RhythmForBar = new List<String>();
        /*
        RhythmForBar.Add("quarter");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("eigth");
        RhythmForBar.Add("quarter");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        */
        RhythmForBar.Add("whole");

        //Decides whether note is a rest or not, SHOULD MATCH UP WITH EACH ADDITION TO RhythmForBar
        List<int> DecideRest = new List<int>();
        /*
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(0);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);
        */
        DecideRest.Add(1);

        //When using GetRandomElement to declare the octave, this will randomize the root note up or down an octave
        /*
        if (Rng.Percent(30))
        {
            if (Rng.Percent(50))
                Root += Note.STEPS_PER_OCTAVE;
            else
                Root -= Note.STEPS_PER_OCTAVE;
        }
        */

        foreach (int x in intervalForChord)
        {

            //This declares the Chord type, Major, minor, etc...
            movement.Chord = Chord.chords[chordTypesForPhrase[m]];
            //This declares how far the chords lie from the Root note. Here, I set it to 60 and added the distances from a list interForChord
            Root = (byte)(60 + intervalForChord[m]);
            //movement.Root = Note.GetNoteIndex(String.Format("{0}{1}", 'G' + intervalForChord[m], '4'));
            m += 1;
            n = 0;

            //The "-4" is because of the rounding error that occurs with midi. This should make sure that an "almost" full bar 
            //counts as a full bar. 
            //Adjust this number if the exception error occurs for a rhythm you know should fill the bar.
            while (totalBarBeatDuration - 4 > currentTotalDuration)
            {
                foreach (String y in RhythmForBar)
                {
                    if (DecideRest[n] == 1)
                    {
                        //Uses for loop to add each note in the chord
                        for (int i = 0; i < movement.Chord.offsets.Count(); i++)
                        {
                            //Parameters of the added note: Current place in duration of the bar, a byte decided by notes based in the offset of the chords, the beat duration of the current note to be played, and a byte describing the volume
                            newBar.notes.Add(new Note(AccurateSongDuration, (byte)(Root + movement.Chord.offsets[i]), movement.Tempo.getNoteDuration(RhythmForBar[n]), (byte)movement.Volume));
                        }
                    }
                    currentTotalDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    AccurateSongDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    n += 1;
                }

            }
            currentTotalDuration = 0;
            SongDuration += movement.Tempo.getTimeSignature("4/4");
            AccurateSongDuration = SongDuration;

        }
        return newBar;
    }

    public static Bar GenerateMelodyBar(MovementInfo movement)
    {
        Bar newBar = new Bar();
        int totalBarBeatDuration = movement.Tempo.getTimeSignature("4/4");
        int currentTotalDuration = 0;
        int SongDuration = 0;
        int AccurateSongDuration = 0;
        int Root = movement.Root;
        int n = 0;  //keeps track of rhythm in bar and whether it is rest or not for that rhythm

        List<String> RhythmForBar = new List<String>();
        RhythmForBar.Add("whole");


        //Decides whether note is a rest or not, SHOULD MATCH UP WITH EACH ADDITION TO RhythmForBar
        List<int> DecideRest = new List<int>();
        DecideRest.Add(1);


        //Decides interval from root note to be played
        List<int> NoteInterval = new List<int>();
        NoteInterval.Add(0);


        for (int i = 0; i < 4; i++)
        {

            //Declares note to be played
            Root = (byte)(65);
            n = 0;

            //The "-4" is because of the rounding error that occurs with midi. This should make sure that an "almost" full bar 
            //counts as a full bar. 
            //Adjust this number if the exception error occurs for a rhythm you know should fill the bar.
            while (totalBarBeatDuration - 4 > currentTotalDuration)
            {
                foreach (String y in RhythmForBar)
                {
                    Root = (byte)(65);
                    Root += NoteInterval[n];
                    if (DecideRest[n] == 1)
                    {
                        //Parameters of the added note: Current place in duration of the bar, a byte decided by notes based in the offset of the chords, the beat duration of the current note to be played, and a byte describing the volume
                        newBar.notes.Add(new Note(AccurateSongDuration, (byte)(Root), movement.Tempo.getNoteDuration(RhythmForBar[n]), (byte)movement.Volume));
                    }
                    currentTotalDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    AccurateSongDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    n += 1;
                }

            }
            currentTotalDuration = 0;
            SongDuration += movement.Tempo.getTimeSignature("4/4");
            AccurateSongDuration = SongDuration;
        }
        return newBar;
    }

    public static Bar GenerateBassLine(MovementInfo movement)
    {
        Bar newBar = new Bar();
        int totalBarBeatDuration = movement.Tempo.getTimeSignature("4/4");
        int currentTotalDuration = 0;
        int SongDuration = 0;
        int AccurateSongDuration = 0;
        int Root = movement.Root;
        int n = 0;  //keeps track of rhythm in bar and whether it is rest or not for that rhythm

        List<String> RhythmForBar = new List<String>();
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");

        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");

        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");

        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");
        RhythmForBar.Add("triplet");


        //Decides whether note is a rest or not, SHOULD MATCH UP WITH EACH ADDITION TO RhythmForBar
        List<int> DecideRest = new List<int>();
        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);

        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);

        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);

        DecideRest.Add(1);
        DecideRest.Add(1);
        DecideRest.Add(1);


        //Decides interval from root note to be played
        List<int> NoteInterval = new List<int>();
        NoteInterval.Add(12);
        NoteInterval.Add(16);
        NoteInterval.Add(19);

        NoteInterval.Add(12);
        NoteInterval.Add(16);
        NoteInterval.Add(19);

        NoteInterval.Add(12);
        NoteInterval.Add(16);
        NoteInterval.Add(19);

        NoteInterval.Add(12);
        NoteInterval.Add(16);
        NoteInterval.Add(19);

        for (int i = 0; i < 4; i++)
        {

            //Declares note to be played
            Root = (byte)(65);
            n = 0;

            //The "-4" is because of the rounding error that occurs with midi. This should make sure that an "almost" full bar 
            //counts as a full bar. 
            //Adjust this number if the exception error occurs for a rhythm you know should fill the bar.
            while (totalBarBeatDuration - 4 > currentTotalDuration)
            {
                foreach (String y in RhythmForBar)
                {
                    Root = (byte)(65);
                    Root += NoteInterval[n];
                    if (DecideRest[n] == 1)
                    {
                        //Parameters of the added note: Current place in duration of the bar, a byte decided by notes based in the offset of the chords, the beat duration of the current note to be played, and a byte describing the volume
                        newBar.notes.Add(new Note(AccurateSongDuration, (byte)(Root), movement.Tempo.getNoteDuration(RhythmForBar[n]), (byte)movement.Volume));
                    }
                    currentTotalDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    AccurateSongDuration += movement.Tempo.getNoteDuration(RhythmForBar[n]);
                    n += 1;
                }

            }
            currentTotalDuration = 0;
            SongDuration += movement.Tempo.getTimeSignature("4/4");
            AccurateSongDuration = SongDuration;
        }
        return newBar;
    }
}
/*
int currBeat = 0;

//I think we should set this up to be less than the total amount of beat duration in a phrase. So if we have
//a 2 bar phrase, in 4/4 time, set to a tempo where the beat duration of a quarter note is 100, there would be a total of 800
//since there are 8 quarter notes total.
while (currBeat < (movement.TimeSignature.denominator))
{
    int beatCount = Rng.rng.Next(movement.TimeSignature.denominator - currBeat + 1);
    //beatCount = 1;
    switch (beatCount)
    {
        case 0:
            //Add two notes in one beat
            for (int i = 0; i < movement.Chord.offsets.Count(); i++)
                newBar.notes.Add(new Note(currBeat * qnLen, (byte)(Root + movement.Chord.offsets[i]), qnLen / 2, (byte)movement.Volume));
            for (int i = 0; i < movement.Chord.offsets.Count(); i++)
                newBar.notes.Add(new Note((currBeat * qnLen) + (qnLen / 2), (byte)(Root + movement.Chord.offsets[i]), qnLen / 2, (byte)movement.Volume));
            currBeat += 1;
            break;
        default:
            for (int i = 0; i < movement.Chord.offsets.Count(); i++)
                newBar.notes.Add(new Note(currBeat * qnLen, (byte)(Root + movement.Chord.offsets[i]), qnLen * beatCount, (byte)movement.Volume));
            currBeat += beatCount;
            break;
    }
}
return newBar;
}
*/


/*
public static Bar GenerateMelodyBar(MovementInfo movement)
    {
        Bar newBar = new Bar();

        int qnLen = movement.Tempo.BeatDuration;

        //int currTime = 0;
        int currBeat = 0;
        while (currBeat < (movement.TimeSignature.denominator))
        {
            int beatCount = Rng.rng.Next(movement.TimeSignature.denominator - currBeat + 1);
            int oIndx = Rng.rng.Next(movement.Chord.offsets.Count);
            switch (beatCount)
            {
                case 0:
                    newBar.notes.Add(new Note(currBeat * qnLen, (byte)(movement.Root + movement.Chord.offsets[oIndx]), qnLen / 2, (byte)movement.Volume));
                    if (Rng.Percent(25))
                        oIndx = Rng.rng.Next(movement.Chord.offsets.Count);
                    newBar.notes.Add(new Note((currBeat * qnLen) + (qnLen / 2), (byte)(movement.Root + movement.Chord.offsets[oIndx]), qnLen / 2, (byte)movement.Volume));
                    currBeat += 1;
                    break;
                default:
                    newBar.notes.Add(new Note(currBeat * qnLen, (byte)(movement.Root + movement.Chord.offsets[oIndx]), qnLen * beatCount, (byte)movement.Volume));
                    currBeat += beatCount;
                    break;
            }
        }
        return newBar;
    }

}*/
//}
