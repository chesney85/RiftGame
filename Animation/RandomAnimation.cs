using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class RandomAnimation : MonoBehaviour
{
    private Animator animator;
    private AudioSource source;
    public List<string> anims;
    public List<AudioClip> clips;
    void Start()
    {
       animator = GetComponent<Animator>();
       source = GetComponent<AudioSource>();
       InvokeRepeating("DelayMethod",0.1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    bool AnimatorIsPlaying(){
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    void DelayMethod()
    {
        if (AnimatorIsPlaying())
        {
            return;
        }

        int index = Random.Range(0, anims.Count);
        animator.Play(anims[index]);
        source.PlayOneShot(clips[index]);
    }

}
