using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private UIInventory _inventoryMenu;
    [SerializeField] private GameObject _uiInventory;
    private                  InventoryManager _inventoryManager;
    private                  EquipmentManager _equipmentManager;
    private                  Character _character;

    public static int budget = 50;
    
    public PlayerHealth health;
    public Animator animator;


    void Awake() {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        health = GetComponent<PlayerHealth>();    
    }


    void Start() {
        _character = FindObjectOfType(typeof(Character)) as Character; 

        _uiInventory.SetActive(true);
        _inventoryManager = new InventoryManager();
        _equipmentManager = new EquipmentManager();
        _inventoryMenu.SetInventory(_inventoryManager);
        _uiInventory.SetActive(false);

        SetCharacter(ChooseCharacter.characterType);

    }


    void Update() {
        ReadInstruction();
    }


    void SetCharacter(Character.Type characterType) {
        animator.runtimeAnimatorController = _character.GetAnimatorController(characterType);

        GetComponent<BoxCollider2D>().size = _character.GetBoxColliderSize(characterType);
        GetComponent<BoxCollider2D>().offset = _character.GetBoxColliderOffset(characterType);
        
        // characterType = Character.Type.Ninja;
        GetComponent<Transform>().localScale = _character.GetLocalScale(characterType);
    }


    void ReadInstruction() {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2d.position,
        transform.TransformDirection(Vector3.forward), 1.5f, LayerMask.GetMask("Instruction"));
       
        if (hit.collider != null) {
            Instruction instruction = hit.collider.GetComponent<Instruction>();
            
            if (instruction != null) {
                instruction.DisplayDialog();
            }
        }
    }
}
