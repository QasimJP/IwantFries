using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField]
    AudioClip Fries, Sauce, Backing, Olives, cheez, cash;
    [SerializeField]
    AudioSource audioSource, cashAudio;
    

    [SerializeField] private AudioClip[] audioClips;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int i)
    {
        audioSource.PlayOneShot(audioClips[i]);
    }
    public void PlaySoundInstant(AudioClip clip) 
    {
        audioSource.PlayOneShot(clip);
    }
    public void PlayCashSound() 
    {
        cashAudio.PlayOneShot(cash);
    }
}
