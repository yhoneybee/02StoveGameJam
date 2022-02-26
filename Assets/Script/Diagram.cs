using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Diagram : MonoBehaviour
{
    public Image imgDiagram;
    public TextMeshProUGUI txtDiagram;

    void Start()
    {
        K.diagram = this;
        //Chatting(Color.black, "ㅇ라어아러아러알어ㅏ러ㅏㅇ러아러ㅏA", "살려줘살려줘살려줘살려줘살려줘살려줘살려줘살려줘", "응애응애응애응애");
    }

    public void Chatting(Color color, params string[] chat)
    {
        StopAllCoroutines();
        StartCoroutine(EChatting(color, chat));
    }

    private IEnumerator EChatting(Color color, string[] chats)
    {
        var wait = new WaitForSeconds(0.1f);

        yield return EAlpha(1);

        K.moveable = false;
        K.camable = false;

        txtDiagram.color = color;

        for (int i = 0; i < chats.Length; i++)
        {
            for (int j = 0; j <= chats[i].Length; j++)
            {
                txtDiagram.text = chats[i].Substring(0, j);
                yield return wait;
            }
            yield return new WaitForSeconds(2);
        }

        txtDiagram.text = "";

        K.moveable = true;
        K.camable = true;

        yield return EAlpha(0);
    }

    private IEnumerator EAlpha(float value)
    {
        var wait = new WaitForSeconds(0.01f);

        while (Mathf.Abs(imgDiagram.color.a - value) > 0.01f)
        {
            imgDiagram.color = new Color(imgDiagram.color.r, imgDiagram.color.g, imgDiagram.color.b, Mathf.MoveTowards(imgDiagram.color.a, value, .1f));
            yield return wait;
        }

        yield return null;
    }
}
