using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //LOCK cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
        //HIDE cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
