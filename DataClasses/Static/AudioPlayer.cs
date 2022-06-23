using System;
using System.Linq;
using NAudio.Wave;

namespace Synovian_Character_Maker.DataClasses.Static
{
    public class AudioPlayer
    {
        /// This Audio player uses the folllowing 3rd party library
        /// https://github.com/naudio/NAudio
        /// 

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        ProgramSettings settings;

        public bool onLoop
        {
            get => _onLoop;
            set
            {
                _onLoop = value;
                if (settings != null)
                {
                    settings.LoopSong = value;
                }
            }
        }
        private bool _onLoop;

        public decimal volume
        {
            get => (decimal)outputDevice.Volume;
            set
            {
                if (outputDevice != null)
                {
                    outputDevice.Volume = (float)value;
                }
                if (settings != null)
                {
                    settings.AudioVolume = value;
                }
            }
        }

        public AudioPlayer(string audioFileUrl, ref ProgramSettings programSettings)
        {
            settings = programSettings;

            if (audioFileUrl != "")
            {
                try
                {
                    outputDevice = new WaveOutEvent();
                    audioFile = new AudioFileReader($"{Globals.AudioFolder}\\{audioFileUrl}");
                    outputDevice.Init(audioFile);
                    outputDevice.PlaybackStopped += OnPlaybackStopped;
                    outputDevice.Play();
                    onLoop = true;
                }
                catch (Exception e)
                {
                    ExceptionHandles.ExceptionHandle(e);
                }
            }
        }

        public AudioPlayer(string audioFileUrl, ref ProgramSettings programSettings, bool loop = true)
        {
            settings = programSettings;

            try
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
            catch (Exception e) { ExceptionHandles.ExceptionHandle(e); }
        }

        public void ChangeSong(string audioFileUrl)
        {
            try
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
            catch (Exception e) { ExceptionHandles.ExceptionHandle(e); }
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
        public void SetVolume(float volume) => outputDevice.Volume = volume;
        public string SongName() => audioFile.FileName.Split('\\')[audioFile.FileName.Split('\\').Count() - 1];
        private void OnPlaybackStopped(object sender, StoppedEventArgs eventArgs)
        {
            if (onLoop && outputDevice.PlaybackState == PlaybackState.Stopped && outputDevice.DeviceNumber != -1)
            {
                outputDevice.Play();
            }
        }
    }
}