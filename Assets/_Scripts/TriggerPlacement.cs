using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class TriggerPlacement : MonoBehaviour
{
    public GameObject gameManagerObject;
    public ParticleSystem particle;
    public AudioSource clickAudioSource;
    public AudioSource positiveAudioSource;
    public float duration = 0.5f;

    public GameObject[] parts;

    private void OnTriggerEnter(Collider other)
    {
        print("Triggered by " + other.transform.name);

        gameManagerObject.GetComponent<PlaceARObjectOnHand>().arObject = null;
        other.transform.parent = transform;
        other.GetComponent<BoxCollider>().isTrigger = false;
        particle.Play();
        clickAudioSource.PlayOneShot(clickAudioSource.clip, 1f);
        positiveAudioSource.PlayOneShot(positiveAudioSource.clip, 1f);

        if (other.transform.name == parts[0].name)  // motherboard
        {
            Tween.LocalPosition(other.transform, new Vector3(1.0248f, -11.0312f, 211201f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            StartCoroutine(AttachNewObjectToHand(1));
            
        }
        else if (other.transform.name == parts[1].name) // cpu
        {
            Tween.LocalPosition(other.transform, new Vector3(0.9224068f, -10.48776f, -1.356764f), duration, 0f);
            Tween.LocalRotation(other.transform, new Vector3(90, 0, 0), duration, 0f);
            StartCoroutine(AttachNewObjectToHand(2));
        }
        else if (other.transform.name == parts[2].name) // m2
        {
            Tween.LocalPosition(other.transform, new Vector3(1.055724f, -11.13056f, -1.313646f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            StartCoroutine(AttachNewObjectToHand(3));
        }
        else if (other.transform.name == parts[3].name) // rtx3080
        {
            Tween.LocalPosition(other.transform, new Vector3(0.938f, -11.1488f, -0.8209801f), duration, 0f);
            Tween.LocalRotation(other.transform, new Vector3(90f, 0, 0), duration, 0f);
            StartCoroutine(AttachNewObjectToHand(4));
        }
        else if (other.transform.name == parts[4].name) // ram
        {
            Tween.LocalPosition(other.transform, new Vector3(0.4495568f, -10.48165f, -1.154988f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            StartCoroutine(AttachNewObjectToHand(5));
        }
        else if (other.transform.name == parts[5].name) // side panel
        {
            Tween.LocalPosition(other.transform, new Vector3(-1.560937f, -13.55139f, 0.4832139f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
        }

    }

    IEnumerator AttachNewObjectToHand(int objectNum)
    {
        yield return new WaitForSeconds(2);
        gameManagerObject.GetComponent<PlaceARObjectOnHand>().arObject = parts[objectNum];
    }
}
