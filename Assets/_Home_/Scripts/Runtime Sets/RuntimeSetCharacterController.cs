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
    }

}

