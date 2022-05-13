using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InitializeClassUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI subject;
    [SerializeField]
    private TextMeshProUGUI type;
    [SerializeField]
    private TextMeshProUGUI teacher;
    [SerializeField]
    private TextMeshProUGUI group;
    [SerializeField]
    private GameObject background;

    private Color blockColor;
    public int startPosition;
    public int endPosition;

    public void SetTexts(string subject, string type, string teacher, string group)
    {
        this.subject.text = subject;
        this.type.text = type.ToString();
        this.teacher.text = teacher;
        this.group.text = group;
        setColor(type);
        background.GetComponent<Image>().color = blockColor;
    }

    public void setTimeBoundries(string start, string end)
    {
        int startHour = int.Parse(start.Substring(0, 2));
        int startMinute = int.Parse(start.Substring(3, 2));
        int endHour = int.Parse(end.Substring(0, 2));
        int endMinute = int.Parse(end.Substring(3, 2));

        startPosition = 44 - ((startHour - 7) * 4 + startMinute / 15);
        endPosition = 44 - ((endHour - 7) * 4 + endMinute / 15);
    }

    private void setColor(string type)
    {
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
