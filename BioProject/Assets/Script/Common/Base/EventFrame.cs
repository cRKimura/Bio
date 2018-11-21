using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Base
{
    public class EventFrame : EventTrigger
    {

        public void AddCallBack(EventTriggerType triggerType, UnityEngine.Events.UnityAction<BaseEventData> callBack)
        {
            if (this.triggers == null)
            {
                this.triggers = new List<EventTrigger.Entry>();
            }
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = triggerType;
            entry.callback.AddListener(callBack);
            this.triggers.Add(entry);
        }

        public void RemoveCallBack(EventTriggerType triggerType)
        {
            if (this.triggers == null || this.triggers.Count <= 0)
            {
                return;
            }
            var entry = this.triggers.Where(v => v.eventID == triggerType).SingleOrDefault();
            if (entry == null)
            {
                return;
            }

            this.triggers.Remove(entry);
        }

        public void AllRemoveCallBack()
        {
            this.triggers.Clear();
        }
    }
}
