using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject gancho;
    private GameObject auxgancho;

    public Camera m_camera;

    public Transform dirDoclique;
    private Transform auxDirDoClipque;

    private Vector3 localDoClique;
    private Vector3 posMouse;
    private Quaternion olharParaDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posMouse = Input.mousePosition;
        posMouse.z = Vector3.Distance(m_camera.transform.position, transform.position);
        posMouse = m_camera.ScreenToViewportPoint(posMouse);

        if(auxgancho == null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                auxDirDoClipque = Instantiate(dirDoclique, posMouse, Quaternion.identity) as Transform;
                localDoClique = (auxDirDoClipque.transform.position - transform.position).normalized;
                olharParaDir = Quaternion.LookRotation(localDoClique);

                auxgancho = Instantiate(gancho, transform.position, olharParaDir) as GameObject;
                Destroy(auxDirDoClipque.gameObject);
            }
        }
    }
}
