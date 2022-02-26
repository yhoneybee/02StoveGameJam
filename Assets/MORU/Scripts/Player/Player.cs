using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingleToneMono<Player>
{
    public Define.State cur_State;

    public PlayerInteraction PI;
    public PlayerMove PM;
}
