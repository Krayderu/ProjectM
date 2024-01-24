using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector2 mousePositionWorld;
    [SerializeField] GameObject player;
    private void Update()
    {
        MovePlayer();

    }
    public void GetMousePosition()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in screen coordinates
            Vector3 mousePositionScreen = Input.mousePosition;

            // Use the main camera to convert screen position to world position
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, 0));

                // Now you have the world position of the mouse click
                
                Debug.Log("Mouse Clicked at: " + mousePositionWorld);
            }
        }
    }

    public void MovePlayer()
    {
        GetMousePosition();
        var newPlayerPos = new Vector2(mousePositionWorld.x, player.transform.position.y);
        player.transform.SetPositionAndRotation(newPlayerPos, player.transform.rotation);
        
    }
}
