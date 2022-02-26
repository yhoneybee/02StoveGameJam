using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleToneMono<GameManager>
{
    ///게임매니저에서 최초 인게임 진입 시 랜덤적으로 선택될 요소들을 결정한다
    ///어떤 랜덤요소들이 있을지는 모르겠음



    /// <summary>
    /// 추후 스코어 관리를 위한 변수와 델리게이트 목록입니다.
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
    /// 델리게이트 생성
    /// </summary>
    void Init_Delegate()
    {
        Del_DoorCountUp = () => onDoorCount++;
        Del_HiddenCountUp = () => onHiddenCout++;
    }
    #endregion Helper Methods
}
