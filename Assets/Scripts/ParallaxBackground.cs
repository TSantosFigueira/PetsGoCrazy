using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public float speed;
    public bool isInactive = false;
    public float time;

    private float resetDistance;
    private float initialPosition;
    private bool canInstantiate = true;

    void Start()
    {
        Vector3 gameBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));

        resetDistance = -gameBounds.x;
        initialPosition = transform.position.x;

    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            if (isInactive)
                gameObject.SetActive(true);

            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            if (transform.position.x > resetDistance && canInstantiate)
            {
                Instantiate(gameObject, new Vector3(initialPosition - GetComponent<Renderer>().bounds.size.x, transform.position.y, 0), Quaternion.identity, transform.parent);
                canInstantiate = false;
            }

            if (transform.position.x > resetDistance + (GetComponent<Renderer>().bounds.size.x / 2))
            {
                Destroy(gameObject);
            }
        }
    }
}
