using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piceseScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    public AudioClip Piecescorrectplaceaud;
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(6f, 11f), Random.Range(1.5f, -5.5f));
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                    Camera.main.GetComponent<DragAndDrop_>().PlacedPieces++;
                    AudioSource.PlayClipAtPoint(Piecescorrectplaceaud, transform.position, 1f);
                }
            }
        }
    }
}
