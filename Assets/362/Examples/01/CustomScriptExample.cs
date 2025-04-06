using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CPSC386
{
//[AddComponentMenu("Custom/Custom Script Example")]
public class CustomScriptExample : MonoBehaviour
{
    [Tooltip("This vector can be read and changed outside of the class.")]
    public Vector3 publicVector = new Vector3(3,0,0);
    
    //This vector is protected, which means it is not exposed to serialization or outside use
    protected Vector3 protectedVector;

    [Tooltip("This vector is not accessible outside of the class, but can be manipulated and observed through the editor.")]
    [SerializeField]
    protected Vector3 serializedVector = new Vector3(0,3,0);

    [Header("Object Settings")]
    [Space(10)]
    [SerializeField]
    [Tooltip("The default values for the component is based on initialization within the class declaration.")]
    protected Color color = Color.magenta;

    [SerializeField]
    [Range(0.2f, 5f)]
    [Tooltip("Constraints on values can be implemented to control serialization, avoiding scenarios like inappropriate negatives or division by 0. This does not prevent you from going outside of these values within the script.")]
    protected float scale = 1;

    public float zLevel;

    //Using this functionality, we can create editor routines that can be executed on command
    [ContextMenu("Do Something")]
    void Something()
    {
        Debug.Log("Function Executed");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        Vector3 newPos = new Vector3(serializedVector.x, serializedVector.y, zLevel);
        transform.position = newPos;
        GetComponent<SpriteRenderer>().color = color;
        transform.localScale = new Vector3(scale, scale, 1);
    }

    void Awake()
    {
        Debug.Log("Awake");
        //Note: Awake is called before start, meaning the value assigned here will be overwritten
        Vector3 newPos = new Vector3(publicVector.x, publicVector.y, zLevel);
        transform.position = newPos;
    }

    void OnEnable()
    {
        Debug.Log("Enabled");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Updating");
    }
}

}