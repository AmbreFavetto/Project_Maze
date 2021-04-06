using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItems : MonoBehaviour
{
    private bool dragging = true;
    public SwitchItems switchItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 roundPoint = new Vector2((int)point.x + 0.5f, (int)point.y + 0.5f);
        transform.position = roundPoint;

        if (transform.position.x > 11)
        {
            transform.position = Vector2.right * 10;
        } else if(transform.position.x < -9)
        {
            transform.position = Vector2.right * -8;
        } else if(transform.position.y > 6)
        {
            transform.position = Vector2.up * 5;
        } else if (transform.position.y < - 7)
        {
            transform.position = Vector2.up * -6;
        }

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(gameObject);
        }
    }

}
