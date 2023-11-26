using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text leftscore;
    [SerializeField] private Text rightscore;
    [SerializeField] private Button startbutton;
    [SerializeField] private ball ball;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip goal;
    [SerializeField] private AudioSource audioS;


    private int leftplayerscor = 0;
    private int righttplayerscor = 0;

    public void  startgmaebtn()
    {
        ball.Startthegame();
        startbutton.gameObject.SetActive(false);
    }
    public void fn_winner(int winner)
    {
        audioS.clip = goal;
        audioS.Play();
        if (winner == 0)
        {
            leftplayerscor++;
            leftscore.text = leftplayerscor.ToString();
        }
        else
        {
            righttplayerscor++;
            rightscore.text = righttplayerscor.ToString();
        }
        startbutton.gameObject.SetActive(true);
    }
    public void touchsound()
    {
        audioS.clip = click;
        audioS.Play();
    }


}
