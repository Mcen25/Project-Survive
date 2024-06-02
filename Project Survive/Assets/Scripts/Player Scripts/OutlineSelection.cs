using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    private Ray ray;
    private RaycastHit hit;

    public float maxDistance = 5f;
    private Transform previousHighlight = null;

    void Update()
    {  

    ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            highlight = hit.transform;

            if (highlight.CompareTag("Selectable"))
            {
                    if (highlight != previousHighlight && previousHighlight != null)
                    {
                        previousHighlight.gameObject.GetComponent<Outline>().enabled = false;
                    }

                    if (highlight.gameObject.GetComponent<Outline>().enabled == false)
                    {
                        highlight.gameObject.GetComponent<Outline>().enabled = true;
                    }

                    previousHighlight = highlight;
            }
            else if (previousHighlight != null)
            {
                previousHighlight.gameObject.GetComponent<Outline>().enabled = false;
                previousHighlight = null;
            }
        }
        else if (previousHighlight != null)
        {
            previousHighlight.gameObject.GetComponent<Outline>().enabled = false;
            previousHighlight = null;
        }
    }

    // // Selection
    // if (Input.GetButtonDown("Fire1"))
    // {
    //     if (highlight)
    //     {
    //         if (selection != null)
    //         {
    //             selection.gameObject.GetComponent<Outline>().enabled = false;
    //         }
    //         selection = raycastHit.transform;
    //         selection.gameObject.GetComponent<Outline>().enabled = true;
    //         highlight = null;
    //     }
    //     else
    //     {
    //         if (selection)
    //         {
    //             selection.gameObject.GetComponent<Outline>().enabled = false;
    //             selection = null;
    //         }
    //     }
    // }


}