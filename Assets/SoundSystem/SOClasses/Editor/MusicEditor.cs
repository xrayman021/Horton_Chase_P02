using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace SoundSystem
{
    [CustomEditor(typeof(MusicEvent), true)]
    public class MusicEditor : Editor
    {
        
        

        [SerializeField] private AudioSource _previewer;

        

        public void OnEnable()
        {
            _previewer = EditorUtility.CreateGameObjectWithHideFlags
                ("Audio preview", HideFlags.HideAndDontSave,
                typeof(AudioSource)).GetComponent<AudioSource>();
        }

        private void OnDisable()
        {
            DestroyImmediate(_previewer.gameObject);
        }

        public override void OnInspectorGUI()
        {
            var soundEvent = target as MusicEvent;

            DrawDefaultInspector();

            DrawPreviewButton();
        }

        private void DrawPreviewButton()
        {
            EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);

            GUILayout.Space(20);

            EditorGUI.EndDisabledGroup();
        }
    }
}


