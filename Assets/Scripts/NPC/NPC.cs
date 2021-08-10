using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour, INPC
{
    [SerializeField] protected TextMeshProUGUI texto;
    [SerializeField] int textLine;
    [SerializeField, TextArea] protected string[] dialogo;
    private bool playerCome;

    // Start is called before the first frame update
    void Awake()
    {
        texto = GameObject.FindGameObjectWithTag("TextBox").GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        ActiveText(false);
    }

    private void Update()
    {
        if (playerCome)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                NextLine();
            }
        }
    }


    public void ActiveText(bool index)
    {
        texto.gameObject.SetActive(index);
    }

    public void UpdateText()
    {
        texto.text = dialogo[textLine];
    }

    public void NextLine()
    {
        if (textLine < dialogo.Length - 1)
        {
            textLine++;
            UpdateText();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            ActiveText(true);
            UpdateText();
            playerCome = true;
        }

    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            ActiveText(false);
            playerCome = false;
        }
    }
}
