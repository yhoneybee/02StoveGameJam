using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BasicObstacle
{
    #region Variables
    [Tooltip("���� Ÿ�� �̵����� �̵� ��ġ")]
    public Transform WarpTransfrom;

    [Tooltip("�̵� ���� �� ��ġ")]
    public Define.Map targetMap;

    [Tooltip("���� ��밡�� ����")]
    public bool isActive;

    #endregion Variables


    public void OnDoor(Transform target)
    {
        //���� ���Ұ������� ��� �������� �ʽ��ϴ�.
        if (!isActive) return;
        
        //Ÿ���� ������ ��ġ�� �̵���ŵ�ϴ�.
        target.position = WarpTransfrom.position;

        //�� ź Ƚ���� ������ŵ�ϴ�.
        GameManager.instance.Del_DoorCountUp();

        //Ÿ�� ������Ʈ�� ���� �� ��ġ�� �������ֱ�
        
    }
}
