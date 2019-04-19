/*
 * Description:             UIInterface.cs
 * Author:                  TONYTANG
 * Create Date:             2018/12/23
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIInterface.cs
/// UI挂载统一获取框架
/// </summary>
public class UIInterface : MonoBehaviour {

    /// <summary>
    /// 挂载的UI节点
    /// </summary>
    public UIInterface[] UINodes;

    /// <summary>
    /// 节点描述
    /// </summary>
    public string NodeDes;

    /// <summary>
    /// 获取指定UIInterface索引指定组件类型的组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="index"></param>
    /// <returns></returns>
    public T getUIInterfaceComponent<T>(int index) where T : Component
    {
        if (UINodes != null)
        {
            if (index < UINodes.Length)
            {
                return UINodes[index].GetComponent<T>();
            }
            else
            {
                Debug.LogError(string.Format("超过了UIInterface挂载的最大数量 : {0}，获取index : {1}失败!", UINodes.Length, index));
                return null;
            }
        }
        else
        {
            Debug.LogError(string.Format("没有有效的UINodes!获取指定节点 : {0} 组件失败!", index));
            return null;
        }
    }
}