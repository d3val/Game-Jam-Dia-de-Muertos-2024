using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Transform correctDoor;
    //This variable might be changedm for a component that manage dialogues
    [TextArea] public List<string> roomDialoges;
    bool isFirtsTime = true;
}
