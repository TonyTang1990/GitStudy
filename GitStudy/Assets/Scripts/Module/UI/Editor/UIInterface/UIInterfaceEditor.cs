/*
 * Description:             UIInterfaceEditor.cs
 * Author:                  TONYTANG
 * Create Date:             2018/12/23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// UIInterfaceEditor.cs
/// UIInterface.cs自定义编辑器显示
/// </summary>
[CustomEditor(typeof(UIInterface))]
public class UIInterfaceEditor : Editor {

    /// <summary>
    /// Node描述节点
    /// </summary>
    SerializedProperty mUINodes;

    /// <summary>
    /// Node描述节点
    /// </summary>
    SerializedProperty mNodeDes;

    /// <summary>
    /// 是否在移除节点
    /// </summary>
    private bool mIsRemovingNode;

    /// <summary>
    /// 需要移除的节点索引
    /// </summary>
    private int mRemovedIndex;

    private void OnEnable()
    {
        mUINodes = serializedObject.FindProperty("UINodes");

        mNodeDes = serializedObject.FindProperty("NodeDes");

        mIsRemovingNode = false;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        displayUINodes();
        displayUIInteraction();
        displayUINodeDes();

        serializedObject.ApplyModifiedProperties();
    }

    /// <summary>
    /// 显示所有UI Node Editor节点
    /// </summary>
    private void displayUINodes()
    {
        EditorGUILayout.BeginVertical();
        var uinodessize = mUINodes.arraySize;
        for (int i = 0; i < uinodessize; i++)
        {
            var uinode = mUINodes.GetArrayElementAtIndex(i);
            displayUINode(i + 1, uinode);
        }
        //节点显示遍历完成后再删除
        if(mIsRemovingNode)
        {
            mIsRemovingNode = false;
            var uinode = mUINodes.GetArrayElementAtIndex(mRemovedIndex);
            //第一次是为了移除引用对象
            if (uinode.objectReferenceValue != null)
            {
                mUINodes.DeleteArrayElementAtIndex(mRemovedIndex);
            }
            //第二次是为了真正移除节点
            mUINodes.DeleteArrayElementAtIndex(mRemovedIndex);
        }
        EditorGUILayout.EndVertical();
    }

    /// <summary>
    /// 显示可交互部分
    /// </summary>
    private void displayUIInteraction()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MinWidth(380.0f));
        if (GUILayout.Button("添加", GUILayout.MinWidth(380.0f)))
        {
            mUINodes.InsertArrayElementAtIndex(mUINodes.arraySize);
            var newuinode = mUINodes.GetArrayElementAtIndex(mUINodes.arraySize - 1);
            newuinode.objectReferenceValue = new UINode();
            mUINodes.serializedObject.SetIsDifferentCacheDirty();
        }
        EditorGUILayout.EndHorizontal();
    }

    /// <summary>
    /// 显示节点描述
    /// </summary>
    private void displayUINodeDes()
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MinWidth(380.0f));
        EditorGUILayout.PropertyField(mNodeDes, GUILayout.MinWidth(100.0f));
        EditorGUILayout.EndHorizontal();
    }

    /// <summary>
    /// 显示一个UI Node Editor节点
    /// </summary>
    /// <param name="index"></param>
    /// <param name="uinode"></param>
    private void displayUINode(int index, SerializedProperty uinode)
    {
        EditorGUILayout.BeginHorizontal(GUILayout.MinWidth(380.0f));
        EditorGUILayout.LabelField(index.ToString(), GUILayout.Width(30.0f));
        EditorGUILayout.PropertyField(uinode, GUIContent.none, GUILayout.MinWidth(200.0f));
        if(uinode.objectReferenceValue != null)
        {
            var uinodeso = new SerializedObject(uinode.objectReferenceValue);
            var uinodedes = uinodeso.FindProperty("NodeDes");
            EditorGUILayout.LabelField(uinodedes.stringValue, GUILayout.MinWidth(100.0f));
        }
        if (GUILayout.Button("移除", GUILayout.Width(50.0f)))
        {
            mIsRemovingNode = true;
            mRemovedIndex = index - 1;
        }
        EditorGUILayout.EndHorizontal();
    }
}