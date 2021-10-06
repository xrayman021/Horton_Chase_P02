using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; //Won't be in final build

public class EnemyDesignerWindow : EditorWindow
{
    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }
}
