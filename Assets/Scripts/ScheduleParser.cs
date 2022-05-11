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

            foreach (var room in schedule.rooms)
            {
                foreach (var day in room.days)
                {
                    foreach (var c in day.classes)
                    {
                        var newClass = Instantiate(classUIPrefab);
                        newClass.transform.parent = scheduleUI.transform;
                        Vector3 pos = newClass.transform.position;
                        pos.x += 400;
                        newClass.transform.position = pos;
                        var classScript = newClass.GetComponent<InitializeClassUI>();
                        classScript.setHours(c.startHour, c.endHour);
                        classScript.SetTexts(c.subject, c.type.ToString(), c.teacher, c.group);
                    }
                }
            }

        }
    }
}