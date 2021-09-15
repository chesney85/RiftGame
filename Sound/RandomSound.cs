using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSound : MonoBehaviour
{
    public AudioClip[] sounds;
    public int minRepeatTime, maxRepeatTime;
    public float waitTime;
    private AudioSource src;
    private bool playing;

    private void Start()
    {
        src = GetComponent<AudioSource>();
        InvokeRepeating("SoundStart", 0.1f, Random.Range(minRepeatTime,maxRepeatTime));
    }

    void SoundStart()
    {
        if (!playing)
            StartCoroutine(SoundPlay());
    }

    IEnumerator SoundPlay()
    {
        playing = true;
        src.PlayOneShot(sounds[Random.Range(0,sounds.Length-1)]);
        yield return new WaitForSeconds(waitTime);
        playing = false;
    }
}
