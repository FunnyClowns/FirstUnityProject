using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuCanvas : MonoBehaviour
{

    [SerializeField] GameObject m_MenuPanel;
    [SerializeField] GameObject m_LevelSelection_Panel;
    [SerializeField] CameraSwitcher cameraSwitcher;

    bool canSwitch = true;


    void Awake(){
        // Activate and Hide panels at startup (common mistakes when i forgot to active or deactivate some panels) :v
        ManageActivePanel();
    }

    void ManageActivePanel(){
        m_MenuPanel.SetActive(true);
        m_LevelSelection_Panel.SetActive(false);
    }

    public IEnumerator SwitchPanel(){

        if(canSwitch){

            Debug.Log("Switched panel");

            canSwitch = false;

            m_MenuPanel.SetActive(!m_MenuPanel.activeSelf);
            m_LevelSelection_Panel.SetActive(!m_LevelSelection_Panel.activeSelf);

            cameraSwitcher.SwitchState();
        }

        yield return new WaitForSeconds(1f);

        canSwitch = true;

    }

}
