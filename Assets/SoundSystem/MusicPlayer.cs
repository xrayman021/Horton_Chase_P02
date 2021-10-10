using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicPlayer : MonoBehaviour
    {
        List<AudioSource> _layerSources = new List<AudioSource>();

        private void Awake()
        {
            CreateLayerSources();
        }

        void CreateLayerSources()
        {
            for (int i = 0; i < MusicManager.MaxLayerCount; i++)
            {
                _layerSources.Add(gameObject.AddComponent<AudioSource>());

                _layerSources[i].playOnAwake = false;
                _layerSources[i].loop = true;
            }
        }

        public void Play(MusicEvent musicEvent, float fadeTime)
        {
            Debug.Log("Play Music");
            for(int i = 0; i < _layerSources.Count && (i < musicEvent.MusicLayers.Length); i++)
            {
                if(musicEvent.MusicLayers[i] != null)
                {
                    _layerSources[i].clip = musicEvent.MusicLayers[i];
                    _layerSources[i].Play();
                }
            }
        }
    }
}
