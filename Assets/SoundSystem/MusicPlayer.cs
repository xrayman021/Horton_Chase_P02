using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicPlayer : MonoBehaviour
    {
        List<AudioSource> _layerSources = new List<AudioSource>();
        List<float> _sourceStartVolumes = new List<float>();
        MusicEvent _musicEvent = null;
        Coroutine _fadeVolumeRoutine = null;

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

            _musicEvent = musicEvent;

            for(int i = 0; i < _layerSources.Count && (i < musicEvent.MusicLayers.Length); i++)
            {
                if(musicEvent.MusicLayers[i] != null)
                {
                    _layerSources[i].volume = 0;
                    _layerSources[i].clip = musicEvent.MusicLayers[i];
                    _layerSources[i].Play();
                }
            }

            FadeVolume(MusicManager.Instance.Volume, fadeTime);
        }
        public void FadeVolume(float targetVolume, float fadeTime)
        {
            targetVolume = Mathf.Clamp(targetVolume, 0, 1);
            if(fadeTime < 0)
            {
                fadeTime = 0;
            }
            if(_fadeVolumeRoutine != null)
            {
                StopCoroutine(_fadeVolumeRoutine);
            }

            if(_musicEvent.LayerType == LayerType.Additive)
            {
                StartCoroutine(LerpSourceAdditiveRoutine(targetVolume, fadeTime));
            }
            else if (_musicEvent.LayerType == LayerType.Single)
            {
                StartCoroutine(LerpSourceSingleRoutine());
            }
        }

        IEnumerator LerpSourceAdditiveRoutine(float targetVolume, float fadeTime)
        {
            SaveSourceStartVolumes();

            float newVolume;
            float startVolume;
            for (float elapsedTime = 0; elapsedTime <= fadeTime; elapsedTime += Time.deltaTime)
            {
                for (int i = 0; i < _layerSources.Count; i++)
                {
                    startVolume = _sourceStartVolumes[i];
                    newVolume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / fadeTime);
                    _layerSources[i].volume = newVolume;
                }
                yield return null;

            }
        }

        private void SaveSourceStartVolumes()
        {
            _sourceStartVolumes.Clear();
            for (int i = 0; i < _layerSources.Count; i++)
            {
                _sourceStartVolumes.Add(_layerSources[i].volume);
            }
        }

        IEnumerator LerpSourceSingleRoutine()
        {
            yield return null;
        }
    }
}