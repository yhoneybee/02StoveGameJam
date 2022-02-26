using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ش� �������̽��� ��ӹ޴� Ŭ������ �÷��̾ ���� �� �ְ� �˴ϴ�.
/// </summary>
public interface IHideable
{
    public Transform transform { get; }
    /// <summary>
    /// ���� ��ġ��ǥ�� �����մϴ�.
    /// </summary>
    public Transform HiddenPosition { get; set; }
    /// <summary>
    /// �������� ���⸦ �õ��ߴ� ��ġ��ǥ�Դϴ�.
    /// </summary>
    public Vector3 LastPosition { get; set; }

    /// <summary>
    /// target�� �ش� �������̽��� ���Ե� hiddenPosition �ʵ忡 ����ϴ�.
    /// </summary>
    /// <param name="target"></param>
    public void Hide(Transform target);

    /// <summary>
    /// target�� �ش� �������̽��� ���Ե� hiddenPosition �ʵ�κ��� �巯���ϴ�.
    /// </summary>
    /// <param name="target"></param>
    public void UnHide(Transform target);

}
