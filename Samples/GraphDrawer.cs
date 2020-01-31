using System;
using System.Collections.Generic;
using UnityEngine;

namespace SMILEI.Core.Samples
{
    public class GraphDrawer : MonoBehaviour
    {
        [Serializable] public class Item
        {
            public GraphItemSettings Settings;
            public GraphLine Line;
            public GraphLabel Label;

            public void SetupItem()
            {
                var name = string.IsNullOrEmpty(Settings.DisplayName) ? Settings.name : Settings.DisplayName;
                Label.gameObject.SetActive(true);
                Line.gameObject.SetActive(true);
                Line.SetDisplayValues(name, Settings.LineColor);
                Label.SetDisplayValues(name, Settings.LineColor);
            }
            public void OnReceiveUpdate(Emotion value)
            {
                Line.AddDataPoint(value.Value);
            }
        }

        public List<GraphItemSettings> GraphItems;
        private List<Item> _items;

        public Transform Labels;
        public GraphLabel LabelPrototype;
        public Transform Lines;
        public GraphLine LinePrototype;

        void Start()
        {
            _items = new List<Item>(GraphItems.Count);
            foreach (GraphItemSettings graphItem in GraphItems)
            {
                AddItem(graphItem);
            }
        }


        public void AddItem(GraphItemSettings item)
        {
            var label = Instantiate(LabelPrototype, Labels);
            var line = Instantiate(LinePrototype, Lines);
            var newItem = new Item()
            {
                Label = label,
                Line = line,
                Settings = item
            };
            newItem.SetupItem();
            _items.Add(newItem);
        }

        public void RemoveItem(GraphItemSettings item)
        {
            var idx = _items.FindIndex(x => x.Settings == item);
            if (idx == -1)
            {
                Debug.LogError($"Could not find item {item.name} in graph");
                return;
            }
            Destroy(_items[idx].Label);
            Destroy(_items[idx].Line);
            
            _items.RemoveAt(idx);
        }
        

        void Update()
        {
            foreach (var item in _items)
            {
                if (item.Settings.MixerAsset == null) continue;
                var value = item.Settings.MixerAsset.GetValue();
                item.OnReceiveUpdate(value);
            }
        }
    }

}
