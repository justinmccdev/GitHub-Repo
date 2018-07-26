using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Media;

//namespace $safeprojectname$
//{
    /// <summary>
    /// Provides a way to communicate with the installed MIDI controllers
    /// </summary>
    public class MidiManager
    {
        private int handle = 0;

        // Handle midi messages sent from system.
        private delegate void MidiCallback(int handle, int msg,
                   int instance, int param1, int param2);

        [DllImport("winmm.dll")]
        private static extern int midiOutOpen(ref int handle, int deviceID,
            MidiCallback proc, int instance, int flags);

        [DllImport("winmm.dll")]
        private static extern int midiOutClose(int handle);

        [DllImport("winmm.dll")]
        private static extern int midiOutShortMsg(int handle, int message);

        [DllImport("winmm.dll")]
        private static extern UInt32 midiOutGetNumDevs();

        public struct MIDIOUTCAPS
        {
            public UInt16 wMid;
            public UInt16 wPid;
            public UInt32 vDriverVersion;
            [MarshalAs(UnmanagedType.ByValTStr,
             SizeConst = 32)]
            public string szPname;
            public UInt16 wTechnology;
            public UInt16 wVoices;
            public UInt16 wNotes;
            public UInt16 wChannelMask;
            public UInt32 dwSupport;
        }

        [DllImport("winmm.dll")]
        static public extern UInt32 midiOutGetDevCaps(Int32 uDeviceID,
               ref MIDIOUTCAPS lpMidiOutCaps, UInt32 cbMidiOutCaps);


        /// <summary>
        /// Open midi output for specified device
        /// </summary>
        /// <param name="deviceID"></param>
        /// <returns></returns>
        private int OpenMidiOutput(int deviceID)
        {
            midiOutOpen(ref handle, deviceID, null, 0, 0);
            return handle;
        }

        /// <summary>
        /// Close midi ouput for device handle
        /// </summary>
        /// <param name="deviceHandle"></param>
        private void CloseMidiOutput(int deviceHandle)
        {
            midiOutClose(handle);
        }

        /// <summary>
        /// A list of all Midi Devices installed
        /// </summary>
        public static IEnumerable<string> MidiDevices
        {
            get
            {
                List<string> midiDevices = new List<string>();

                UInt32 numberOfDevices = MidiManager.midiOutGetNumDevs();
                if (numberOfDevices > 0)
                {
                    for (Int32 i = 0; i < numberOfDevices; i++)
                    {
                        MidiManager.MIDIOUTCAPS caps = new MidiManager.MIDIOUTCAPS();
                        MidiManager.midiOutGetDevCaps(i, ref caps, (UInt32)Marshal.SizeOf(caps));
                        midiDevices.Add(caps.szPname);
                    }
                }
                return midiDevices;
            }
        }

        /// <summary>
        /// Send a note down to the current midi device
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="channel"></param>
        /// <param name="velocity"></param>
        public void NoteDown(short idx, short channel, short velocity)
        {
            if (velocity == 0) // don't play 0 volume notes
                return;

            int midiMsg = 0x90 + ((5 + (idx + 1)) * 0x100) + (velocity * 0x10000) + channel;

            midiOutShortMsg(handle, midiMsg);
        }

        /// <summary>
        /// Send a note up to the current midi device
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="channel"></param>
        /// <param name="velocity"></param>
        public void NoteUp(short idx, short channel, short velocity)
        {
            if (velocity == 0) // don't play 0 volume notes
                return;

            int midiMsg = 0x80 + ((5 + (idx + 1)) * 0x100) + (velocity * 0x10000) + channel;

            midiOutShortMsg(handle, midiMsg);
        }


        /// <summary>
        /// List of standard GM instruments
        /// </summary>
 
   
        /// <summary>
        /// Change the current midi device to output notes to
        /// </summary>
        /// <param name="deviceIndex"></param>
        public void ChangeMidiDevice(int deviceIndex)
        {
            CloseMidiOutput(0);
            OpenMidiOutput(deviceIndex);
        }


        /// <summary>
        /// Change the instrument for the notes played
        /// </summary>
        /// <param name="instrumentIdx"></param>
        /// <param name="channel"></param>
        public void ChangeInstrument(int instrumentIdx, int channel)
        {
            midiOutShortMsg(handle, 0xC0 + (instrumentIdx * 0x100) + (instrumentIdx) * 0x10000 + channel);
        }

        //// OLD VB6 CODE, port as required


        ////Option Explicit

        ////Public Const MAXPNAMELEN = 32             ' Maximum product name length

        ////' Error values for functions used in this sample. See the function for more information
        ////Public Const MMSYSERR_BASE = 0
        ////Public Const MMSYSERR_BADDEVICEID = (MMSYSERR_BASE + 2)     ' device ID out of range
        ////Public Const MMSYSERR_INVALPARAM = (MMSYSERR_BASE + 11)     ' invalid parameter passed
        ////Public Const MMSYSERR_NODRIVER = (MMSYSERR_BASE + 6)        ' no device driver present
        ////Public Const MMSYSERR_NOMEM = (MMSYSERR_BASE + 7)           ' memory allocation error

        ////Public Const MMSYSERR_INVALHANDLE = (MMSYSERR_BASE + 5)     ' device handle is invalid
        ////Public Const MIDIERR_BASE = 64
        ////Public Const MIDIERR_STILLPLAYING = (MIDIERR_BASE + 1)      ' still something playing
        ////Public Const MIDIERR_NOTREADY = (MIDIERR_BASE + 3)          ' hardware is still busy
        ////Public Const MIDIERR_BADOPENMODE = (MIDIERR_BASE + 6)       ' operation unsupported w/ open mode

        ////'User-defined variable the stores information about the MIDI output device.
        ////Type MIDIOUTCAPS
        ////   wMid As Integer                   ' Manufacturer identifier of the device driver for the MIDI output device
        ////                                     ' For a list of identifiers, see the Manufacturer Indentifier topic in the
        ////                                     ' Multimedia Reference of the Platform SDK.

        ////   wPid As Integer                   ' Product Identifier Product of the MIDI output device. For a list of
        ////                                     ' product identifiers, see the Product Identifiers topic in the Multimedia
        ////                                     ' Reference of the Platform SDK.

        ////   vDriverVersion As Long            ' Version number of the device driver for the MIDI output device.
        ////                                     ' The high-order byte is the major version number, and the low-order byte is
        ////                                     ' the minor version number.

        ////   szPname As String * MAXPNAMELEN   ' Product name in a null-terminated string.

        ////   wTechnology As Integer            ' One of the following that describes the MIDI output device:
        ////                                     '     MOD_FMSYNTH-The device is an FM synthesizer.
        ////                                     '     MOD_MAPPER-The device is the Microsoft MIDI mapper.
        ////                                     '     MOD_MIDIPORT-The device is a MIDI hardware port.
        ////                                     '     MOD_SQSYNTH-The device is a square wave synthesizer.
        ////                                     '     MOD_SYNTH-The device is a synthesizer.

        ////   wVoices As Integer                ' Number of voices supported by an internal synthesizer device. If the
        ////                                     ' device is a port, this member is not meaningful and is set to 0.

        ////   wNotes As Integer                 ' Maximum number of simultaneous notes that can be played by an internal
        ////                                     ' synthesizer device. If the device is a port, this member is not meaningful
        ////                                     ' and is set to 0.

        ////   wChannelMask As Integer           ' Channels that an internal synthesizer device responds to, where the least
        ////                                     ' significant bit refers to channel 0 and the most significant bit to channel
        ////                                     ' 15. Port devices that transmit on all channels set this member to 0xFFFF.

        ////   dwSupport As Long                 ' One of the following describes the optional functionality supported by
        ////                                     ' the device:
        ////                                     '     MIDICAPS_CACHE-Supports patch caching.
        ////                                     '     MIDICAPS_LRVOLUME-Supports separate left and right volume control.
        ////                                     '     MIDICAPS_STREAM-Provides direct support for the midiStreamOut function.
        ////                                     '     MIDICAPS_VOLUME-Supports volume control.
        ////                                     '
        ////                                     ' If a device supports volume changes, the MIDICAPS_VOLUME flag will be set
        ////                                     ' for the dwSupport member. If a device supports separate volume changes on
        ////                                     ' the left and right channels, both the MIDICAPS_VOLUME and the
        ////                                     ' MIDICAPS_LRVOLUME flags will be set for this member.
        ////End Type

        ////Declare Function midiOutGetNumDevs Lib "winmm" () As Integer
        ////' This function retrieves the number of MIDI output devices present in the system.
        ////' The function returns the number of MIDI output devices. A zero return value means
        ////' there are no MIDI devices in the system.

        ////Declare Function midiOutGetDevCaps Lib "winmm.dll" Alias "midiOutGetDevCapsA" (ByVal uDeviceID As Long, lpCaps As MIDIOUTCAPS, ByVal uSize As Long) As Long
        ////' This function queries a specified MIDI output device to determine its capabilities.
        ////' The function requires the following parameters;
        ////'     uDeviceID-     unsigned integer variable identifying of the MIDI output device. The
        ////'                    device identifier specified by this parameter varies from zero to one
        ////'                    less than the number of devices present. This parameter can also be a
        ////'                    properly cast device handle.
        ////'     lpMidiOutCaps- address of a MIDIOUTCAPS structure. This structure is filled with
        ////'                    information about the capabilities of the device.
        ////'     cbMidiOutCaps- the size, in bytes, of the MIDIOUTCAPS structure. Use the Len
        ////'                    function with the MIDIOUTCAPS variable as the argument to get
        ////'                    this value.
        ////'
        ////' The function returns MMSYSERR_NOERROR if successful or one of the following error values:
        ////'     MMSYSERR_BADDEVICEID    The specified device identifier is out of range.
        ////'     MMSYSERR_INVALPARAM     The specified pointer or structure is invalid.
        ////'     MMSYSERR_NODRIVER       The driver is not installed.
        ////'     MMSYSERR_NOMEM          The system is unable to load mapper string description.

        ////Declare Function midiOutClose Lib "winmm.dll" (ByVal hMidiOut As Long) As Long
        ////' The function closes the specified MIDI output device. The function requires a
        ////' handle to the MIDI output device. If the function is successful, the handle is no
        ////' longer valid after the call to this function. A successful function call returns
        ////' MMSYSERR_NOERROR.

        ////' A failure returns one of the following:
        ////'     MIDIERR_STILLPLAYING  Buffers are still in the queue.
        ////'     MMSYSERR_INVALHANDLE  The specified device handle is invalid.
        ////'     MMSYSERR_NOMEM        The system is unable to load mapper string description.

        ////Declare Function midiOutOpen Lib "winmm.dll" (lphMidiOut As Long, ByVal uDeviceID As Long, ByVal dwCallback As Long, ByVal dwInstance As Long, ByVal dwFlags As Long) As Long
        ////' The function opens a MIDI output device for playback. The function requires the
        ////' following parameters
        ////'     lphmo-               Address of an HMIDIOUT handle. This location is filled with a
        ////'                          handle identifying the opened MIDI output device. The handle
        ////'                          is used to identify the device in calls to other MIDI output
        ////'                          functions.
        ////'     uDeviceID-           Identifier of the MIDI output device that is to be opened.
        ////'     dwCallback-          Address of a callback function, an event handle, a thread
        ////'                          identifier, or a handle of a window or thread called during
        ////'                          MIDI playback to process messages related to the progress of
        ////'                          the playback. If no callback is desired, set this value to 0.
        ////'     dwCallbackInstance-  User instance data passed to the callback. Set this value to 0.
        ////'     dwFlags-Callback flag for opening the device. Set this value to 0.
        ////'
        ////' The function returns MMSYSERR_NOERROR if successful or one of the following error values:
        ////'     MIDIERR_NODEVICE-       No MIDI port was found. This error occurs only when the mapper is opened.
        ////'     MMSYSERR_ALLOCATED-     The specified resource is already allocated.
        ////'     MMSYSERR_BADDEVICEID-   The specified device identifier is out of range.
        ////'     MMSYSERR_INVALPARAM-    The specified pointer or structure is invalid.
        ////'     MMSYSERR_NOMEM-         The system is unable to allocate or lock memory.

        ////Declare Function midiOutShortMsg Lib "winmm.dll" (ByVal hMidiOut As Long, ByVal dwMsg As Long) As Long
        ////' This function sends a short MIDI message to the specified MIDI output device. The function
        ////' requires the handle to the MIDI output device and a message is packed into a doubleword
        ////' value with the first byte of the message in the low-order byte. See the code sample for
        ////' how to create this value.
        ////'
        ////' The function returns MMSYSERR_NOERROR if successful or one of the following error values:
        ////'     MIDIERR_BADOPENMODE-  The application sent a message without a status byte to a stream handle.
        ////'     MIDIERR_NOTREADY-     The hardware is busy with other data.
        ////'     MMSYSERR_INVALHANDLE- The specified device handle is invalid.


        ////Public numDevices As Long      ' number of midi output devices
        ////Public curDevice As Long       ' current midi device
        ////Public hmidi As Long           ' midi output handle
        ////Public rc As Long              ' return code
        ////Public midimsg As Long         ' midi output message buffer
        ////'Public channel As Integer      ' midi output channel
        ////Public volume As Double       ' midi volume
        ////Public incra As Integer        ' increment the note
        ////Public tempo As Integer        ' set playing speed
        ////Public incraup As Integer      ' incra-1

        ////Const BASENOTE = 20

        ////'Public mastervolume As Integer

        ////Dim instrument As Integer

        ////Sub NoteDown(idx As Integer, program As Integer, channel As Integer, velocity As Integer)

        ////'    If program <> instrument Then ChangeInstrument (program)
        ////    Call ChangeInstrument(program, channel)

        ////    If velocity = 0 Then
        ////        'don't play 0 volume notes
        ////        Exit Sub
        ////    End If

        ////    Dim midimessage As String
        ////    midimessage = &H90 + ((5 + (idx + 1)) * &H100) + (velocity * &H10000) + channel
        ////    'midimessage = &H90 + ((5 + (idx + 1)) * &H100) + (velocity * &H10000) + channel

        ////    midiOutShortMsg hmidi, midimessage
        ////End Sub

        ////Sub NoteUp(idx As Integer, program As Integer, channel As Integer)
        ////    'If program <> instrument Then ChangeInstrument (program)



        ////    Dim midimessage As String
        ////    midimessage = &H80 + ((5 + (idx + 1)) * &H100) + (0 * &H10000) + channel

        ////    midiOutShortMsg hmidi, midimessage
        ////End Sub

        ////Sub AllNotesUp(channel As Integer)
        ////    Dim midimessage As String
        ////    midimessage = &HB0 + (&H7B * &H100) + 0 * &H10000 + channel
        ////    midiOutShortMsg hmidi, midimessage

        ////'    midimessage = &HB0 + (&H78 * &H100) + 0 * &H10000 + channel
        ////'    midiOutShortMsg hmidi, midimessage

        ////End Sub

        ////Sub AllControllersOff(channel As Integer)
        ////    Dim midimessage As String
        ////    midimessage = &HB0 + (&H79 * &H100) + 0 * &H10000 + channel

        ////    midiOutShortMsg hmidi, midimessage
        ////End Sub

        ////Sub changeVolume(v As Integer, channel As Integer)
        ////    Dim midimessage As String

        ////    midimessage = &HB0 + (&H7 * &H100) + Int(v * volume) * &H10000 + channel


        ////    midiOutShortMsg hmidi, midimessage
        ////End Sub

        ////Private Sub ChangeInstrument(newinstrument As Integer, channel As Integer)
        ////    instrument = newinstrument
        ////    midiOutShortMsg hmidi, &HC0 + (instrument * &H100) + (instrument) * &H10000 + channel
        ////End Sub

        ////Sub RAWControlChange(param1 As Integer, param2 As Integer, channel As Integer) 'avoid using
        ////    Dim midimessage As String
        ////    midimessage = &HB0 + (CInt(param1) * &H100) + param2 * &H10000 + channel

        ////    midiOutShortMsg hmidi, midimessage
        ////End Sub

    }
//}
