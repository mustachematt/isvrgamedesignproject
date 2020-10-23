using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompingSoundEffect : MonoBehaviour
{
    public AudioClip stomp1;
    public AudioClip stomp2;
    AudioSource source;
    Velocity monsterSpeed;
    public int waitFrames;
    int currentFrames = 0;
    public float pitchRange;

    void Start()
    {
        source = GetComponent<AudioSource>();
        monsterSpeed = GetComponent<Velocity>();
        currentFrames = waitFrames;
    }

    void Update()
    {
        if (currentFrames > 0)
        {
            currentFrames--;
        }
        if (currentFrames <= 0)
        {
            if (monsterSpeed.speed > 1)
            {
                //int rand = (Random.Range(1, 3));
                float randPitch = (Random.Range(1.0f - pitchRange, 1.0f + pitchRange));
                source.pitch = randPitch;
                //if (rand == 1)
                //{
                source.PlayOneShot(stomp1, 0.5f);
                //}
                //else if (rand == 2)
                //{
                //    source.PlayOneShot(stomp2, 0.5f);
                //}
                currentFrames = waitFrames;
            }
        }
    }
    


}
