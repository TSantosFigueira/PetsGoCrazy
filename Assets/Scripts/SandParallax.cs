using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandParallax : MonoBehaviour {

    public float speed;
    public float time;

    private float resetDistance;
    private Vector3 initialPosition;
    private float originalTime;
    private bool hasBegun = false;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0);
        Vector3 gameBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));

        resetDistance = -gameBounds.x;
        initialPosition = transform.position;
        originalTime = time;
    }

    void Update()
    {
        time -= Time.deltaTime;
        
        if(time <= 0 && !hasBegun)
        {
            StartCoroutine("SandStorm");
            hasBegun = true; 
        }

        if (hasBegun)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            if (transform.position.x > resetDistance)
            {
                GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0);
                gameObject.transform.position = initialPosition;
                time = originalTime;
                hasBegun = false;
            }
        }
    }

    IEnumerator SandStorm()
    {
        Color rendererColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(rendererColor.r, rendererColor.g, rendererColor.b, 0);
        while(rendererColor.a < 1)
        {
            rendererColor.a += Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(rendererColor.r, rendererColor.g, rendererColor.b, rendererColor.a);
            yield return null; 
        }
    }
}

