using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogControll : MonoBehaviour
{
    internal static GameObject Dialogs;
    internal static GameObject ChoosesOb;

    internal static List<GameObject> Chooses;
    internal static List<Button> Buttons;
    internal static GameObject NextTextButton;

    internal static List<Text> ChoosesText;
    internal static GameObject UseButton;
    internal static GameObject CloseButton;

    internal static List<Text> DiagThis;
    internal static Text DialogWondow;

    internal static List<SubList> ChoosesId = new List<SubList>();

    internal static List<Events> Events = new List<Events>();
    
    internal static int ChoosesNumber;
    internal static int ChooseWayNumber;

    internal static int DialoguesCount = 0;

    internal static int CurrentDialogueState = 0;

    internal static int DialoguesWndownCount = 0;
    internal static int DialoguesWndownCountMax = 0;

    internal static int ChooseeWay1;
    internal static int ChooseeWay2;
    internal static int ChooseeWay3;

    internal static int ChooseEventNumber=0;

    
    internal static void Choose123()
    {
        Chooses[0].SetActive(true);
        Chooses[1].SetActive(true);
        Chooses[2].SetActive(true);

    }
    internal static void Choose12()
    {
        Chooses[0].SetActive(true);
        Chooses[1].SetActive(true);
        Chooses[2].SetActive(false);
    }
    internal static void Choose1()
    {
        Chooses[0].SetActive(true);
        Chooses[1].SetActive(false);
        Chooses[2].SetActive(false);
    }

    internal static void ChooseNumbers(int i)
    {
        Choose123();
        if (DialogControll.ChoosesId[i].list[2] == "")
        {
            Choose12();
        }
        if (DialogControll.ChoosesId[i].list[1] == "")
        {
            Choose1();
        }
        
         
      

        //Debug.Log(ChoosesNumber);
    }

    internal static void TextTranslater(List<SubList> text,List<Events> ev)
    {
        UseButton.SetActive(true);

        DialogControll.Events = ev;

        int b = 0;
        DialoguesCount = 0;
        DialoguesWndownCount = 0;
        DialoguesWndownCountMax = 0;
        CurrentDialogueState = 0;

        for (int i = 0; i < 3; i++)
        {
            ChoosesText[i].text = text[b].list[i];

        }
        while (text[b].name != "End")
        {
           
            DialogWondow.text = text[0].Dialogues[0];
            b = b + 1;
            DialoguesCount = DialoguesCount + 1;
            
        }
        while (text[0].Dialogues[DialoguesWndownCountMax] != "End")
        {
            DialoguesWndownCountMax += 1;
        }

        if (text[0].Dialogues.Capacity == 1)
        {
            NextTextButton.SetActive(false);
        }
        else
        {
            NextTextButton.SetActive(true);
        }

        ChooseeWay1 = text[0].Choose1Way;
        ChooseeWay2 = text[0].Choose2Way;
        ChooseeWay3 = text[0].Choose3Way;

        if (ev[0].DiagStateNumber == CurrentDialogueState)
        {
            Events.Add(ev[0]);
            Events[0].dei = ev[0].dei;
            ChooseEventNumber = ev[0].ChooseNumber;
           // Debug.Log(CurrentDialogueState);
        }

        

        CurrentDialogueState = 0;

        DialoguesWndownCount = 1;
        DialogControll.ChoosesId = text;
        DialogControll.ChooseNumbers(0);

    }

    internal static void DialogProcess(int CurDiagState)
    {
        for (int i = 0; i < Events.Count; i++)
        {
            if (Events[i].DiagStateNumber == CurrentDialogueState)
            {
                ChooseEventNumber = Events[i].ChooseNumber;
            }
        }
        DialoguesWndownCount = 0;
        DialoguesWndownCountMax = 0;
        
        for (int i = 0; i < 3; i++)
        {
           
            ChoosesText[i].text = ChoosesId[CurDiagState].list[i];
        }

        while (ChoosesId[CurDiagState].Dialogues[DialoguesWndownCountMax] != "End")
        {
            DialoguesWndownCountMax += 1;
        }

        DialogWondow.text = ChoosesId[CurDiagState].Dialogues[0];

        if (ChoosesId[CurDiagState].Dialogues.Capacity == 1)
        {
            NextTextButton.SetActive(false);
        }
        else
        {
            NextTextButton.SetActive(true);
        }
        DialogControll.ChooseNumbers(CurDiagState);


        DialoguesWndownCount = 1;
        ChooseeWay1 = ChoosesId[CurDiagState].Choose1Way;
        ChooseeWay2 = ChoosesId[CurDiagState].Choose2Way;
        ChooseeWay3 = ChoosesId[CurDiagState].Choose3Way;

        

        Debug.Log(CurrentDialogueState);

    }

    internal static void NextText()
    {
        DialogWondow.text = ChoosesId[CurrentDialogueState].Dialogues[DialoguesWndownCount];
        DialoguesWndownCount = DialoguesWndownCount + 1;
        if (DialoguesWndownCount == DialoguesWndownCountMax)
        {
            NextTextButton.SetActive(false);
        }
    }
    internal static void DialogOpen()
    {
        DialogControll.Dialogs.SetActive(true);
        DialogControll.ChoosesOb.SetActive(true);
        CloseButton.SetActive(true);
    }

    internal static void DialogClose()
    {
        DialogControll.Dialogs.SetActive(false);
        DialogControll.ChoosesOb.SetActive(false);
        CloseButton.SetActive(false);
    }

}
