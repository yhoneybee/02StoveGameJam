using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassControl : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6) return;

        var v = Input.GetAxisRaw("Vertical");

        K.moveableY = v == 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        K.moveableY = true;
    }
}
