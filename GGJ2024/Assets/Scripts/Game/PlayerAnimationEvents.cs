using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(int clipToPlay)
    {
        source.PlayOneShot(clip[clipToPlay]);
    }
}
