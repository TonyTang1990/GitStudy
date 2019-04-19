/*
 * Description:             UINodeEditor.cs
 * Author:                  TONYTANG
 * Create Date:             2018/12/23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// UINodeEditor.cs
/// UINode.cs的自定义Editor显示
/// </summary>
[CustomEditor(typeof(UINode))]
public class UINodeEditor : Editor {

    /// <summary>
    /// Node描述节点
    /// </summary>
    SerializedProperty mNodeDes;

    private void OnEnable()
    {
        mNodeDes = serializedObject.FindProperty("NodeDes");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(mNodeDes, GUILayout.MinWidth(100.0f));

        serializedObject.ApplyModifiedProperties();
    }
}