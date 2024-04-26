using UnityEngine;

public class Play_Music : MonoBehaviour
{
    public AudioSource musicSource;
    const float startDelay = 1;

    void Start(){
        musicSource.PlayDelayed(startDelay);

    }
}
