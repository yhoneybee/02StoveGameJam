using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 해당 인터페이스를 상속받는 클래스는 플레이어가 숨을 수 있게 됩니다.
/// </summary>
public interface IHideable
{
    public Transform transform { get; }
    /// <summary>
    /// 숨을 위치좌표를 결정합니다.
    /// </summary>
    public Transform HiddenPosition { get; set; }
    /// <summary>
    /// 마지막에 숨기를 시도했던 위치좌표입니다.
    /// </summary>
    public Vector3 LastPosition { get; set; }

    /// <summary>
    /// target을 해당 인터페이스에 포함된 hiddenPosition 필드에 숨깁니다.
    /// </summary>
    /// <param name="target"></param>
    public void Hide(Transform target);

    /// <summary>
    /// target을 해당 인터페이스에 포함된 hiddenPosition 필드로부터 드러냅니다.
    /// </summary>
    /// <param name="target"></param>
    public void UnHide(Transform target);

}
