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
    
    [SerializeField] private Camera fpsCamera;
    public Camera currentCamera;

    void Update()
    {  

    ray = currentCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if(currentCamera.tag == "MainCamera") {
            GetComponent<FPSController>().canMove = true;

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

            if (Input.GetButtonDown("Fire1"))
            {
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    highlight = hit.transform;
                    if (highlight.CompareTag("CameraSelectable"))
                    {
                        //get raycast hit object
                        //get the object's script pressed to camera
                        //Switch camera First Person Camera to Overhead Camera
                        var pressedToCamera = highlight.Find("Button Camera"); 
                        if (pressedToCamera != null && pressedToCamera != null && currentCamera != null)
                        {
                            Camera changedCamera = pressedToCamera.GetComponent<Camera>();
                            currentCamera.enabled = false;
                            currentCamera = changedCamera;
                            changedCamera.enabled = true;
                        }
                        else
                        {
                            Debug.LogError("Camera or OverheadCamera is not assigned.");
                        }
                    }
                }
            }
        } else {
            //disable movement
            GetComponent<FPSController>().canMove = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (Input.GetKeyDown(KeyCode.Q)) {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                currentCamera.enabled = false;
                fpsCamera.enabled = true;
                currentCamera = fpsCamera;
            }

            if (highlight != null)
            {
                highlight.gameObject.GetComponent<Outline>().enabled = false;
                highlight = null;
            }


            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
            {
                highlight = hit.transform;
                if (highlight.CompareTag("Selectable"))
                {
                    if (highlight.gameObject.GetComponent<Outline>() != null)
                    {
                        highlight.gameObject.GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        Outline outline = highlight.gameObject.AddComponent<Outline>();
                        outline.enabled = true;
                        highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                        highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                    }
                }
                else
                {
                    highlight = null;
                }
            }
        }       
    }
}