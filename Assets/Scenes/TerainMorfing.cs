using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerainMorfing : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }
    private void OnCollisionEnter(Collision c)
    {
        var TextureDamageRadius = 5f;
        var TerrainDamageRadius = 5f;
        if (c.transform.tag == "Terrain")
        {
            //c.gameObject.GetComponent<TerrainDeformer>().DestroyTerrain(c.contacts[0].point, TerrainDamageRadius, TextureDamageRadius);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
