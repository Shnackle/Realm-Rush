using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] //executes in both play and edit mode
public class EnemyDebug : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    TextMeshPro label;
    EnemyHealth health;
    EnemyMover mover;
    Enemy enemy;

    private void Awake()
    {
        label = GetComponentInChildren<TextMeshPro>();
        health = GetComponent<EnemyHealth>();
        mover = GetComponent<EnemyMover>();
        enemy = GetComponent<Enemy>();
        DisplayStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayStats();
        }

        ToggleLabels();
        DisplayStats();
    }
    

    private void DisplayStats()
    {
        label.text = "Health: " + health.CurrHP + "\nSpeed: " + mover.Speed;
        GameObject text = label.gameObject;
    }


    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            label.enabled = !label.enabled;
        }
    }
}
