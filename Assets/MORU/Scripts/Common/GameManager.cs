using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleToneMono<GameManager>
{


    #region Score/Delegate_Variables

    private int onDoorCount = 0;
    public int OnDoorCount => onDoorCount;

    public delegate void DoorCountUp();
    public DoorCountUp Del_DoorCountUp;




    #endregion Score/Delegate_Variables

    protected override void Awake()
    {
        base.Awake();
        Init_Delegate();
    }

    void Init_Delegate()
    {
        Del_DoorCountUp = () => onDoorCount++;
    }
}
