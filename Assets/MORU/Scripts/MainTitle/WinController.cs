using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public float Alpha_speed;
    public Image image;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        Color _color = new Color(0, 0, 0, Alpha_speed);
        yield return null;

        while (image.color.a < 0.99f)
        {
            image.color += _color;
            yield return null;
        }
    }
}
