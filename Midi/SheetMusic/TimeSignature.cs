using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$.SheetMusic
//{
    public class TimeSignature
    {
        
        public int numerator; 
        public int denominator;

        public  static List<TimeSignature> TimeSignatures = new List<TimeSignature>()
        {



           new TimeSignature() { numerator=2, denominator=4 },
           new TimeSignature() { numerator=3, denominator=4 },
           new TimeSignature() { numerator=4, denominator=4 },
           new TimeSignature() { numerator=8, denominator=4 }

            /*For 4/4 Timing
             * Let's say a quarter note is set at a beat duration of 100. 400 would be the total beat duration of the entire bar
             * 
             * So we will need to list out the largest note to the smallest note as a function based on this duration
             * 
             * Since we can have a note held for every duration - (a note held for 3 beat + 15/16ths of one beat)
             * we could list the commonly used ones first, at work our way down (but please look at section 2 for how we will actually do this):
             * 
             * Whole note - Beat duration * 4  =  400
             * Half note - Beat duration * 2  = 200
             * Quarter note - Beat duration * 1 = 100
             * Eigth note - Beat duration / 2 = 50
             * Triplets - Beat duration / 3 = 33.33
             * Sixteenth note - Beat duration / 4 = 25
             * 
             * Then onward to the lesser used durations
             * 
             * Dotted Half note - Beat duration * 3 = 300
             * Dotted Quarter note - Beat duration * 1.5 = 150
             * Dotted Eigth note - Beat duration * .75 = 75
             * Triplets in Eigth note duration - Beat duration / 6 = 16.6666666
             * 
             * 
             * **********SECTION2*********
             * We can obviously go for every 16th note if we want as well for a total of 16, and just mark which ones would be the durations 
             * above so we can always have every option open to use for every possible duration type and just add in the triplets since
             * they have their own special durations so it would be something like
             * 
             * Beat duration * 1/8
             * Beat duration * 2/8
             * Beat duration * 3/8
             * Beat duration * 4/8  = Eigth note 
             *                 8/8  =quarter
             * etc...
             * 
             * Til we get the total number of every divisible fraction in 4/4 time
             * 
             * This could be used then for every simple meter because 1/8 through 16/8 would give us every note in 2/4 time
             * and 1/4 through 24/8 would give us every duration for 3/4 time etc...
             * 
             * 
             * Complex meters might take some more thought but we can use the same shortcut as above for the divisions
             * 
             */ 
        };

    }
//}
