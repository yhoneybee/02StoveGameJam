using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BasicObstacle
{

    #region Variables
    [Tooltip("�ݴ��� ��")]
    public Door reverseDoor;

    [Tooltip("�������� ���� ��ġ")]
    public Transform WarpTransfrom;

    [Tooltip("�ڽ��� �� ��ġ")]
    public Define.Map targetMap;

    [Tooltip("���� ��밡�� ����")]
    public bool isActive;

    #endregion Variables


    private void Start()
    {
        WarpTransfrom = transform.Find("WarpPoint");
    }


    /// <summary>
    /// ���� ���� �̵���Ű�� �޼ҵ��Դϴ�.
    /// </summary>
    /// <param name="target"></param>
    public void OnDoor(Transform target)
    {
        //���� ���Ұ������� ��� �������� �ʽ��ϴ�.
        if (!isActive) return;

        if (reverseDoor != null)
        {
            //�÷��̾ ���� ������ ���
            if (target.CompareTag("Player"))
            {
                var obj = FindObjectOfType<BasicGhost>();
                if (obj != null) { 
                    obj.TargetToDoor(this); 
                }
                K.moveable = false;
                //K.CinemachineConfiner.m_BoundingShape2D = null;

                //Ÿ���� ������ ��ġ�� �̵���ŵ�ϴ�.
                target.position = reverseDoor.WarpTransfrom.position;

                //Ÿ�� ������Ʈ�� ���� �� ��ġ�� �������ֱ�
                MapManager.instance.maps[(int)reverseDoor.targetMap].Setting();

                K.moveable = true;

                //���� ���� �̿���� �ð��� ȿ���� �۾��� ��� �� ���� �߰�



                //���� �̿��� Ƚ���� ������ŵ�ϴ�.
                GameManager.instance.Del_DoorCountUp();
            }
            //������ ���� ������ ���
            else
            {
                //�̵���Ų��.
                target.position = reverseDoor.WarpTransfrom.position;
                //�ش� ������ ���� �ֽ�ȭ�Ѵ�.
                if(target.TryGetComponent<BasicGhost>(out BasicGhost ghost))
                {
                    ghost.cur_Map = reverseDoor.targetMap;
                    ghost.OnDoor();
                }
                Debug.Log("�̵���");
            }
        }



        else
        {
            Debug.Log("���� �Ҵ���� �ʾҽ��ϴ�.");
        }





    }


    /// <summary>
    /// �켱 �̷��� ����� �׽�Ʈ�ϰ���
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
