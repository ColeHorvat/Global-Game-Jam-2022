using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerGrab : MonoBehaviour
{
    private float mouseAngle;
    private GameObject playerG;
    private PlayerController playerController;
    private Collider2D playerCollider;
    private Collider2D bodyCollider;
    private Rigidbody2D rb2d;
    public LayerMask bodyLayer;
    private RaycastHit2D hit;
    private GameObject bodyObject;
    private float distance;
    private GameObject grabPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        playerG = this.gameObject;
        playerController = playerG.GetComponent<PlayerController>();
        rb2d = playerG.GetComponent<Rigidbody2D>();
        bodyLayer = LayerMask.GetMask("Body");
        grabPoint = playerG.transform.GetChild(1).gameObject;
        playerCollider = playerG.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0) && playerController.isSoul)
        {
            //UnityEngine.Debug.Log("IDIOT");


            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDir = mouseWorldPosition - rb2d.position;
            
            Debug.DrawRay(transform.position, lookDir, Color.red, 0f);

            hit = Physics2D.Linecast(transform.position, mouseWorldPosition, bodyLayer);
            if (hit.collider != null && !playerCollider.IsTouching(hit.collider))
            {
                bodyObject = hit.collider.gameObject;
                distance = Vector2.Distance(playerG.transform.position, bodyObject.transform.position);

                if (distance < 5f)
                {
                    bodyObject.GetComponent<BoxCollider2D>().enabled = false;
                    bodyObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    bodyObject.transform.position = grabPoint.transform.position;
                    bodyObject.transform.parent = grabPoint.transform;
                    
                }
            }
            else
            {
                Debug.Log("Nothing");
            }
            
            
        }
    }
}
