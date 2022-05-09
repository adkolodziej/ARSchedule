using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScheduleParser : MonoBehaviour
    {
        [SerializeField]
        public TextAsset scheduleJSON;

        public Rooms schedule;
        void Start()
        {
            schedule = JsonUtility.FromJson<Rooms>(scheduleJSON.text);

            foreach (var room in schedule.rooms)
            {
                foreach (var day in room.days)
                {
                    Debug.Log(day.weekday);
                    foreach (var c in day.classes)
                    {
                        Debug.Log(c.type + " " + c.week + ". " + c.subject + ": " + c.startHour + " - " + c.endHour);
                    }
                }
            }
        }
    }
}