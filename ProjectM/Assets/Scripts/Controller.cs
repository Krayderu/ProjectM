using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float maxSpeed = 5f; //Vitesse maximum de déplacement du joueur
    public bool facingLeft = false;

    public Vector2 lastPos;
    public Vector2 newPlayerPos;
    public Vector2 playerPos;
    public Vector2 mousePositionWorld;
    
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;
    

    private void Start()
    {
        lastPos = player.transform.position;
        newPlayerPos = player.transform.position;
    }

    private void Update()
    {
        MovePlayer();

    }
    public void GetMousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePositionScreen = Input.mousePosition; // Get the mouse position in screen coordinates
            Camera mainCamera = Camera.main; // Use the main camera to convert screen position to world position
            if (mainCamera != null)
            {
                mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, 0));
                Debug.Log("Mouse Clicked at: " + mousePositionWorld);  // Now you have the world position of the mouse click
            }
        }
    }

    public void MovePlayer()
    {
        
        lastPos = player.transform.position;
        GetMousePosition();
        newPlayerPos = new Vector2(mousePositionWorld.x, player.transform.position.y);
        player.transform.position = Vector2.MoveTowards(player.transform.position, newPlayerPos, maxSpeed * Time.deltaTime);

        if (newPlayerPos != lastPos)
        {
            animator.SetBool("isWalking", true);
            //Flips Sprite
            if (newPlayerPos.x > lastPos.x && facingLeft)
            {

                sprite.flipX = false;
                facingLeft = false;
            }
            else if (newPlayerPos.x < lastPos.x && !facingLeft)
            {
                sprite.flipX = true;
                facingLeft = true;
            }
        }else if( newPlayerPos == lastPos)
        {
            animator.SetBool("isWalking", false);
        }


        
    }
}
