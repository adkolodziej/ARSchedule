using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScheduleParser : MonoBehaviour
    {
        [SerializeField]
        public TextAsset scheduleJSON;
        [SerializeField]
        public GameObject classPrefabBoth;
        [SerializeField]
        public GameObject classPrefabOdd;
        [SerializeField]
        public GameObject classPrefabEven;
        [SerializeField]
        public GameObject classesPanel;

        private Rooms schedule;
        void Start()
        {
            schedule = JsonUtility.FromJson<Rooms>(scheduleJSON.text);
            readSchedule(529);
        }

        public void readSchedule(int roomNumber)
        {
            var columns = GameObject.FindGameObjectsWithTag("column");  // all columns for class boxes
            GameObject prefab;  // prefab that should be used based on week presence

            foreach (var room in schedule.rooms)
            {
                if (room.number != roomNumber)
                    continue;

                foreach (var day in room.days)
                {
                    int dayOfWeek = (int)day.weekday;
                    foreach (var c in day.classes)
                    {
                        switch (c.week)
                        {
                            case Week.odd:
                                prefab = classPrefabOdd;
                                break;
                            case Week.even:
                                prefab = classPrefabEven;
                                break;
                            default:
                                prefab = classPrefabBoth;
                                break;
                        }

                        var box = Instantiate(prefab);
                        var boxScript = box.GetComponent<InitializeClassUI>();
                        box.transform.SetParent(columns[dayOfWeek].transform);

                        boxScript.setTimeBoundries(c.startHour, c.endHour);
                        boxScript.SetTexts(c.subject, c.type.ToString(), c.teacher, c.group);

                        Vector2 panelSize = classesPanel.GetComponent<RectTransform>().sizeDelta;
                        Vector3 panelPos = classesPanel.transform.position;
                        Vector2 size = box.GetComponent<RectTransform>().sizeDelta;
                        Vector3 pos = box.transform.position;

                        pos.y += boxScript.endPosition * (panelSize.y / 44);
                        size.y = (boxScript.startPosition - boxScript.endPosition) * (panelSize.y / 44);

                        box.transform.position = pos;
                        box.GetComponent<RectTransform>().sizeDelta = size;
                    }
                }
            }
        }
    }
}