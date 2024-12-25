using UnityEngine;

public class PlaySoundOnCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
