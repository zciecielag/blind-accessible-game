using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float moveSpeed; // predkosc playera
        Rigidbody2D rigb;
    // Start is called before the first frame update
    void Start()
    {
        rigb = GetComponent<Rigidbody2D>(); // namy dostep do rigidbod
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // sprawdzamy gdzie klikamy lewo/prawo
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(touchPos.x < 0)
            {
                rigb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rigb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else // jak niczego nie klikamy to velocity = 0
        {
            rigb.linearVelocity = Vector2.zero; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Falling_Object")
        {
            SceneManager.LoadScene(sceneName: "PrototypeSelection");
        }
    }
}
