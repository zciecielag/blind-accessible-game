using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5f) // je¿eliblok jest po za ekranem to wtedy zniszcz
        {
            Destroy(gameObject);
        }
    }
}
