using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public string cenaParaCarregar;
    public string menuPrincipal;
    //Carrega a primeira fase

    public void goToScene()
    {
        StartCoroutine(FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.Out, cenaParaCarregar));
        //SceneManager.LoadScene(cenaParaCarregar);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(menuPrincipal);
    }
}
