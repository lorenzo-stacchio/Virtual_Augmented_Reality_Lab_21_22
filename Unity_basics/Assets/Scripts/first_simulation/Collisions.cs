using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    MeshRenderer thisRenderer; // meshrender component of the object

    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = GetComponent<MeshRenderer>();
    }

    // Manage the object collisions
    private void OnCollisionEnter(Collision other)
    {
        //this is necessary since enabling a unity script means activating it's main methods as Start() or Update()
        //but other methods could still be called!
        if (this.enabled)
        {
            //Inibit scripting
            Collider otherCollider = other.collider;
            Change_Color otherscript =
                otherCollider.GetComponent<Change_Color>();
            if (otherscript != null)
            {
                otherscript.enabled = false;
            }
            Debug.Log("The sphere is colliding");
            // game object refers to the object the script is attachet to!
            gameObject.AddComponent<Change_Color>();
        }
    }

}
