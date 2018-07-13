using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EngineSoundScript : MonoBehaviour
{
    public AudioSource audioSourceIntro;
    public AudioSource audioSourceLoop;
    private bool stoppedAll = false;


    void Start()
    {
        stoppedAll = false;
        audioSourceIntro.Play();
        StartCoroutine(DelaySoundStop(audioSourceIntro.clip.length));
    }
    

    IEnumerator DelaySoundStop(float timeEnd)
    {
        yield return new WaitForSeconds(timeEnd);
        if(!stoppedAll)
        {
            audioSourceLoop.Play();
        }
    }

    public void stopAll()
    {
        stoppedAll = true;
        audioSourceIntro.Stop();
        audioSourceLoop.Stop();
    }
}
