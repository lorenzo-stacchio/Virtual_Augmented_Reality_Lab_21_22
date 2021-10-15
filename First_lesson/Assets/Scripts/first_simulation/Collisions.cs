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
            Material new_material = new Material(thisRenderer.material);
            Color new_color = getRandomColor();
            new_material.SetColor("_Color", new_color);
            thisRenderer.material = new_material;
        }
    }

    /*
   This function returns a Color object which is defined by a triplet of float values, indicating the value of R,G and B channels that defines a color in the RGB space.
   */
    private Color getRandomColor()
    {
        Color randomColor =
            new Color(Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f),
                Random.Range(0.0f, 1.0f));
        return randomColor;
    }
}
