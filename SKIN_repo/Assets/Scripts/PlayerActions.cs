using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerActions : MonoBehaviour
{
    /*[SerializeField]
    private TextMeshPro UseText;

    public Camera cam;
    private Transform cameraTransform;
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    private void Start()
    {
        cameraTransform = cam.transform;
    }
    public void OnInteract()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, MaxUseDistance, UseLayers))
        {
            if (hit.collider.TryGetComponent<Door>(out Door door))
            {
                if (door.IsOpen)
                {
                    door.Close();
                }
                else
                {
                    door.Open(transform.position);
                }
            }
        }

    }

    private void Update()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, MaxUseDistance, UseLayers)
            && hit.collider.TryGetComponent<Door>(out Door door))
        {
            if (door.IsOpen)
            {
                UseText.SetText("Close \"E\"");
            }
            else
            {
                UseText.SetText("Open \"E\"");
            }
            UseText.gameObject.SetActive(true);
            UseText.transform.position = hit.point - (hit.point - cameraTransform.position).normalized * 0.01f;
            UseText.transform.rotation = Quaternion.LookRotation((hit.point - cameraTransform.position).normalized);
        }
        else
        {
            UseText.gameObject.SetActive(false);
        }
    }*/



}
