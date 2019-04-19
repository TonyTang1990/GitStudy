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
/// UINode.cs���Զ���Editor��ʾ
/// </summary>
[CustomEditor(typeof(UINode))]
public class UINodeEditor : Editor {

    /// <summary>
    /// Node�����ڵ�
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