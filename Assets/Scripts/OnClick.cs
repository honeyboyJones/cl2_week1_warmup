using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    //called before the first frame update
    void Start()
    {
        //trying to get the specific sprite to have different points for different colors
        //color = GetComponent<SpriteRenderer>().sprite;
    }

    //called once per frame
    void Update()
    {
        //on left mouse button click
        if(Input.GetMouseButton(0))
        {
            //needs to have something that can tell if the mouse is on a circle
            //Destroy(gameObject);

            //sends a ray from mouse point to see if on a circle
            //ScreenToWorldPoint transforms a point from screen space into Unity world space using the mouse position
            //Vector2.zero same as Vector2(0, 0)
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //if the ray hits a collider
            if(hit.collider != null)
            {
                //if the collider is on a gameObject
                if(hit.collider.gameObject==gameObject)
                {
                    //add point through CircleSpawn
                    print("POINT ADDED");
                    CircleSpawn.instance.AddPoint();

                    //destroys the specific circle that was clicked
                    Destroy(gameObject);
                }
            }
        }
    }
}
