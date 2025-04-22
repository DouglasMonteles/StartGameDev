using UnityEngine;

public class ActorSFX : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

}
