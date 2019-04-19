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
/// UI����ͳһ��ȡ���
/// </summary>
public class UIInterface : MonoBehaviour {

    /// <summary>
    /// ���ص�UI�ڵ�
    /// </summary>
    public UIInterface[] UINodes;

    /// <summary>
    /// �ڵ�����
    /// </summary>
    public string NodeDes;

    /// <summary>
    /// ��ȡָ��UIInterface����ָ��������͵����
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
                Debug.LogError(string.Format("������UIInterface���ص�������� : {0}����ȡindex : {1}ʧ��!", UINodes.Length, index));
                return null;
            }
        }
        else
        {
            Debug.LogError(string.Format("û����Ч��UINodes!��ȡָ���ڵ� : {0} ���ʧ��!", index));
            return null;
        }
    }
}