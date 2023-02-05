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

        public T RemoveItemAt(int index)
        {
            if (Items.Count <= 0)
            {
                Debug.LogError("There are no elements in the RuntimeSet", this);
                return default(T);
            }
            if (index > Items.Count)
            {
                Debug.LogError("Index " + index + " is too big for the RuntimeSet", this);
                return default(T);
            }
            if (index < 0)
            {
                Debug.LogError("Index " + index + " is too small for the RuntimeSet", this);
                return default(T);
            }
            T removedItem = Items[index];
            Items.RemoveAt(index);
            return removedItem;
        }

        public T RemoveFirst()
        {
            return RemoveItemAt(0);
        }

        public int IndexOf(T Item)
        {
            return Items.IndexOf(Item);
        }
    }
}