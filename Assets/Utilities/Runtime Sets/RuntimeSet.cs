using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RuntimeSets
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> Items = new List<T>();

        public void Add(T thing)
        {
            if (!Items.Contains(thing))
                Items.Add(thing);
        }

        public void Remove(T thing)
        {
            if (Items.Contains(thing))
                Items.Remove(thing);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public T GetItemAt(int index)
        {
            if (Items.Count <= 0)
            {
                Debug.LogError("There are no elements in the RuntimeSet", this);
                return default(T);
            }
            if (index < 0)
            {
                return Items[Items.Count - 1];
            }
            return Items[index % Items.Count];
        }

        public int IndexOf(T Item)
        {
            return Items.IndexOf(Item);
        }
    }
}