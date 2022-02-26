using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHintable
{
    public string TryGetHint();
}

public class HintableObject : BasicObstacle, IHintable
{
    public HintInfo hintInfo;
    public string TryGetHint()
    {
        string result = "";
        if (hintInfo != null)
        {
            result = hintInfo.getHintCommnet;
            K.hintInfos.Add(hintInfo);
            hintInfo = null;
        }
        else
        {
            int rand = Random.Range(1, 11);

            result = rand switch
            {
                int i when i == 1 => "아무것도 없는데?",
                int i when i == 2 => "여기서 뭐해?",
                int i when i == 3 => "으... 더러워",
                int i when i == 4 => "쓰레기잖아...",
                int i when i == 5 => "여기서 시간낭비를 하는거야..?",
                int i when i == 6 => "소리가 너무커...",
                int i when i == 7 => "으... 먼지",
                _ => "아무것도 없어...",
            };
        }
        return result;
    }
}
