using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditsScroll : MonoBehaviour
{
    public float UpwardSpeed_Velocity;
    [SerializeField] Text mytext;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, UpwardSpeed_Velocity, 0);
        mytext = GetComponent<Text>();
        SetText();
    }
    private void SetText()
    {
        mytext.text =
            ("<b> FallSafe </b>@@@@@@@@@@" +
            "<b><i>Game Design</i></b>@@@" +
            "Luke G Gillen@@" +
            "Kevin Huang@@" +
            "Hector Castelli Zacharias@@@@" +
            "<b><i>Programming</i></b>@@@" +
            "Hector Castelli Zacharias@@@@" +
            "<b><i>Art</i></b>@@" +
            "<b>3D Assets</b>@@@" +
            "Michael Long@@" +
            "Minkyoung Choi@@@@" +
            "<b>2D Assets</b>@@@" +
            "Minkyoung Choi@@@@" +
            "<b><i>Audio</i></b>@@" +
            "<b>Music</b>@@@" +
            "Steph Nguyen@@@@" +
            "<b>Sound Effects</b>@@@" +
            "Brian Ceely@@" +
            "Steph Nguyen@@" +
            "" +
            "@@@@@@@@@@" +
            "Thank You For Playing" +
            "").Replace("@", "\n");
    }
}
