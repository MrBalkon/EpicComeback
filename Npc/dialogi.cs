using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogi : MonoBehaviour
{
    [SerializeField ]
    public GameObject Dialogs;
    public GameObject ChoosesOb;

    public List<GameObject> Chooses;
    public List<Button> Buttons;
    public List<Text> ChoosesText;

    public Text DialogWondow;

    public GameObject NextTextButton;

    public GameObject UseButton;
    public GameObject CloseButton;

    public int ChoosesNumber;

    public void Awake()
    {
        DialogControll.Dialogs = Dialogs;
        DialogControll.ChoosesOb = ChoosesOb;
        DialogControll.DialogWondow = DialogWondow;
        DialogControll.Chooses = Chooses;
        DialogControll.Buttons = Buttons;
        DialogControll.NextTextButton = NextTextButton;

        DialogControll.ChoosesText = ChoosesText;

        DialogControll.ChoosesNumber = ChoosesNumber;
        DialogControll.UseButton = UseButton;
        DialogControll.CloseButton = CloseButton;
    }
    public void OpenDialog()
    {
        Dialogs.SetActive(true);

    }

    public void Closediag()
    {
        DialogControll.DialogClose();
    }

    public void NextText()
    {
        DialogControll.NextText();
    }

    public void NextDialog1()
    {
        DialogControll.DialogProcess(DialogControll.ChooseeWay1);
    }

    public void NextDialog2()
    {
        DialogControll.DialogProcess(DialogControll.ChooseeWay2);
    }

    public void NextDialog3()
    {
        DialogControll.DialogProcess(DialogControll.ChooseeWay3);
    }

    public void Button1Vent()
    {
        if (DialogControll.ChooseEventNumber == 1)
        {
            DialogControll.Events[DialogControll.CurrentDialogueState].dei();
            DialogControll.ChooseEventNumber = 0;
        }
    }
    public void Button2Vent()
    {
        if (DialogControll.ChooseEventNumber == 2)
        {
            DialogControll.Events[DialogControll.CurrentDialogueState].dei();
            DialogControll.ChooseEventNumber = 0;
        }
    }
    public void Button3Vent()
    {
        if (DialogControll.ChooseEventNumber == 3)
        {
            DialogControll.Events[DialogControll.CurrentDialogueState].dei();
            DialogControll.ChooseEventNumber = 0;
        }
    }
}
