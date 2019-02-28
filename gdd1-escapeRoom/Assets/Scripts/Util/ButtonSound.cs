using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    public AudioClip SoundOnClick;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource sourceOnClick { get { return GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();

        sourceOnClick.clip = SoundOnClick;
        sourceOnClick.playOnAwake = false;

        button.onClick.AddListener(() => onClickPlay());
    }


    void onClickPlay()
    {
        sourceOnClick.PlayOneShot(SoundOnClick);
    }

}
