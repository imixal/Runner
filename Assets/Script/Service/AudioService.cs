using System;
using System.Collections.Generic;
using System.Linq;
using Script.interfece;
using UnityEngine;

namespace Script.Service
{
    public class AudioService : IAudioService
    {
        private readonly Dictionary<string, Sound> _sounds;
        private float _volume = 1;
        private bool _mute;
        public AudioService(IEnumerable<Sound> sounds)
        {
            foreach (var sound in sounds)
            {
                sound.Init();
            }

            _sounds = sounds.ToDictionary(s => s.name);
        }
        public void Play(string soundName)
        {
            if (_sounds.TryGetValue(soundName, out var sound))
            {
                sound.source.Play();
                return;
            }
            Debug.LogWarning($"The sound {soundName} not found");
        }

        public void Stop(string soundName)
        {
            if (_sounds.TryGetValue(soundName, out var sound))
            {
                sound.source.Stop();
                return;
            }
            Debug.LogWarning($"The sound {soundName} not found");
        }

        public float Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                foreach (var kv in _sounds)
                {
                    kv.Value.source.volume = _volume;
                }
            } 
        }

        public bool Mute
        {
            get => _mute;
            set
            {
                _mute = value;
                foreach (var sound in _sounds.Values)
                {
                    sound.source.Stop();
                }
            }
        }
    }

    [Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)]
        public float pitch;
        public bool loop;

        [HideInInspector]
        public AudioSource source;
        
        public void Init()
        {
        }
    }
}