using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private bool leftSidePressed = false;
    private bool rightSidePressed = false;
    public bool leftRightPressed
    
    {
        get { return leftSidePressed && rightSidePressed; }
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
          
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) // czy naciœniêto/naciœnieto i gracz rusza palcem
                {
                    if (touch.position.x < Screen.width/2) // czy dotknieto z lewej
                    {
                        leftSidePressed = true;
                    }
                    else 
                    {
                        rightSidePressed = true; // czy dotkniêto  z prawej
                    }
                }
                // musimy sprawdziæ czy przyciski s¹ dalej przyciœniête
                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    if (touch.position.x < Screen.width/2)
                    {
                        leftSidePressed = false;
                    }
                    else
                    {
                        rightSidePressed = false;
                    }
                }
            }
        }
    }
}
