using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public void changeText(string text){
        textMesh.text = text;
    }
}
