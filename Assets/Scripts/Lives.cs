using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{ [SerializeField]
    private List<Image> _lives = new List<Image>();

    private int _currentLives = 3;

    public void SetLives(int lives)
    {
        _currentLives = lives;
        for (int i = 0; i < _lives.Count; i++)
        {
            if(i < lives)
            {
                _lives[i].enabled = true;
            }

            else
            {
                _lives[i].enabled = false;
            }
        }
    }
}
