using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Dei();
public abstract class NpcControl : MonoBehaviour
{
    public Animator anim;
    //public List<List<string>> ChoosesId;
    public List<Events> Eventss = new List<Events>();
    public List<SubList> ChoosesId = new List<SubList>();

}
[System.Serializable]
public class SubList
{
    public string name; // дополнительное поле, чтобы в инсекторе отобразить имя массива для удобства
    public int Choose1Way;
    public int Choose2Way;
    public int Choose3Way;
    public List<string> Dialogues = new List<string>();
    public List<string> list = new List<string>();

   
}
[System.Serializable]
public class Events
{
    public string EventName;
    public int DiagStateNumber;
    public int ChooseNumber;
    public Dei dei;
    
}