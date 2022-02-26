using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : BasicObstacle, IHideable
{
    #region Ref Variables
    [Tooltip("실제 숨어지는 위치입니다.")]
    [SerializeField] Transform _HiddenPosition;
    #endregion Ref Variables

    #region Interface
    public Transform HiddenPosition { get; set; }
    public Vector3 LastPosition { get; set; }

    public void Hide(Transform target)
    {
        //마지막 플레이어의 좌표를 저장(다시 나올 경우의 스폰장소 결정을 위해)
        LastPosition = target.transform.position;
        //숨는 장소로 플레이어를 이동시킴
        target.transform.position = HiddenPosition.position;

        //플레이어의 숨어짐 처리는 플레이어에서 할 필요가 있습니다.
        //라이트 제어라면 이 곳에서 처리해도 좋습니다.
    }

    public void UnHide(Transform target)
    {
        //마지막으로 플레이어가 위치했던 장소로 플레이어를 이동시킴
        target.transform.position = LastPosition;
        
        //마찬가지로 플레이어의 숨지 않음처리는 플레이어에서 부탁드립니다.
        //라이트 제어는 이곳에서 처리해도 좋습니다.
    }
    #endregion Interface

    protected override void Awake()
    {
        base.Awake();
        HiddenPosition = _HiddenPosition;
    }

}
