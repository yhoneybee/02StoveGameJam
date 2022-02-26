using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "HintInfo", menuName = "Info/HintInfo", order = 0)]
public class HintInfo : ScriptableObject
{
    [TextArea(3, 5)]
    public string getHintCommnet;
    [TextArea(3, 5)]
    public string hintCommnet;
}
