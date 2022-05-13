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
        public GameObject classUIPrefab;
        [SerializeField]
        public GameObject scheduleUI;

        public Rooms schedule;
        void Start()
        {
            schedule = JsonUtility.FromJson<Rooms>(scheduleJSON.text);
            readSchedule();
        }

        public void readSchedule()
        {
            var room = schedule.rooms[0];
            foreach (var day in room.days)
            {
                int dayOfWeek = (int)day.weekday;
                foreach (var c in day.classes)
                {
                    var newClass = Instantiate(classUIPrefab);
                    var classScript = newClass.GetComponent<InitializeClassUI>();
                    classScript.setTimeBoundries(c.startHour, c.endHour);
                    classScript.SetTexts(c.subject, c.type.ToString(), c.teacher, c.group);

                    var panelSize = scheduleUI.GetComponent<RectTransform>().sizeDelta;

                    newClass.transform.parent = scheduleUI.transform;
                    newClass.transform.localScale = new Vector3(1, 1, 1);
                    Vector3 pos = newClass.transform.position;
                    pos.y += classScript.endPosition * 2 * (panelSize.y / 44);
                    Debug.Log($"{pos.y} is for {classScript.endPosition}");
                    pos.x = scheduleUI.transform.position.x - panelSize.x * 4 + ((dayOfWeek * panelSize.x * 4) / 7);
                    newClass.transform.position = pos;
                
                    Vector2 size = newClass.GetComponent<RectTransform>().sizeDelta;
                    size.y = (classScript.startPosition - classScript.endPosition) * (panelSize.y / 44);
                    newClass.GetComponent<RectTransform>().sizeDelta = size;
                }
            }
        }
    }
}