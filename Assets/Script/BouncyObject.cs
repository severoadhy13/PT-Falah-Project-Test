using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyObject : MonoBehaviour
{

    private Vector3 positionVec;
    private Vector3 velocityVec;

    public float velocityNum = 0.1f;
    public int boundaryX = 20;
    public int boundaryZ = 10;
    public Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        positionVec = new Vector3(0,0,0);
        velocityVec = new Vector3(velocityNum, 0, velocityNum/3);

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(positionVec.x > boundaryX || positionVec.x < -boundaryX)
        {
            velocityVec.x = -velocityVec.x;
        }

        if(positionVec.z > boundaryZ || positionVec.z < -boundaryZ)
        {
            velocityVec.z = -velocityVec.z;
        }

        positionVec += velocityVec;
        transform.position = positionVec;
        
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == "Box")
        {
            rend.sharedMaterial = material[1];
        }
        else
        {
            rend.sharedMaterial = material[2];
        }
    }
}
