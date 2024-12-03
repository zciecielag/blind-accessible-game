using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using Unity.Cinemachine;

public class TreflikVoice : MonoBehaviour
{
    //public AudioSource telephone;
    public AudioSource startGame;
    public static float time = 4f;

    private void Start()
    {
        //InvokeRepeating("PlaySound", 0.001f, time);
    }
    void PlaySound()
    {
        //telephone.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            startGame.Play();
        }
    }
}
