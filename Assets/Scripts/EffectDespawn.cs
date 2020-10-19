using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawn : MonoBehaviour
{
    public AudioClip destroySound1;
    public AudioClip destroySound2;
    AudioSource destructionSounds;
    public float pitchRange;

    public float despawnTime;

    void Start()
    {
        destructionSounds = GetComponent<AudioSource>();

        float randPitch = (Random.Range(1.0f - pitchRange, 1.0f + pitchRange));
        destructionSounds.pitch = randPitch;

        int rubbleSoundChance = Random.Range(1, 3);

        if (rubbleSoundChance == 1)
            destructionSounds.PlayOneShot(destroySound1, 0.7F);
        if (rubbleSoundChance == 2)
            destructionSounds.PlayOneShot(destroySound2, 0.7F);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RemoveEffect());
    }

    IEnumerator RemoveEffect()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(gameObject);
    }
}
