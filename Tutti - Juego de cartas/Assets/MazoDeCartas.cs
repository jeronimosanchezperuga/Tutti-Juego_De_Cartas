using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazoDeCartas
{
    public List<Carta> mazo = new List<Carta>();
    int cantCartas;
    int cantSimbolos;
    int cantFiguras;

    public MazoDeCartas(int cantCartas, int simbolos, int figuras)
    {
        this.cantCartas = cantCartas;
        cantSimbolos = simbolos;
        cantFiguras = figuras;
        GenerateDeck();
    }

    public void ShowAllCardsOnConsole()
    {
        for (int i = 0; i<mazo.Count;i++)
        {
            Debug.Log(i+1 + ": " +  mazo[i].simbolo + ", " + mazo[i].numero);
        }
    }


    private void GenerateDeck()
    {
        mazo.Clear();
        for (int i = 0; i<cantSimbolos;i++)
        {
            for (int j = 2; j<=cantCartas;j++)
            {
                Carta carta = new Carta(i,j,true);
                mazo.Add(carta);
            }
            for (int k = 0; k<cantFiguras;k++)
            {
                Carta cartaEspecial = new Carta(i,k,false);
                mazo.Add(cartaEspecial);
            }
        }
    }

}

public class Carta
{
    public int simbolo;
    public int numero;
    public bool isNumeric;

    public Carta(int simbolo, int nro, bool isNumeric)
    {
        this.simbolo = simbolo;
        this.numero = nro;
        this.isNumeric = isNumeric;
    }
}
