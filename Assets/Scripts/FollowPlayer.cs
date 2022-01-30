using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
            transform.position = Vector3.Lerp(transform.position, target.position,8 *  Time.deltaTime);
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }
}
