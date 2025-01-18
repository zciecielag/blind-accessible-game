using UnityEngine;

public class ObjectsScrolling : MonoBehaviour
{
    public float tempo;

    void Start()
    {
        tempo = tempo / 60f;
    }

    void Update()
    {
        if (GameController.Instance.gameStarted)
        {
            transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
        }
    }
}
