using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Cartas : MonoBehaviour
{
    MazoDeCartas mazo;
    public GameObject cartaPrefab;
    public int cantCartas;
    public List<Sprite> simbolos;
    public List<string> figuras;
    public List<Carta> pozo = new List<Carta>();

    void Start()
    {
        mazo = new MazoDeCartas(cantCartas, simbolos.Count, figuras.Count);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InstantiateRandomCard();
        }
    }

    void InstantiateRandomCard()
    {
        int cardsRemaining = mazo.mazo.Count;
        if ( cardsRemaining > 0)
        {
            int randomIndex = Random.Range(0,cardsRemaining);
            Carta carta = mazo.mazo[randomIndex];
            mazo.mazo.RemoveAt(randomIndex);
            GameObject clon = Instantiate(cartaPrefab,transform.position,Quaternion.identity);
            CardScript cardscript = clon.GetComponent<CardScript>();

            if (carta.isNumeric)
            {
                cardscript.cardSymbol.sprite = simbolos[carta.simbolo];
                cardscript.textCardNumber.text = carta.numero.ToString();
                cardscript.textCardNumber2.text = carta.numero.ToString();
            }
            else
            {
                cardscript.textCardNumber.text = figuras[carta.numero];
                cardscript.textCardNumber2.text = figuras[carta.numero];
            }            
            pozo.Add(carta);
        }
    }
}
