using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SoundSystem
{
    public enum LayerType
    {
        Additive,
        Single
    }


    [CreateAssetMenu(menuName = "SoundSystem/Music Event", fileName = "MUS_")]
    public class MusicEvent : ScriptableObject
    {
        [Header("General Settings")]
        [SerializeField] AudioClip[] _musicLayers = null;

        [SerializeField] LayerType _layerType = LayerType.Additive;

        [SerializeField] AudioMixerGroup _mixer;

        public AudioClip[] MusicLayers => _musicLayers;
        public LayerType LayerType => _layerType;
        public AudioMixerGroup Mixer => _mixer;

        public float Volume { get; private set; }

        public float Pitch { get; private set; }

        public void Play(float fadeTime)
        {
            MusicManager.Instance.PlayMusic(this, fadeTime);
        }

        public void Preview (AudioSource source)
        {
            
        }
    }
}
