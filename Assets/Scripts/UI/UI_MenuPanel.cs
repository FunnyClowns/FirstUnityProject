using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuPanel : MonoBehaviour
{
    [SerializeField] GameObject m_MenuPanel;
    [SerializeField] GameObject m_SelectLevel_Panel;
    [SerializeField] UI_MenuCanvas MenuCanvas;

    /// <summary>
    /// Called directly by the quit button in the UI prefab
    /// </summary>
    public void OnClickPlayButton(){
        MenuCanvas.StartCoroutine("SwitchPanel");
    }

    /// <summary>
    /// Called directly by the quit button in the UI prefab
    /// </summary>
    public void OnClickQuitButton(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();

        #endif
    }
}
