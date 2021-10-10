using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;


public class SoundSystemTester : MonoBehaviour
{
    [SerializeField] MusicEvent _songA;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _songA.Play(2.5f);
        }
    }
}
