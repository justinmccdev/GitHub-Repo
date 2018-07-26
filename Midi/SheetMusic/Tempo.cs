using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$.SheetMusic
//{
    public class Tempo
    {
        public String Name;
        public int BeatDuration;
    public static List<Tempo> Tempos = new List<Tempo>()
        {
            /* OLD CODE FOR TEMPOS!!
            //new Tempo() { Name="Grave", BeatDuration=366 },
            //new Tempo() { Name="Largo", BeatDuration=338 },
            //new Tempo() { Name="Larghetto", BeatDuration=310 },
            new Tempo() { Name="Adagio", BeatDuration=282 },
            new Tempo() { Name="Andante", BeatDuration=254 },
            new Tempo() { Name="Andantino", BeatDuration=226 },
            new Tempo() { Name="Allegretto", BeatDuration=198 },
            new Tempo() { Name="Allegro", BeatDuration=170 },
            new Tempo() { Name="Vivace", BeatDuration=142 },
            new Tempo() { Name="Presto", BeatDuration=114 },
            new Tempo() { Name="Allegretto", BeatDuration=198 },
            new Tempo() { Name="Allegro", BeatDuration=170 },
            new Tempo() { Name="Vivace", BeatDuration=142 },
            new Tempo() { Name="Presto", BeatDuration=114 },
            new Tempo() { Name="Prestissimo", BeatDuration=86 },
            new Tempo() { Name="Moderato", BeatDuration=58 },
            //new Tempo() { Name="Molto", BeatDuration=30 },
            */
            //The lower the beat duration the faster. 50 is stupidly fast up to 177 which is very slow
            new Tempo() { Name="0", BeatDuration=50 },
            new Tempo() { Name="1", BeatDuration=51 },
            new Tempo() { Name="2", BeatDuration=52 },
            new Tempo() { Name="3", BeatDuration=53 },
            new Tempo() { Name="4", BeatDuration=54 },
            new Tempo() { Name="5", BeatDuration=55 },
            new Tempo() { Name="6", BeatDuration=56 },
            new Tempo() { Name="7", BeatDuration=57 },
            new Tempo() { Name="8", BeatDuration=58 },
            new Tempo() { Name="9", BeatDuration=59 },
            new Tempo() { Name="10", BeatDuration=60 },
            new Tempo() { Name="11", BeatDuration=61 },
            new Tempo() { Name="12", BeatDuration=62 },
            new Tempo() { Name="13", BeatDuration=63 },
            new Tempo() { Name="14", BeatDuration=64 },
            new Tempo() { Name="15", BeatDuration=65 },
            new Tempo() { Name="16", BeatDuration=66 },
            new Tempo() { Name="17", BeatDuration=67 },
            new Tempo() { Name="18", BeatDuration=68 },
            new Tempo() { Name="19", BeatDuration=69 },
            new Tempo() { Name="20", BeatDuration=70 },
            new Tempo() { Name="21", BeatDuration=71 },
            new Tempo() { Name="22", BeatDuration=72 },
            new Tempo() { Name="23", BeatDuration=73 },
            new Tempo() { Name="24", BeatDuration=74 },
            new Tempo() { Name="25", BeatDuration=75 },
            new Tempo() { Name="26", BeatDuration=76 },
            new Tempo() { Name="27", BeatDuration=77 },
            new Tempo() { Name="28", BeatDuration=78 },
            new Tempo() { Name="29", BeatDuration=79 },
            new Tempo() { Name="30", BeatDuration=80 },
            new Tempo() { Name="31", BeatDuration=81 },
            new Tempo() { Name="32", BeatDuration=82 },
            new Tempo() { Name="33", BeatDuration=83 },
            new Tempo() { Name="34", BeatDuration=84 },
            new Tempo() { Name="35", BeatDuration=85 },
            new Tempo() { Name="36", BeatDuration=86 },
            new Tempo() { Name="37", BeatDuration=87 },
            new Tempo() { Name="38", BeatDuration=88 },
            new Tempo() { Name="39", BeatDuration=89 },
            new Tempo() { Name="40", BeatDuration=90 },
            new Tempo() { Name="41", BeatDuration=91 },
            new Tempo() { Name="42", BeatDuration=92 },
            new Tempo() { Name="43", BeatDuration=93 },
            new Tempo() { Name="44", BeatDuration=94 },
            new Tempo() { Name="45", BeatDuration=95 },
            new Tempo() { Name="46", BeatDuration=96 },
            new Tempo() { Name="47", BeatDuration=97 },
            new Tempo() { Name="48", BeatDuration=98 },
            new Tempo() { Name="49", BeatDuration=99 },
            new Tempo() { Name="50", BeatDuration=100 },
            new Tempo() { Name="51", BeatDuration=101 },
            new Tempo() { Name="52", BeatDuration=102 },
            new Tempo() { Name="53", BeatDuration=103 },
            new Tempo() { Name="54", BeatDuration=104 },
            new Tempo() { Name="55", BeatDuration=105 },
            new Tempo() { Name="56", BeatDuration=106 },
            new Tempo() { Name="57", BeatDuration=107 },
            new Tempo() { Name="58", BeatDuration=108 },
            new Tempo() { Name="59", BeatDuration=109 },
            new Tempo() { Name="60", BeatDuration=110 },
            new Tempo() { Name="61", BeatDuration=111 },
            new Tempo() { Name="62", BeatDuration=112 },
            new Tempo() { Name="63", BeatDuration=113 },
            new Tempo() { Name="64", BeatDuration=114 },
            new Tempo() { Name="65", BeatDuration=115 },
            new Tempo() { Name="66", BeatDuration=116 },
            new Tempo() { Name="67", BeatDuration=117 },
            new Tempo() { Name="68", BeatDuration=118 },
            new Tempo() { Name="69", BeatDuration=119 },
            new Tempo() { Name="70", BeatDuration=120 },
            new Tempo() { Name="71", BeatDuration=121 },
            new Tempo() { Name="72", BeatDuration=122 },
            new Tempo() { Name="73", BeatDuration=123 },
            new Tempo() { Name="74", BeatDuration=124 },
            new Tempo() { Name="75", BeatDuration=125 },
            new Tempo() { Name="76", BeatDuration=126 },
            new Tempo() { Name="77", BeatDuration=127 },
            new Tempo() { Name="78", BeatDuration=128 },
            new Tempo() { Name="79", BeatDuration=129 },
            new Tempo() { Name="80", BeatDuration=130 },
            new Tempo() { Name="81", BeatDuration=131 },
            new Tempo() { Name="82", BeatDuration=132 },
            new Tempo() { Name="83", BeatDuration=133 },
            new Tempo() { Name="84", BeatDuration=134 },
            new Tempo() { Name="85", BeatDuration=135 },
            new Tempo() { Name="86", BeatDuration=136 },
            new Tempo() { Name="87", BeatDuration=137 },
            new Tempo() { Name="88", BeatDuration=138 },
            new Tempo() { Name="89", BeatDuration=139 },
            new Tempo() { Name="90", BeatDuration=140 },
            new Tempo() { Name="91", BeatDuration=141 },
            new Tempo() { Name="92", BeatDuration=142 },
            new Tempo() { Name="93", BeatDuration=143 },
            new Tempo() { Name="94", BeatDuration=144 },
            new Tempo() { Name="95", BeatDuration=145 },
            new Tempo() { Name="96", BeatDuration=146 },
            new Tempo() { Name="97", BeatDuration=147 },
            new Tempo() { Name="98", BeatDuration=148 },
            new Tempo() { Name="99", BeatDuration=149 },
            new Tempo() { Name="100", BeatDuration=150 },
            new Tempo() { Name="101", BeatDuration=151 },
            new Tempo() { Name="102", BeatDuration=152 },
            new Tempo() { Name="103", BeatDuration=153 },
            new Tempo() { Name="104", BeatDuration=154 },
            new Tempo() { Name="105", BeatDuration=155 },
            new Tempo() { Name="106", BeatDuration=156 },
            new Tempo() { Name="107", BeatDuration=157 },
            new Tempo() { Name="108", BeatDuration=158 },
            new Tempo() { Name="109", BeatDuration=159 },
            new Tempo() { Name="110", BeatDuration=160 },
            new Tempo() { Name="111", BeatDuration=161 },
            new Tempo() { Name="112", BeatDuration=162 },
            new Tempo() { Name="113", BeatDuration=163 },
            new Tempo() { Name="114", BeatDuration=164 },
            new Tempo() { Name="115", BeatDuration=165 },
            new Tempo() { Name="116", BeatDuration=166 },
            new Tempo() { Name="117", BeatDuration=167 },
            new Tempo() { Name="118", BeatDuration=168 },
            new Tempo() { Name="119", BeatDuration=169 },
            new Tempo() { Name="120", BeatDuration=170 },
            new Tempo() { Name="121", BeatDuration=171 },
            new Tempo() { Name="122", BeatDuration=172 },
            new Tempo() { Name="123", BeatDuration=173 },
            new Tempo() { Name="124", BeatDuration=174 },
            new Tempo() { Name="125", BeatDuration=175 },
            new Tempo() { Name="126", BeatDuration=176 },
            new Tempo() { Name="127", BeatDuration=340 },
            new Tempo() { Name="128", BeatDuration=400 }


        };


    //This should set the total amount of BeatDuration per bar.
    public int getTimeSignature(string timeSig)
    {
        int totalTimePerBar = 0;
        switch (timeSig)
        {
            case "6/4":
                totalTimePerBar = BeatDuration * 6;
                break;
            case "5/4":
                totalTimePerBar = BeatDuration * 5;
                break;
            case "4/4":
                totalTimePerBar = BeatDuration * 4;
                break;
            case "3/4":
                totalTimePerBar = BeatDuration * 3;
                break;
            case "2/4":
                totalTimePerBar = BeatDuration * 2;
                break;
            //For Complex Time Signatures, we will just think of the BeatDuration as the duration of the 8th note instead of the quarter note
            case "6/8":
                totalTimePerBar = BeatDuration * 6;
                break;
            case "7/8":
                totalTimePerBar = BeatDuration * 7;
                break;
            case "8/8":
                totalTimePerBar = BeatDuration * 8;
                break;
            case "9/8":
                totalTimePerBar = BeatDuration * 9;
                break;
            case "10/8":
                totalTimePerBar = BeatDuration * 10;
                break;
            case "11/8":
                totalTimePerBar = BeatDuration * 11;
                break;
            case "12/8":
                totalTimePerBar = BeatDuration * 12;
                break;
            case "13/8":
                totalTimePerBar = BeatDuration * 13;
                break;
            case "14/8":
                totalTimePerBar = BeatDuration * 14;
                break;
            case "15/8":
                totalTimePerBar = BeatDuration * 15;
                break;
            default:
                System.ArgumentException argEx = new System.ArgumentException("Time signature (timeSig) was set improperly!", "timeSig");
                throw argEx;
        }
        return totalTimePerBar;
    }

    //The BeatDuration is a quarter note. To get every 16th note duration (including dotted 16ths) we 
    //only need to go 1/8 - 32/8 for 4/4 timing (1/8 - 24/8 for 3/4 timing and 1/8 - 16/8  for 2/4 etc..)
    //To get a Triplet duration use 333. I only set this up because there is no good number to get a triplet out of 
    //and the 333 numerator is so high it should never be used
    public int getNoteDuration(int barDivision) {
        double noteDuration;
        int roundedNoteDuration = 0;
        if (barDivision == 333)
        {
            noteDuration = BeatDuration / 3;
        }else
        {
            noteDuration = BeatDuration * (barDivision / 8);
        }
        //Since we need to use an int for Midi, I rounded. This may need to change, as the cumulative notes being rounded may end up messing  
        //up the timing. We could use a flag that switches back and forth depending on what was last or we could add up the total
        //beat duration from the cumulative divisions until it equals one whole int and add it to the next note. This might
        //take some more thought.
        roundedNoteDuration = (int)Math.Round(noteDuration);
        
        return roundedNoteDuration;
    }
    //Allows for usual beat durations to be called by name instead
    public int getNoteDuration(String noteType)
    {
        double noteDuration = 0;
        int roundedNoteDuration = 0;
        switch (noteType)
        {
            case "whole":
            case "1":
                noteDuration = BeatDuration * 4;
                break;
            case "dottedhalf":
            case "dothalf":
            case "3/2":
                noteDuration = BeatDuration * 3;
                break;
            case "half":
            case "1/2":
                noteDuration = BeatDuration * 2;
                break;
            case "dottedquarter":
            case "dotquarter":
            case "3/4":
                noteDuration = BeatDuration * 1.5;
                break;
            case "quarter":
            case "1/4":
                noteDuration = BeatDuration;
                break;
            case "dottedeigth":
            case "dotted8th":
            case "dotted8":
            case "dot8":
                noteDuration = BeatDuration * .75;
                break;
            case "eigth":
            case "8th":
            case "8":
                noteDuration = BeatDuration / 2;
                break;
            case "triplet":
            case "trip":
                noteDuration = BeatDuration / 3;
                break;
            case "dottedsixteenth":
            case "dotted16th":
            case "dotted16":
            case "dot16":
                noteDuration = BeatDuration * .375;
                break;
            case "sixteenth":
            case "16th":
            case "16":
                noteDuration = BeatDuration / 4;
                break;
            case "thirtysecond":
            case "32nd":
            case "32":
                noteDuration = BeatDuration * .125;
                break;
            default:
                System.ArgumentException argEx = new System.ArgumentException("noteDuration was set improperly!", "noteDuration");
                throw argEx;
        }
        roundedNoteDuration = (int)Math.Round(noteDuration);

        return roundedNoteDuration;
    }

    //Use this for note durations in Compound time signatures - Eigth note is the BeatDuration instead of a quarter note
    public int getCompoundNoteDuration(String noteType)
    {
        int roundedNoteDuration = 0;
        double noteDuration = 0;
        switch (noteType)
        {
            case "whole":
            case "1":
                noteDuration = BeatDuration * 8;
                break;
            case "dottedhalf":
            case "dothalf":
            case "3/4":
                noteDuration = BeatDuration * 6;
                break;
            case "half":
            case "1/2":
                noteDuration = BeatDuration * 4;
                break;
            case "dottedquarter":
            case "dotquarter":
                noteDuration = BeatDuration * 3;
                break;
            case "quarter":
            case "4":
                noteDuration = BeatDuration * 2;
                break;
            case "dottedeigth":
            case "dotted8th":
            case "dotted8":
            case "dot8":
                noteDuration = BeatDuration * 1.5;
                break;
            case "eigth":
            case "8th":
            case "8":
                noteDuration = BeatDuration;
                break;
            case "dottedsixteenth":
            case "dotted16th":
            case "dot16th":
            case "dot16":
                noteDuration = BeatDuration * .75;
                break;
            case "sixteenth":
            case "16th":
            case "16":
                noteDuration = BeatDuration / 2;
                break;
            case "tripleteigth":
            case "triple8th":
            case "triple8":
            case "trip8":
                noteDuration = BeatDuration / 3;
                break;
            case "dottedthirtysecond":
            case "dotted32nd":
            case "dot32nd":
            case "dot32":
                noteDuration = BeatDuration * .375;
                break;
            case "thirtysecond":
            case "32nd":
            case "32":
                noteDuration = BeatDuration / 4;
                break;
            case "sixtyfourth":
            case "64th":
            case "64":
                noteDuration = BeatDuration * .125;
                break;
            default:
                System.ArgumentException argEx = new System.ArgumentException("noteDuration for compound time was set improperly!", "noteDuration");
                throw argEx;
        }
        roundedNoteDuration = (int)Math.Round(noteDuration);

        return roundedNoteDuration;
    }
    /*
    public double getNoteDurations(beats nameDuration) {
        double noteDuration;
        switch (nameDuration)
        {
            case beats.wholenote:
                noteDuration = BeatDuration;
                break;
            case beats.halfnote:
                noteDuration = BeatDuration / 2;
                break;
            case beats.quarternote:
                noteDuration = BeatDuration / 4;
                break;
            case beats.eighthnote:
                noteDuration = BeatDuration / 8;
                break;
            case beats.sixteenthnote:
                noteDuration = BeatDuration / 16;
                break;
            default:
                noteDuration = 1;
                throw Exception("");
                break;

        }

        return noteDuration;
    }

    enum beats
    {
        wholenote = 1,
        halfnote = 2,
        quarternote = 3,
        eighthnote = 4,
        sixteenthnote = 5
    }
    */
}
//}
