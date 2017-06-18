using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public string verticalAxis;
    public string AButton;
    public Image characterBoard;
    public bool isSelectPressed = false;

    public Sprite[] characters;

    private float vertical;
    private bool canMove = true;
    private static int ready = 0;
    private static int players = 1;

    void Start()
    {
        PlayerPrefs.SetString(gameObject.name, "null");
    }

    void Update()
    {

        if (!isSelectPressed && canMove) //Se a pre-definição não determinar que está ativo, então deve aguardar ativação do jogador
        {
            isSelectPressed = Input.GetButtonUp(AButton);
            StartCoroutine("Blink");
            if (isSelectPressed)
                players += 1;
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

        if (Input.GetButtonDown(AButton))
        {
            canMove = false;
            characterBoard.color = new Color(characterBoard.color.r, characterBoard.color.g, characterBoard.color.b, 0.5f);
            PlayerPrefs.SetString(gameObject.name, characters[0].name);
            PlayerPrefs.Save();
            ready += 1;
            StartGame();
        }
    }

    void StartGame()
    {
        if (ready % players == 0)
        {
            SceneManager.LoadScene(2);
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
