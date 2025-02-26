using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    private DialogCharacter m_dialogCharacter;

    public DialogCharacter DialogCharacter { get => m_dialogCharacter; set => m_dialogCharacter = value; }
}
