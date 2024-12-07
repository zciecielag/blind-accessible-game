using UnityEngine;

public class PlaySoundOnCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
