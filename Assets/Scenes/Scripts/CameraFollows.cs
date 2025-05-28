using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{

    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = new Vector3(target.position.x, target.position.y, -10);
        transform.position = cameraPos;

    }
}
