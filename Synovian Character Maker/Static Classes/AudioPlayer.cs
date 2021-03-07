using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Synovian_Character_Maker.Static_Classes
{
    public class AudioPlayer
    {
        /// This Audio player uses the folllowing 3rd party library
        /// https://github.com/naudio/NAudio
        /// 

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        
        public bool onLoop { get; set; }

        public AudioPlayer(string audioFileUrl)
        {
            if (audioFileUrl != "")
            {
                outputDevice = new WaveOutEvent();
                audioFile = new AudioFileReader(audioFileUrl);
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                onLoop = true;
            }
        }

        public AudioPlayer(string audioFileUrl, bool loop = true)
        {
            if (audioFileUrl != "")
            {
                outputDevice = new WaveOutEvent();
                audioFile = new AudioFileReader(audioFileUrl);
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Play();
                onLoop = loop;
            }
        }

        public void ChangeSong(string audioFileUrl)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                audioFile = new AudioFileReader(audioFileUrl);
                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Play();
                return;
            }

            if (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Stop();
            }
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFileUrl);
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += OnPlaybackStopped;
            outputDevice.Play();
        }

        public TimeSpan CurrentTime() => audioFile.CurrentTime;

        public TimeSpan Length() => audioFile.TotalTime;

        public bool IsPlaying()
        {
            if (outputDevice != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public bool IsValid() => outputDevice != null && audioFile != null;
        public float Volume() => outputDevice.Volume;
        public void SetVolume(float volume) => outputDevice.Volume = volume;
        public string SongName() => audioFile.FileName.Split('\\')[audioFile.FileName.Split('\\').Count() - 1];
        private void OnPlaybackStopped(object sender, StoppedEventArgs eventArgs)
        {
            if(onLoop && outputDevice.PlaybackState == PlaybackState.Stopped)
            {
                outputDevice.Play();
            }
        }
    }
}
