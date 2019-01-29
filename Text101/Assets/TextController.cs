using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text text;

    private enum states { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
        corridor_0, stairs_0, stairs_1, stairs_2, courtyard, floor, corridor_1, corridor_2, corridor_3, closet_door, in_closet, 
        freedom,  };

    private states myState;

    // Use this for initialization
    void Start()
    {
        text.text = "press space";
        myState = states.cell;
    }

    // Update is called once per frame
    void Update()
    {
        print(myState);

        if (states.cell == myState)                 {cell();}
        else if (states.sheets_0 == myState)        {sheets_0();}
        else if (states.lock_0 == myState)          {lock_0();}
        else if (states.sheets_1 == myState)        {sheets_1();}
        else if (states.lock_0 == myState)          {lock_0();}
        else if (states.lock_1 == myState)          {lock_1();}
        else if (states.mirror == myState)          {mirror();}
        else if (states.cell_mirror == myState)     {cell_mirror();}
        else if (states.corridor_0 == myState)      {corridor_0();}
        else if (states.stairs_0 == myState)        {stairs_0();}
        else if (states.stairs_1 == myState)        {stairs_1();}
        else if (states.stairs_2 == myState)        {stairs_2();}
        else if (states.courtyard == myState)       {courtyard();}
        else if (states.floor == myState)           {floor();}
        else if (states.corridor_1 == myState)      {corridor_1();}
        else if (states.corridor_2 == myState)      {corridor_2();}
        else if (states.corridor_3 == myState)      {corridor_3();}
        else if (states.closet_door == myState)     {closet_door();}
        else if (states.in_closet == myState)       {in_closet();}
    }

    private void in_closet()
    {
        text.text = "here is cleaner uniform\n\n" +
                        "r return, d dress up";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.corridor_2; }
        else if (Input.GetKeyDown(KeyCode.D))       {myState = states.corridor_3; }

    }

    private void closet_door()
    {
        text.text = "locked closet\n\n" +
                        "r return";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.corridor_0; }

    }

    private void corridor_3()
    {
        text.text = "dressed as fine cleaner, in corridor\n\n" +
                        "u undress, s stairs";

        if (Input.GetKeyDown(KeyCode.U))            {myState = states.in_closet; }
        else if (Input.GetKeyDown(KeyCode.S))       {myState = states.courtyard; }
    }

    private void corridor_2()
    {
        text.text = "dressed as cleaner, in corridor\n\n" +
                        "c closet, s stairs";

        if (Input.GetKeyDown(KeyCode.C))            {myState = states.in_closet; }
        else if (Input.GetKeyDown(KeyCode.S))       {myState = states.stairs_2; }
    }

    private void corridor_1()
    {
        text.text = "hairclip in hand, on corridor - closet lockpick?\n\n" +
                        "s stairs, p lockpick";

        if (Input.GetKeyDown(KeyCode.P))            {myState = states.in_closet; }
        else if (Input.GetKeyDown(KeyCode.S))       {myState = states.stairs_1; }
    }

    private void floor()
    {
        text.text = "you found hairclip\n\n" +
                        "r stand up, h get hairclip";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.H))       {myState = states.corridor_1; }
    }

    private void courtyard()
    {
        text.text = "you are free\n\n" +
                        "p play again";

        if (Input.GetKeyDown(KeyCode.P))            {myState = states.cell; }
    }

    private void stairs_2()
    {
        text.text = "on stairs to outside, not wise" +
                    "\n\n" +
                    "r return";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.corridor_2; }
    }

    private void stairs_1()
    {
        text.text = "on stairs to outside, not wise" +
                    "\n\n" +
                    "r return";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.corridor_1; }
    }

    private void stairs_0()
    {
        text.text = "on stairs to outside, not wise" +
                    "\n\n" +
                    "r return";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.corridor_0; }
    }

    private void corridor_0()
    {
        text.text = "in coridor"+
                    "\n\n" +
                    "s stairs, c closet_door, f look floor";

        if (Input.GetKeyDown(KeyCode.S))            {myState = states.stairs_0;}
        else if (Input.GetKeyDown(KeyCode.C))       {myState = states.closet_door; }
        else if (Input.GetKeyDown(KeyCode.F))       {myState = states.floor; }

    }

   

    private void cell_mirror()
    {
        text.text = "escape??\n\n" +
                       "s sheets,  l lock";

        if (Input.GetKeyDown(KeyCode.S))            {myState = states.sheets_1;}
        else if (Input.GetKeyDown(KeyCode.L))       {myState = states.lock_1;}
    }

    private void mirror()
    {
        text.text = "loose mirror\n\n" +
                       "t take,  r return";

        if (Input.GetKeyDown(KeyCode.T))            {myState = states.cell_mirror;}
        else if (Input.GetKeyDown(KeyCode.R))       {myState = states.cell;}
    }

    private void lock_0()
    {
        text.text = "this is lock\n\n" +
                       " r return";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.cell;}
    }

    private void lock_1()
    {
        text.text = "mirror through bars - you see lock\n\n" +
                       "o open, r return";

        if (Input.GetKeyDown(KeyCode.O))            {myState = states.corridor_0;}
        else if (Input.GetKeyDown(KeyCode.R))       {myState = states.cell_mirror;}
    }

    void cell()
    {
        text.text = "you are in cell" +
                       " escape? \n\n" +
                       " s sheets, m mirror, l lock";

        if (Input.GetKeyDown(KeyCode.S))            {myState = states.sheets_0;}
        else if (Input.GetKeyDown(KeyCode.M))       {myState = states.mirror;}
        else if (Input.GetKeyDown(KeyCode.L))       {myState = states.lock_0;}
    }

    void sheets_0()
    {
        text.text = "dirty sheets\n\n" +
                       " r return";

        if (Input.GetKeyDown(KeyCode.R))            {myState = states.cell;}
    }

    void sheets_1()
    {
        text.text = "dirty sheets still, even with mirror in hand\n\n" +
                       " r return";

        if (Input.GetKeyDown(KeyCode.R))           {myState = states.cell_mirror;}
    }
}