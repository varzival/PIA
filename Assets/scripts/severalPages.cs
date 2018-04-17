using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class severalPages : MonoBehaviour {

    public GameObject[] pages;
    public GameObject prevButton;
    public GameObject nextButton;
    private int currentPage = 0;

    public void next()
    {
        if (currentPage+1 >= pages.Length)
        {
            Debug.Log("Page overflow.");
        }
        else
        {
            pages[currentPage].SetActive(false);
            pages[++currentPage].SetActive(true);
            checkButtons();
        }
    }

    public void previous()
    {
        if (currentPage - 1 < 0)
        {
            Debug.Log("Page underflow.");
        }
        else
        {
            pages[currentPage].SetActive(false);
            pages[--currentPage].SetActive(true);
            checkButtons();
        }
    }

    void checkButtons()
    {
        if (currentPage == 0)
        {
            prevButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else if (currentPage == pages.Length - 1)
        {
            prevButton.SetActive(true);
            nextButton.SetActive(false);
        }
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
        }
    }

	// Use this for initialization
	void Start () {
        pages[0].SetActive(true);
        prevButton.SetActive(false);
        nextButton.SetActive(true);
		for (int i = 1; i<pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
