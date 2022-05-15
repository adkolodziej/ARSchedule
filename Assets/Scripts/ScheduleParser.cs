using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

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
        [SerializeField]
        private List<ImageTargetBehaviour> imageTargets;
        [SerializeField]
        private GameObject scheduleUI;

        private Rooms schedule;
        void Start()
        {
            schedule = JsonUtility.FromJson<Rooms>(scheduleJSON.text);
            Deactivate();
        }

        public void Deactivate()
        {
            //scheduleUI.gameObject.SetActive(false);
            //scheduleUI.transform.parent = transform;
        }

        public void readSchedule()
        {
            scheduleUI.gameObject.SetActive(true);
            var imageTarget = imageTargets.Find(x => x.TargetStatus.Status == Status.TRACKED);
            if(imageTarget == null) return;
            var columns = GameObject.FindGameObjectsWithTag("column");  // all columns for class boxes
            GameObject prefab;  // prefab that should be used based on week presence

            foreach (var room in schedule.rooms)
            {
                if (!imageTarget.TargetName.Contains(room.number.ToString()))
                    continue;

                scheduleUI.transform.parent = imageTarget.transform;
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

                        box.transform.rotation = new Quaternion(90,0,0,0);
                        box.transform.localScale = Vector3.one;
                        box.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    }
                }
            }
        }
    }
}