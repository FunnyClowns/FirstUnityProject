using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MuteController : MonoBehaviour, IPointerClickHandler
{

    // Images
    [SerializeField]
    private RawImage ButtonRImage;

    [SerializeField]
    private Texture2D AudioMute_Image;

    [SerializeField]
    private Texture2D AudioUnmute_Image;

    // Audio

    [SerializeField]
    private AudioSource gameplayMusic;


    bool isMuted;
    bool isButtonClicked = false;

    public void OnPointerClick(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left && !isButtonClicked){
            isButtonClicked = true;

            if (isMuted){
                isMuted = false;
                Debug.Log("Audio unmute");
                SetAudioUnmute();
                ChangesButtonImage(AudioUnmute_Image);

            } else {
                isMuted = true;
                Debug.Log("Audio mute");
                SetAudioMute();
                ChangesButtonImage(AudioMute_Image);

            }
            

            StartCoroutine(CountdownForNextClick());
            IEnumerator CountdownForNextClick(){
                yield return new WaitForSeconds(0.5f);
                isButtonClicked = false;

            }

        }
    }

    void SetAudioMute(){
        gameplayMusic.mute = true;

    }

    void SetAudioUnmute(){
        gameplayMusic.mute = false;

    }

    void ChangesButtonImage(Texture2D image){
        ButtonRImage.texture = image;

    }
}
