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

    private AudioSource gameplayMusicSource;
    
    [SerializeField] AudioClip music;


    bool isMuted;
    bool isButtonClicked = false;

    void Awake(){
        SetMusicSource();
    }

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
        if(gameplayMusicSource){
            gameplayMusicSource.mute = true;
        } else {
            Debug.LogWarning("Null getting references");
        }

    }

    void SetAudioUnmute(){
        if(gameplayMusicSource){
            gameplayMusicSource.mute = false;
        } else {
            Debug.LogWarning("Null getting references");
        }

    }

    void ChangesButtonImage(Texture2D image){
        ButtonRImage.texture = image;

    }

    void SetMusicSource(){
        GameObject musicObj = GameObject.FindGameObjectWithTag("Music");

        if (musicObj)
        {
            musicObj.TryGetComponent<AudioSource>(out gameplayMusicSource);
            
        } else {

            // overcome problems when music gameobject is not detected
            gameplayMusicSource = this.gameObject.AddComponent<AudioSource>();

            gameplayMusicSource.clip = music;
            gameplayMusicSource.loop = true;
            gameplayMusicSource.playOnAwake = false;

            gameplayMusicSource.PlayDelayed(1f);
        }
    }

}
