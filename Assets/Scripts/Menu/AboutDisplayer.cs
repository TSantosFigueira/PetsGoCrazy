using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AboutDisplayer : MonoBehaviour
{

    public GameObject credits;
    public GameObject mainMenu;

    public void DisplayCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        StartCoroutine(DoFade(credits));
    }

    public void UndisplayCredits()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
        StartCoroutine(DoFade(mainMenu));
    }

    IEnumerator DoFade(GameObject canvas)
    {

        CanvasGroup canvasG = canvas.GetComponent<CanvasGroup>();
        canvasG.alpha = 0;

        while (canvasG.alpha < 1)
        {
            canvasG.alpha += Time.deltaTime; // optinal parameters 2 ,3 ,5 
            yield return null;
        }
    }
}
