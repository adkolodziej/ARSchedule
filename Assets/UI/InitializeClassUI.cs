using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InitializeClassUI : MonoBehaviour
{
    [SerializeField]
    private Text subject;
    [SerializeField]
    private Text type;
    [SerializeField]
    private Text teacher;
    [SerializeField]
    private Text group;
    [SerializeField]
    private GameObject background;

    private Color blockColor;

    public void SetTexts(string subject, string type, string teacher, string group)
    {
        this.subject.text = subject;
        this.type.text = type.ToString();
        this.teacher.text = teacher;
        this.group.text = group;
        setColor(type);
        background.GetComponent<Image>().color = blockColor;
    }

    public void setHours(string start, string end)
    {
        int startHour = int.Parse(start.Substring(0, 2));
        int startMinute = int.Parse(start.Substring(3, 2));
        int endHour = int.Parse(end.Substring(0, 2));
        int endMinute = int.Parse(end.Substring(3, 2));
    }

    private void setColor(string type)
    {
        Debug.Log(type);
        switch(type)
        {
            case "exercises":
                blockColor = Color.red;
                break;
            case "lecture":
                blockColor = Color.green;
                break;
            case "project":
                blockColor = Color.magenta;
                break;
            case "seminar":
                blockColor = Color.yellow;
                break;
            default:
                blockColor = Color.gray;
                break;
        }
    }
}
