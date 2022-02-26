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

    [Tooltip("�̵� ���� �� ��ġ")]
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

        //Ÿ���� ������ ��ġ�� �̵���ŵ�ϴ�.
        if (reverseDoor != null)
        { 
            target.position = reverseDoor.WarpTransfrom.position;
        }
        else
        {
            Debug.Log("���� �Ҵ���� �ʾҽ��ϴ�.");
        }

        //���� �̿��� Ƚ���� ������ŵ�ϴ�.
        GameManager.instance.Del_DoorCountUp();


        //���� ���� �̿���� �ð��� ȿ���� �۾��� ��� �� ���� �߰�
        //Ÿ�� ������Ʈ�� ���� �� ��ġ�� �������ֱ�

    }


    /// <summary>
    /// �켱 �̷��� ����� �׽�Ʈ�ϰ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<IDoorable>(out IDoorable doorable))
        {
            OnDoor(collision.transform);
        }
    }

}
