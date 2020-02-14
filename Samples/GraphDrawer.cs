using System;
using System.Collections.Generic;
using UnityEngine;

namespace SMILEI.Core.Samples
{
    /// <summary>
    /// UI class to draw a graph. Instantiates a GraphLine and a GraphLabel for each item in GraphItems.
    /// </summary>
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

        /// <summary> Items to instantiate </summary>
        public List<GraphItemSettings> GraphItems;
        private List<Item> _items;
        
        /// <summary> Parent object for the Labels</summary>
        public Transform Labels;
        /// <summary> Prototype GameObject for a Label</summary>
        public GraphLabel LabelPrototype;
        /// <summary> Parent object for the GraphLines</summary>
        public Transform Lines;
        /// <summary> Prototype GameObject for a GraphLine</summary>
        public GraphLine LinePrototype;

        void Start()
        {
            _items = new List<Item>(GraphItems.Count);
            foreach (GraphItemSettings graphItem in GraphItems)
            {
                AddItem(graphItem);
            }
        }
        
        /// <summary>
        /// Add an item to the graph.
        /// </summary>
        /// <param name="item">A settings object that contains a mixer to read from, a name and colour.</param>
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
        
        /// <summary>
        /// Remove an item from the graph.
        /// </summary>
        /// <param name="item">The settings object to remove</param>
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
