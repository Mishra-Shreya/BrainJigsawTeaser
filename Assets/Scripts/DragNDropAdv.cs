using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DragNDropAdv : MonoBehaviour
{
    //public GameObject Puzzlelayout;
    //public GameObject Lockcanvas;
    //public GameObject Quizpanel;

    public AudioClip clkpieceaudio;

    public Sprite[] Levels;

    public GameObject EndMenu;
    public GameObject SelectedPiece;


    private Vector2 screenBounds;

    int OIL = 1;
    public int PlacedPieces = 0;

    void Start()
    {
        /*for (int i = 0;i < 36; i++)
        {
            GameObject.Find("Piece (" + i + ")").transform.Find("PuzzleAdv").GetComponent<SpriteRenderer>().sprite = Levels[PlayerPrefs.GetInt("Levels")];
        }*/

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("PuzzleAdv"))
            {
                if (!hit.transform.GetComponent<PiecesAdv>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PiecesAdv>().Selected = true;
                    AudioSource.PlayClipAtPoint(clkpieceaudio, transform.position, 0.1f);
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<PiecesAdv>().Selected = false;
                SelectedPiece = null;
            }
        }

        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }

        if (PlacedPieces == 9)
        {
            EndMenu.SetActive(true);
        }
    }


    /*public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        SceneManager.LoadScene("Game");
    }*/

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Levels");
    }
}
