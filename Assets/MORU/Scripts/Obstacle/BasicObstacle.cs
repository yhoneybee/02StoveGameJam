using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 맵 상에 위치되어있는 모든 사물 오브젝트의 부모클래스입니다.
/// </summary>
public class BasicObstacle : MonoBehaviour
{
    #region Ref Variables

    Collider2D _collider;
    /// <summary>
    /// 해당 오브젝트의 콜라이더를 참조합니다.
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
    /// 마우스 레이 결과 포인터에 콜라이더 진입 시
    /// </summary>
    public virtual void OnPointerEnter() { }
    /// <summary>
    /// 마우스 레이 결과 포인터에 콜라이더 탈출 시
    /// </summary>
    public virtual void OnPointerExit() { }

    #endregion Abstract Methods

}
