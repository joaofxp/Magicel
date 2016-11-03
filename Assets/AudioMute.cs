using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioMute : MonoBehaviour {

    public static AudioMute singleton;

    public Sprite MuteSprite;
    public Sprite UnMuteSprite;

    // Use this for initialization
    void Start () {
        singleton = this;
	}
	
    public void AudioToggle()
    {
        GetComponentInParent<Button>().onClick.Invoke();
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            GetComponent<Image>().sprite = UnMuteSprite;
        } else
        {
            AudioListener.volume = 0;
            GetComponent<Image>().sprite = MuteSprite;
        }
    }
}
