/*
 * Description:             FastUITools.cs
 * Author:                  TONYTANG
 * Create Date:             2019//04/17
 */

using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 快速UI辅助小工具
/// </summary>
public class FastUITools : EditorWindow{

    /// <summary>
    /// 当前滚动位置
    /// </summary>
    private Vector2 mScrollPos = Vector2.zero;

    /// <summary>
    /// 最小宽设置
    /// </summary>
    private GUILayoutOption NormalMinWidth = GUILayout.MinWidth(50.0f);

    /// <summary>
    /// 最小高设置
    /// </summary>
    private GUILayoutOption NormalMinHeight = GUILayout.MinHeight(50.0f);

    [MenuItem("TonyTang/FastUITools", false, 100)]
    public static void ShowFastUITools()
    {
        FastUITools fastuiwindow = (FastUITools)EditorWindow.GetWindow(typeof(FastUITools));
        fastuiwindow.Show();
    }

    private void OnGUI()
    {
        mScrollPos = EditorGUILayout.BeginScrollView(mScrollPos, GUILayout.MaxWidth(400.0f), GUILayout.MaxHeight(400.0f));
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("快速UI工具:");
        displayTonyTangSwitchUI();
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndScrollView();
    }

    /// <summary>
    /// 显示个人开关UI
    /// </summary>
    private void displayTonyTangSwitchUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.EndHorizontal();
    }
}