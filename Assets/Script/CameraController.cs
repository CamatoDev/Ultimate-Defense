using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private bool canMove = true;

    public float panSpeed = 10f;

    public float maxHeight = 70f;
    public float minHeight = -50f;
    public float maxWidth = 120f;
    public float minWidth = -40f;

    public float scrollSpeed = 5f;

    public float minY = 20f;
    public float middleY = 40f;
    public float maxY = 60f;

    void Update()
    {
        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canMove = !canMove;
        }

        if(!canMove)
        {
            return;
        }

        //Zoom 
        //float scroll = Input.GetAxis("Mouse ScrollWheel");

        //Vector3 pos = transform.position;
        //pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //transform.position = pos;
    }

    //Fonction pour le zoom 
    public void Zoom()
    {
        //Posittion de la camera
        Vector3 pos = transform.position;

        //Zoom niveau 1 
        if (transform.position.y >= maxY)
        {
            Debug.Log("ok.");
            pos.y = middleY;
            transform.position = pos;
        }
        
        //Zoom niveau 2 
        else if (transform.position.y == middleY)
        {
            Debug.Log("ok ok.");
            pos.y = minY;
            transform.position = pos;
        }

        //Zoom niveau 3
        else if (transform.position.y <= minY)
        {
            Debug.Log("ok ok ok.");
            pos.y = maxY;
            transform.position = pos;
        }
    }

    public void Up()
    {
        //déplacement vers l'avant
        if (transform.position.x <= maxHeight)
        {
            transform.Translate(Vector3.right * panSpeed, Space.World);
        }
    }

    public void Down()
    {
        //déplacement vers l'arrière
        if (transform.position.x >= minHeight)
        {
            transform.Translate(Vector3.left * panSpeed, Space.World);
        }
    }

    public void Left()
    {
        //déplacement vers la gauche
        if (transform.position.z <= maxWidth)
        {
            transform.Translate(Vector3.forward * panSpeed, Space.World);
        }
    }

    public void Right()
    {
        //déplacement vers la droite
        if (transform.position.z >= minWidth)
        {
            transform.Translate(Vector3.back * panSpeed, Space.World);
        }
    }
}
