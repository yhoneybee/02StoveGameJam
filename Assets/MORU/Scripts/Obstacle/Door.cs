using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BasicObstacle
{
    #region Variables
    [Tooltip("문을 타고 이동시의 이동 위치")]
    public Transform WarpTransfrom;

    [Tooltip("이동 후의 맵 위치")]
    public Define.Map targetMap;

    [Tooltip("문의 사용가능 상태")]
    public bool isActive;

    #endregion Variables


    public void OnDoor(Transform target)
    {
        //문이 사용불가상태일 경우 동작하지 않습니다.
        if (!isActive) return;
        
        //타겟을 지정한 위치로 이동시킵니다.
        target.position = WarpTransfrom.position;

        //문 탄 횟수를 증가시킵니다.
        GameManager.instance.Del_DoorCountUp();

        //타겟 오브젝트의 현재 맵 위치를 결정해주기
        
    }
}
