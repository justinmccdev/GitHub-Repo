using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
//using $safeprojectname$.SheetMusic;

//namespace $safeprojectname$
//{


    /// <summary>
    /// Provides methods to save notes to a midi
    /// </summary>
    public static class MidiWriter
    {
        public const int MIDI_CHANNEL = 15;

        /// <summary>
        /// Use midi format 0, there's only 1 track
        /// </summary>
        private const Int16 MIDI_FORMAT = 0x01;

        private const Int16 MIDI_MULTI_TRACK_FORMAT = 0x01;

        /// <summary>
        /// Number of tracks used
        /// </summary>
        private const Int16 NR_OF_TRACKS_USED = 0x02;

        /// <summary>
        /// Milliseconds per minute
        /// </summary>
        private const int MILLISECONDS_PER_MINUTE = 60000;

        /// <summary>
        /// Use 120 bpm
        /// </summary>
        private const int BEATS_PER_MINUTE = 120;

        /// <summary>
        /// Ticks per beat, use 240
        /// </summary>
        private const int TICKS_PER_BEAT = 240;

        /// <summary>
        /// Meta event
        /// </summary>
        private const byte MSG_META = 0xFF;

        /// <summary>
        /// Set tempo meta type
        /// </summary>
        private const byte MSG_META_SETTEMPO = 0x51;

        /// <summary>
        /// Text meta midi event
        /// </summary>
        private const byte MSG_META_TEXT = 0x01;

        /// <summary>
        /// End of track meta midi event
        /// </summary>
        private const byte MSG_META_ENDOFTRACK = 0x2F;

        /// <summary>
        /// Note down message
        /// </summary>
        private const byte MSG_NOTE_DOWN = 0x9;
        /// <summary>
        /// Note up message
        /// </summary>
        private const byte MSG_NOTE_UP = 0x8;

        /// <summary>
        /// Pitch Bend Message
        /// 8192 : No bend
        /// 0    : Bend negitive as much as possible
        /// 16383: Bend positive as much as posible
        /// </summary>
        private const byte MSG_PITCH_BEND = 0xE;

        private const byte PITCH_NO_BEND = 0x20;


        /// <summary>
        /// Program change message
        /// </summary>
        private const byte MSG_PROGRAM_CHANGE = 0xC;

        /// <summary>
        /// Return the amount of ticks in a timespan
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static ulong GetTicks(TimeSpan t)
        {
            const double BEAT_PER_MILLISECOND = ((double)BEATS_PER_MINUTE / (double)MILLISECONDS_PER_MINUTE);
            const double TICKS_PER_MILLISECOND = TICKS_PER_BEAT * BEAT_PER_MILLISECOND;

            return (ulong)(t.TotalMilliseconds * TICKS_PER_MILLISECOND);
        }

        /// <summary>
        /// Write a midi file to the given path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="instrumentIdx"></param>
        /// <param name="notes"></param>
        public static void Write(string path, int instrumentIdx, List<Note> notes)
        {
            using (Stream stream = File.Create(path))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                WriteHeader(writer);

                WriteMetaTrack(writer);

                WriteTrack(writer, instrumentIdx, notes,MIDI_CHANNEL);
        }
        
    }

        public static void Write(string path, List<Track> tracks)
        {
            using (Stream stream = File.Create(path))
            {
                BinaryWriter writer = new BinaryWriter(stream);
                
                
                WriteMultiTrackHeader(writer, (ushort)(tracks.Count()));
                int i = 0;
                foreach(Track t in tracks)
                {
                    WriteTrack(writer, t.InstrumentIndex, t.Notes,i);
                    i += 1;
                }
            }
    }


        /// <summary>
        /// Write the midi header
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteHeader(BinaryWriter writer)
        {
            // write chunk ID
            writer.Write(new char[] { 'M', 'T', 'h', 'd' }, 0, 4);
            // write chunk size
            WriteInt32(writer.BaseStream, (uint)0x00000006);
            // write format
            WriteInt16(writer.BaseStream, (ushort)MIDI_FORMAT);

            // write nr of tracks
            WriteInt16(writer.BaseStream, (ushort)NR_OF_TRACKS_USED);

            // write time division
            //WriteVarLen((ulong)TICKS_PER_BEAT, writer.BaseStream);
            WriteInt16(writer.BaseStream, (ushort)TICKS_PER_BEAT);
        }

        private static void WriteMultiTrackHeader(BinaryWriter writer, ushort trackCount)
        {
            // write chunk ID
            writer.Write(new char[] { 'M', 'T', 'h', 'd' }, 0, 4);
            // write chunk size
            WriteInt32(writer.BaseStream, (uint)0x00000006);
            // write format
            WriteInt16(writer.BaseStream, (ushort)MIDI_FORMAT);

            // write nr of tracks
            WriteInt16(writer.BaseStream, (ushort)trackCount);

            // write time division
            //WriteVarLen((ulong)TICKS_PER_BEAT, writer.BaseStream);
            WriteInt16(writer.BaseStream, (ushort)TICKS_PER_BEAT);
        }



        private static void WriteMetaTrack(BinaryWriter writer)
        {
            // write track chunk ID
            writer.Write(new char[] { 'M', 'T', 'r', 'k' }, 0, 4);

            using (MemoryStream memStream = new MemoryStream())
            {
                const int MICROSECONDS_PER_QUARTER_NOTE = (int)((MILLISECONDS_PER_MINUTE * 1000f) / (float)BEATS_PER_MINUTE);

                // write tempo
                memStream.WriteByte(0); // 0 delta
                memStream.WriteByte(MSG_META);
                memStream.WriteByte(MSG_META_SETTEMPO);
                memStream.WriteByte(3); // length 3
                byte[] b = BitConverter.GetBytes(MICROSECONDS_PER_QUARTER_NOTE);
                memStream.WriteByte(b[2]);
                memStream.WriteByte(b[1]);
                memStream.WriteByte(b[0]);

              
                
                // write end of track
                memStream.WriteByte(0); // 0 delta
                memStream.WriteByte(MSG_META);
                memStream.WriteByte(MSG_META_ENDOFTRACK);
                memStream.WriteByte(0); // length 0

                // get bytes from total track
                byte[] trackBytes = memStream.ToArray();

                // write track chunk size
                WriteInt32(writer.BaseStream, (uint)(trackBytes.Length));

                // write track
                writer.Write(trackBytes, 0, trackBytes.Length);
            }
        }

        /// <summary>
        /// Write the midi track
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="instrumentIdx"></param>
        /// <param name="notes"></param>
        private static void WriteTrack(BinaryWriter writer, int instrumentIdx, List<Note> notes, int trackIndx)
        {
            // write track chunk ID
            writer.Write(new char[] { 'M', 'T', 'r', 'k' }, 0, 4);

            // use first note as start
            //DateTime start = notes.Min(n => n.TimeDown);
            

            using (MemoryStream memStream = new MemoryStream())
            {
                // write program change
                //byte eventTypeAndChannel = (byte)((MSG_PROGRAM_CHANGE << 4) + MIDI_CHANNEL);
                //byte eventTypeAndChannel = (byte)((MSG_PROGRAM_CHANGE << 4) + 0);
                byte eventTypeAndChannel = (byte)((MSG_PROGRAM_CHANGE << 4) + trackIndx);
                memStream.WriteByte(0);
                memStream.WriteByte(eventTypeAndChannel);
                memStream.WriteByte((byte)instrumentIdx);

                // build midi messages from the notes
                List<MidiMessage> midiMessagesFromNotes = new List<MidiMessage>();
                foreach (Note n in notes)
                {
                    int currPitchBend = 0;
                    //TimeSpan timeStart = (n.TimeDown);
                    //TimeSpan timeEnd = timeStart.Add(TimeSpan.FromMilliseconds(n.DurationMS));

                    int timeStart = (n.TimeDown);
                    int timeEnd = timeStart + n.DurationMS;

                    midiMessagesFromNotes.Add(new MidiMessage()
                    {
                        Time = timeStart,

                        //Channel = MIDI_CHANNEL,
                        Channel=(byte)trackIndx,
                        Message = MSG_NOTE_DOWN,
                        Param1 = (byte)n.MidiIndex,
                        Param2 = 64 // velocity
                    });

                    if (n.PitchBends != null)
                        foreach (var pB in n.PitchBends)
                        {
                            var args = GetPitchBendParameters(pB.TrgtPitchBend);
                            midiMessagesFromNotes.Add(new MidiMessage()
                            {
                                Channel = (byte)trackIndx,
                                Time = timeStart+pB.TimePitchBend,
                                Message = MSG_PITCH_BEND,
                                Param1 = args.Item1,
                                Param2 = args.Item2
                            });

                        }

                    midiMessagesFromNotes.Add(new MidiMessage()
                    {
                        Time = timeEnd,

                        //Channel = MIDI_CHANNEL,
                        Channel=(byte)trackIndx,
                        Message = MSG_NOTE_UP,
                        Param1 = (byte)n.MidiIndex,
                        Param2 = 64 // velocity
                    });
                }

                //TimeSpan last = new TimeSpan();
                int last = 0;
                foreach (MidiMessage msg in midiMessagesFromNotes.OrderBy(m => m.Time))
                {
                    // relative delta
                    //ulong delta = GetTicks(msg.Time.Subtract(last));
                    ulong delta = (ulong)(msg.Time - last);
                    last = msg.Time;

                    WriteVarLen(delta, memStream);

                    // write channel and midi message
                    byte channelAndMessage = (byte)((msg.Message << 4) + msg.Channel);
                    memStream.WriteByte(channelAndMessage);

                    // write midi index & velocity
                    memStream.WriteByte(msg.Param1);
                    memStream.WriteByte(msg.Param2);
                }

                // write end of track
                memStream.WriteByte(0); // 0 delta
                memStream.WriteByte(MSG_META);
                memStream.WriteByte(MSG_META_ENDOFTRACK);
                memStream.WriteByte(0); // length 0


                // get bytes from total track
                byte[] trackBytes = memStream.ToArray();

                // write track chunk size
                WriteInt32(writer.BaseStream, (uint)(trackBytes.Length));

                // write track
                writer.Write(trackBytes, 0, trackBytes.Length);
            }
        }

        /// <summary>
        /// Write int in big endian to the given stream
        /// </summary>
        /// <param name="s"></param>
        /// <param name="val"></param>
        private static void WriteInt32(Stream s, uint val)
        {
            byte[] b = BitConverter.GetBytes(val);
            s.WriteByte(b[3]);
            s.WriteByte(b[2]);
            s.WriteByte(b[1]);
            s.WriteByte(b[0]);
        }

        /// <summary>
        /// Write short in big endian to the given stream
        /// </summary>
        /// <param name="s"></param>
        /// <param name="val"></param>
        private static void WriteInt16(Stream s, ushort val)
        {
            byte[] b = BitConverter.GetBytes(val);
            s.WriteByte(b[1]);
            s.WriteByte(b[0]);
        }

        /// <summary>
        /// A midi message for a midi track
        /// </summary>
        private class MidiMessage
        {
            //public TimeSpan Time { get; set; }
            public int Time { get; set; }

            public ulong DeltaTime { get; set; }
            public byte Message { get; set; }
            public byte Channel { get; set; }
            public byte Param1 { get; set; }
            public byte Param2 { get; set; }
        }

        /// <summary>
        /// Write given long as variable length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="s"></param>
        private static void WriteVarLen(ulong value, Stream s)
        {
            ulong buffer = value & 0x7F;

            while ((value >>= 7) != 0)
            {
                buffer <<= 8;
                buffer |= ((value & 0x7F) | 0x80);
            }

            while (true)
            {
                s.WriteByte((byte)buffer);
                //putc(buffer,outfile);
                if ((buffer & 0x80) != 0)
                    buffer >>= 8;
                else
                    break;
            }
        }

        /// <summary>
        /// Returns the pitch bend arguments req. 
        /// To set pitch bend to a specific value +- 
        /// </summary>
        /// <param name="pitchBend"></param>
        /// <returns></returns>
        public static Tuple<Byte,Byte> GetPitchBendParameters(int pitchBend)
        {
            if (pitchBend > 8191 || pitchBend < -8192) throw new ArgumentOutOfRangeException("Pitchbend Range (-8192 to 8191)");
            pitchBend += 8192;

            //Tuple<Byte, Byte> ret;// = new Tuple<byte, byte>(0x20,0x00);
            //Console.WriteLine("{0} {0:x4}",pitchBend, pitchBend);
            Byte b1 =(byte)((pitchBend & 0xFF80)>>7);
            Byte b2 = (byte)((pitchBend & 0x007F));

            return new Tuple<byte, byte>(b1, b2);
            //return ret;
        }
        public static int FromPitchBendParameters(byte b1, byte b2)
        {
            int i = b2 + (b1 << 7);
            return i;
        }
    }
//}
