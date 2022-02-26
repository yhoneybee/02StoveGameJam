using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �� �� ��ġ�Ǿ��ִ� ��� �繰 ������Ʈ�� �θ�Ŭ�����Դϴ�.
/// </summary>
public class BasicObstacle : MonoBehaviour
{
    #region Ref Variables

    Collider2D _collider;
    /// <summary>
    /// �ش� ������Ʈ�� �ݶ��̴��� �����մϴ�.
    /// </summary>
    [HideInInspector] public Collider2D GetCollider2D
    {
        get
        {
            if (_collider == null) _collider = GetComponent<Collider2D>();
            return _collider;
        }
    }

    #endregion Ref Variables

    #region CallBack Methods
    protected virtual void Awake()
    {
        
    }
    #endregion CallBack Methods



    #region Abstract Methods

    /// <summary>
    /// ���콺 ���� ��� �����Ϳ� �ݶ��̴� ���� ��
    /// </summary>
    public virtual void OnPointerEnter() { }
    /// <summary>
    /// ���콺 ���� ��� �����Ϳ� �ݶ��̴� Ż�� ��
    /// </summary>
    public virtual void OnPointerExit() { }

    #endregion Abstract Methods

}
