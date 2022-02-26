using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleToneMono<GameManager>
{
    ///���ӸŴ������� ���� �ΰ��� ���� �� ���������� ���õ� ��ҵ��� �����Ѵ�
    ///� ������ҵ��� �������� �𸣰���



    /// <summary>
    /// ���� ���ھ� ������ ���� ������ ��������Ʈ ����Դϴ�.
    /// </summary>
    #region Score/Delegate_Variables

    private int onDoorCount = 0;
    public int OnDoorCount => onDoorCount;

    public delegate void DoorCountUp();
    public DoorCountUp Del_DoorCountUp;


    private int onHiddenCout = 0;
    public int OnHiddenCout => onHiddenCout;

    public delegate void HiddenCountUp();
    public HiddenCountUp Del_HiddenCountUp;


    #endregion Score/Delegate_Variables

    protected override void Awake()
    {
        base.Awake();
        Init_Delegate();
    }

    #region Helper Methods

    /// <summary>
    /// ��������Ʈ ����
    /// </summary>
    void Init_Delegate()
    {
        Del_DoorCountUp = () => onDoorCount++;
        Del_HiddenCountUp = () => onHiddenCout++;
    }
    #endregion Helper Methods
}
