using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public string verticalAxis;
    public string unblockAccess;
    public string AButton;
    public string startButton;
    public Image characterBoard;
    public bool isSelectPressed = false;

    public Sprite[] characters;

    public Text startCountTxt;
    public int startCount;

    private float vertical;
    private bool canMove = true;
    public bool canPlay = false;

    private static int ready = 0;
    private static int players = 1;

    void Start() {
        PlayerPrefs.SetString(gameObject.name, "null");
        startCount = 3;
    }

    void Update() {

        if (!isSelectPressed && canMove) //Se a pre-definição não determinar que está ativo, então deve aguardar ativação do jogador
        {    
            StartCoroutine("Blink");

            if (Input.GetButtonUp(unblockAccess))
            {
                players += 1;
                characterBoard.sprite = characters[0];
                StopCoroutine("Blink");
                this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g,
                    this.GetComponent<Image>().color.b, 1f);
                isSelectPressed = true;
            }
                
        }

        if (isSelectPressed && canMove) //Se estiver ativo, permitir a mudança de sprites
        {
            vertical = Input.GetAxis(verticalAxis);

            if (vertical > 0)
                characterBoard.sprite = characters[0];
         
            else if (vertical < 0)
                characterBoard.sprite = characters[1];

            characterBoard.SetNativeSize();
        }

        if (Input.GetButtonDown(AButton) && isSelectPressed && canMove)
        {
            canMove = false;
            characterBoard.color = new Color(characterBoard.color.r, characterBoard.color.g, characterBoard.color.b, 0.5f);
            PlayerPrefs.SetString(gameObject.name, this.GetComponent<Image>().sprite.name);
            PlayerPrefs.Save();
            ready += 1;
            StartGame();
        }
    }

    void StartGame() {
        if (ready == 2 || ready == 4) {
            InvokeRepeating("PlayGame", 1f, 1f); /*StartCoroutine("PlayGame");*/
        }
    }

    void PlayGame() {
        if(ready == 2 || ready == 4) {
            startCountTxt.text = startCount.ToString();
            print(startCount);
            startCount -= 1;
        }
        else{ startCount = 3; startCountTxt.text = ""; }
        if(startCount < 0) {
            SceneManager.LoadScene(Random.Range(2, 4));
            ready = players = 0;
        }
    }

    IEnumerator Blink()
    {
        Color tempColor = GetComponent<Image>().color;

        if(tempColor.a >= 1)
            while (tempColor.a > 0)
            {
                tempColor.a -= Time.deltaTime;
                GetComponent<Image>().color = new Color(tempColor.r, tempColor.g, tempColor.b, tempColor.a);
                yield return null;
            }

        if (tempColor.a <= 0)
            while (tempColor.a < 1)
            {
                tempColor.a += Time.deltaTime;
                GetComponent<Image>().color = new Color(tempColor.r, tempColor.g, tempColor.b, tempColor.a);
                yield return null;
            }
    }
}
