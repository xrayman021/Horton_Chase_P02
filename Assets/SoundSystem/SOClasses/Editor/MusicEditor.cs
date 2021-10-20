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
        [MenuItem("Window/Music Event")]
        public static void ShowWindow()
        {
            GetWindow<MusicEditor>("MusicEditor");
        }

        private static void GetWindow<T>(string v)
        {
            throw new NotImplementedException();
        }

        [SerializeField] private AudioSource _previewer;

        private void OnGUI()
        {
            GUILayout.Label("This is a label.", EditorStyles.boldLabel);
        }

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

            if (GUILayout.Button("Preview"))
            {
                ((MusicEvent)target).Preview(_previewer);
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}


