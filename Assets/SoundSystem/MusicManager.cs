using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundSystem
{
    public class MusicManager : MonoBehaviour
    {
        AudioSource _audioSource;

        private static MusicManager _instance;
        public static MusicManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MusicManager>();
                    if (_instance == null)
                    {
                        GameObject singletonGO = new GameObject("MusicManager _singleton");
                        _instance = singletonGO.AddComponent<MusicManager>();

                        DontDestroyOnLoad(singletonGO);
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
            SetupMusicPlayers();
        }

        void SetupMusicPlayers()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        public void PlayMusic(MusicEvent musicEvent, float fadeTime)
        {
            Debug.Log("Play Music");
            _audioSource.clip = musicEvent.MusicLayers[0];
            _audioSource.Play();
        }


    }
}
