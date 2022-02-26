using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toilet_Graphic : MonoBehaviour
{
    public ToiletGhost to_ghost;

    public void EndOfFrame()
    {
        to_ghost.EndOfFrame();
    }

}
