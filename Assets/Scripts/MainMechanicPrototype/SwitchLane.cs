using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLane : MonoBehaviour
{
    public bool leftOrRight;
    public AudioSource failureSound;
    public AudioSource switchLaneSound;

    public GameObject character;
    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
    private bool doubleTouch = false;

    private float touchDelay = 0.2f;
    private float lastMove = -Mathf.Infinity;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && Time.time >= lastMove)
            {
                StartCoroutine(WaitForDoubleTouch(touch));
            }
        }
    }
    private IEnumerator WaitForDoubleTouch(Touch initialTouch)
    {
        doubleTouch = true;
        yield return new WaitForSeconds(touchDelay);

        if(Input.touchCount > 1) 
        { 
        }
        else
        {
            float screenWidth = Screen.width;
            if(initialTouch.position.x < screenWidth/2)
            {
                SwitchToLeftLine();
            } 
            else
            {
                SwitchToRightLine();
            }
        }
        doubleTouch = false;
        lastMove = Time.time;
    }

    private void SwitchToLeftLine()
    {
        if (character.transform.position.x == -4.8f)
        {
            Debug.Log("Can't move further left");
            failureSound.Play();
        }
        else
        {
            switchLaneSound.Play();

            character.transform.position = new Vector3(-4.8f, -3.92f, 1f * Time.deltaTime);
        }
    }

    private void SwitchToRightLine()
    {
        if (character.transform.position.x == 5.1f)
        {
            Debug.Log("Can't move further right");
            failureSound.Play();
        }
        else
        {
            switchLaneSound.Play();

            character.transform.position = new Vector3(5.1f, -3.92f, 1f * Time.deltaTime);
        }
    }
}
