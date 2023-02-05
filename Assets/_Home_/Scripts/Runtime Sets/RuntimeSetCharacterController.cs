using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RuntimeSets
{
    [CreateAssetMenu(menuName = "RuntimeSets/CharacterController")]
    public class RuntimeSetCharacterController : RuntimeSet<CharacterController>
    {
        private void OnEnable()
        {
            Clear();
        }


        public new CharacterController GetItemAt(int index)
        {
            if (Items.Count <= 0)
            {
                Debug.LogError("There are no elements in the RuntimeSet", this);
                return null;
            }
            if (index < 0)
            {
                return Items[Items.Count - 1];
            }
            return Items[index % Items.Count];
        }
    }

}

