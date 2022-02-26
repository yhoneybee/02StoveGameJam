using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BasicObstacle
{

    #region Variables
    [Tooltip("반대편 문")]
    public Door reverseDoor;

    [Tooltip("도착시의 문의 위치")]
    public Transform WarpTransfrom;

    [Tooltip("자신의 맵 위치")]
    public Define.Map targetMap;

    [Tooltip("문의 사용가능 상태")]
    public bool isActive;

    #endregion Variables


    private void Start()
    {
        WarpTransfrom = transform.Find("WarpPoint");
    }


    /// <summary>
    /// 문을 통해 이동시키는 메소드입니다.
    /// </summary>
    /// <param name="target"></param>
    public void OnDoor(Transform target)
    {
        //문이 사용불가상태일 경우 동작하지 않습니다.
        if (!isActive) return;

        if (reverseDoor != null)
        {
            //플레이어가 문에 진입한 경우
            if (target.CompareTag("Player"))
            {
                var obj = FindObjectOfType<BasicGhost>();
                if (obj != null) { 
                    obj.TargetToDoor(this); 
                }
                K.moveable = false;
                //K.CinemachineConfiner.m_BoundingShape2D = null;

                //타겟을 지정한 위치로 이동시킵니다.
                target.position = reverseDoor.WarpTransfrom.position;

                //타겟 오브젝트의 현재 맵 위치를 결정해주기
                MapManager.instance.maps[(int)reverseDoor.targetMap].Setting();

                K.moveable = true;

                //만일 문을 이용시의 시각적 효과를 작업할 경우 이 곳에 추가



                //문을 이용한 횟수를 증가시킵니다.
                GameManager.instance.Del_DoorCountUp();
            }
            //유령이 문에 진입한 경우
            else
            {
                //이동시킨다.
                target.position = reverseDoor.WarpTransfrom.position;
                //해당 유령의 맵을 최신화한다.
                if(target.TryGetComponent<BasicGhost>(out BasicGhost ghost))
                {
                    ghost.cur_Map = reverseDoor.targetMap;
                    ghost.OnDoor();
                }
                Debug.Log("이동됨");
            }
        }



        else
        {
            Debug.Log("문이 할당되지 않았습니다.");
        }





    }


    /// <summary>
    /// 우선 이렇게 기능을 테스트하겠음
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<IDoorable>(out IDoorable doorable))
        {
            OnDoor(collision.transform);
        }
    }

}
