using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace $safeprojectname$.SheetMusic
//{
    public class Chord
    {
        public String Name;
        public List<int> offsets;


    public static List<Chord> chords = new List<Chord>()
        {
            //Triads!                                                                                     //# on the List
            new Chord() { Name= "Major Triad", offsets=new List<int>() { 0,4,7 } },                       //0
            new Chord() { Name= "Minor Triad",offsets=new List<int>() { 0,3,7 } },                        //1
            new Chord() { Name= "Diminished Triad",offsets=new List<int>() { 0,3,6 } },                   //2
            new Chord() { Name= "Augmented Triad", offsets=new List<int>() { 0,4,8 } },                   //3
            
            //Seventh Chords!
            new Chord() {Name="Dominant Seventh", offsets=new List<int>() {0,4,7,10 } },                  //4     //-- Also called the Major-Minor Chord
            new Chord() {Name="Minor Seventh", offsets=new List<int>() {0,3,7,10 } },                     //5
            new Chord() {Name="Major Seventh", offsets=new List<int>() {0,4,7,11 } },                     //6
            new Chord() {Name="Minor Major Seventh", offsets=new List<int>() {0,3,7,11 } },               //7
            new Chord() {Name="Diminished Seventh", offsets=new List<int>() {0,3,6,9 } },                 //8
            new Chord() {Name="Half Diminished Seventh", offsets=new List<int>() {0,3,6,10 } },           //9
            new Chord() {Name="Augmented Seventh", offsets=new List<int>() {0,4,8,10 } },                 //10
            new Chord() {Name="Augmented Major Seventh", offsets=new List<int>() {0,4,8,11 } },           //11

            //The next 2  chord sets are just commonly used and have doubles in the intervals section
            //I just put them here for easy reference

            //Power Chord
            new Chord() {Name="Power Chord", offsets=new List<int>() {0,7 } },                            //12  
            //Octave
            new Chord() {Name="Octave", offsets=new List<int>() {0,12 } },                                //13

            //2 Note Intervals - Not Chords!
            new Chord() {Name="Minor 2nd", offsets=new List<int>() {0,1 } },                              //14      - m2  1 Half Step
            new Chord() {Name="Major 2nd", offsets=new List<int>() {0,2 } },                              //15      - M2  2 Half Step  - 1 Whole Step
            new Chord() {Name="Minor 3rd", offsets=new List<int>() {0,3 } },                              //16      - m3  3 Half Steps
            new Chord() {Name="Major 3rd", offsets=new List<int>() {0,4 } },                              //17      - M3  4 Half Steps - 2 Whole Steps
            new Chord() {Name="Perfect 4th", offsets=new List<int>() {0,5 } },                            //18      - P4  5 Half Steps
            new Chord() {Name="Augmented 4th/Diminished 5th/Tritone", offsets=new List<int>() {0,6 } },   //19      - A4/d5 6 Half Steps - 3 Whole Steps      
            new Chord() {Name="Perfect 5th ", offsets=new List<int>() {0,7 } },                           //20      - P5  7 Half Steps           
            new Chord() {Name="Minor 6th", offsets=new List<int>() {0,8 } },                              //21      - m6  8 Half Steps  - 4 Whole Steps
            new Chord() {Name="Major 6th", offsets=new List<int>() {0,9 } },                              //22      - M6  9 Half Steps
            new Chord() {Name="Minor 7th", offsets=new List<int>() {0,10 } },                             //23      - m7  10 Half Steps - 5 Whole Steps
            new Chord() {Name="Major 7th", offsets=new List<int>() {0,11 } },                             //24      - M7  11 Half Steps 
            new Chord() {Name="Octave", offsets=new List<int>() {0,12 } },                                //25      - P8  12 Half Steps

            //1st Inversion Triads!
            new Chord() {Name= "1st Inv Major Triad", offsets=new List<int>() { 4,7,12 } },               //26
            new Chord() {Name= "1st Inv Minor Triad",offsets=new List<int>() { 3,7,12 } },                //27
            new Chord() {Name= "1st Inv Diminished Triad",offsets=new List<int>() { 3,6,12 } },           //28
            new Chord() {Name= "1st Inv Augmented Triad", offsets=new List<int>() { 4,8,12 } },           //29
            
                   
            //1st Inversion Seventh Chords!
            new Chord() {Name="1st Inv Dominant Seventh", offsets=new List<int>() {4,7,10,12 } },         //30
            new Chord() {Name="1st Inv Minor Seventh", offsets=new List<int>() { 3,7,10,12 } },           //31
            new Chord() {Name="1st Inv Major Seventh", offsets=new List<int>() {4,7,11,12 } },            //32
            new Chord() {Name="1st Inv Minor Major Seventh", offsets=new List<int>() {3,7,11,12 } },      //33
            new Chord() {Name="1st Inv Diminished Seventh", offsets=new List<int>() {3,6,9,12 } },        //34
            new Chord() {Name="1st Inv Half Diminished Seventh", offsets=new List<int>() {3,6,10,12 } },  //35
            new Chord() {Name="1st Inv Augmented Seventh", offsets=new List<int>() {4,8,10,12 } },        //36
            new Chord() {Name="1st Inv Augmented Major Seventh", offsets=new List<int>() {4,8,11,12 } },  //37

            //2nd Inversion Triads!
            new Chord() {Name= "2nd Inv Major Triad", offsets=new List<int>() { 7,12,16 } },              //38
            new Chord() {Name= "2nd Inv Minor Triad",offsets=new List<int>() { 7,12,15 } },               //39
            new Chord() {Name= "2nd Inv Diminished Triad",offsets=new List<int>() { 6,12,15 } },          //40
            new Chord() {Name= "2nd Inv Augmented Triad", offsets=new List<int>() { 8,12,16 } },          //41

            //2nd Inversion Seventh Chords!
            new Chord() {Name="2nd Inv Dominant Seventh", offsets=new List<int>() {7,10,12,16 } },          //42
            new Chord() {Name="2nd Inv Minor Seventh", offsets=new List<int>() { 7,10,12,15 } },            //43
            new Chord() {Name="2nd Inv Major Seventh", offsets=new List<int>() { 7,11,12,16 } },            //44
            new Chord() {Name="2nd Inv Minor Major Seventh", offsets=new List<int>() { 7,11,12,15 } },      //45
            new Chord() {Name="2nd Inv Diminished Seventh", offsets=new List<int>() { 6,9,12,15 } },        //46
            new Chord() {Name="2nd Inv Half Diminished Seventh", offsets=new List<int>() { 6,10,12,15 } },  //47
            new Chord() {Name="2nd Inv Augmented Seventh", offsets=new List<int>() { 8,10,12,16 } },        //48
            new Chord() {Name="2nd Inv Augmented Major Seventh", offsets=new List<int>() { 8,11,12,16 } },  //49

            //3rd Inversion Seventh Chords!
            new Chord() {Name="3rd Inv Dominant Seventh", offsets=new List<int>() { 10,12,16,19 } },        //50
            new Chord() {Name="3rd Inv Minor Seventh", offsets=new List<int>() { 10,12,15,19 } },           //51
            new Chord() {Name="3rd Inv Major Seventh", offsets=new List<int>() { 11,12,16,19 } },           //52
            new Chord() {Name="3rd Inv Minor Major Seventh", offsets=new List<int>() { 11,12,15,19 } },     //53
            new Chord() {Name="3rd Inv Diminished Seventh", offsets=new List<int>() { 9,12,15,18 } },       //54
            new Chord() {Name="3rd Inv Half Diminished Seventh", offsets=new List<int>() { 10,12,15,18 } }, //55
            new Chord() {Name="3rd Inv Augmented Seventh", offsets=new List<int>() { 10,12,16,20 } },       //56
            new Chord() {Name="3rd Inv Augmented Major Seventh", offsets=new List<int>() { 11,12,16,20 } }, //57

            //Just play 1 note
            new Chord() { Name= "note",offsets=new List<int>() { 0 } },                                     //58
        };
    }

/*
Intervals      
P1, d2 = 0  //      -12
m2, A1 = 1  //      -11
M2, d3 = 2  //      -10
m3, A2 = 3  //       -9
M3, d4 = 4  //       -8
P4, A3 = 5  //       -7
A4, d5 = 6  //       -6
P5, d6 = 7  //       -5
m6, A5 = 8  //       -4
M6, d7 = 9  //       -3
m7, A6 = 10 //       -2
M7, d8 = 11 //       -1
P8, A7 = 12 //        0
*/