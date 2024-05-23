using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class managerslect : MonoBehaviour
{
    public List<GameObject> allUnitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    public LayerMask piso;
    public LayerMask clickeable;
    public LayerMask atacable;
    public GameObject Ondeir;

   public bool Cursoratacar;

    private Camera cam;
    public static managerslect Instance { get; set; }
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {

            Destroy(this.gameObject);

        }

        else
        {

            Instance = this;

        }

    }

    private void Start ()
    {

        cam = Camera.main;
    }

    private void Update() {


        if(Input.GetMouseButton(0)) {


            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickeable)) {

                if(Input.GetKey(KeyCode.LeftShift))
                {
                    multishift(hit.collider.gameObject);
                }
                else
                {
                    if(!Input.GetKey(KeyCode.LeftShift)) {
                        selectrata(hit.collider.gameObject);
                    }
                    
                }
               
            }
            else
            {

                 Deseleccionar();
            }


        } 



        if (Input.GetMouseButton(1) && unitsSelected.Count >0)
        {


            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, piso))
            {

                Ondeir.transform.position = hit.point;
                Ondeir.SetActive(false);
                Ondeir.SetActive(true);
            }


        }

        //atacar
        if (unitsSelected.Count >0 && rataenojada(unitsSelected))
        {


            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, atacable))
            {
                Debug.Log("seleccionaste a este puto ");
                Cursoratacar = true;


                if (Input.GetMouseButton(1))
                {
                    Transform Target = hit.transform;

                    foreach (GameObject units in unitsSelected)
                    {
                        if (units.GetComponent<controlatacar>())
                        {
                            units.GetComponent<controlatacar>().Objetivo=Target;
                        }
                    }

                }
            }
            else
            {
                Cursoratacar = false;

            }


        }

    }

    private bool rataenojada(List<GameObject> unitsSelected)
    {
        foreach (GameObject units in unitsSelected)
        {
            if (units.GetComponent<controlatacar>())
            {
                return true;
            }
            
        }
        return false;
    }


    private void multishift(GameObject gameObject)
    {
       if(unitsSelected.Contains(gameObject)== false)
        {
            unitsSelected.Add(gameObject);
            aquienseleccione(gameObject, true);
            Puedemover(gameObject, true);

        }
        else
        {
            Puedemover(gameObject, false);
            aquienseleccione(gameObject, false);
            unitsSelected.Remove(gameObject);
        }
    }

    private void selectrata(GameObject rataSol)
    {

        Deseleccionar();
        unitsSelected.Add(rataSol);

        aquienseleccione(rataSol, true);
        Puedemover(rataSol,true);

    }

    private void Puedemover(GameObject rataSol, bool memuevo)
    {
        rataSol.GetComponent<movimientorata>().enabled = memuevo;
    }

    public void Deseleccionar()
    {
        foreach(var Ratas in unitsSelected)
        {
            Puedemover(Ratas, false);
            aquienseleccione(Ratas, false);
        }
        Ondeir.SetActive(false);
        unitsSelected.Clear();
    }

   private void  aquienseleccione(GameObject rataSol, bool seleccionado)
    {
        rataSol.transform.GetChild(0).gameObject.SetActive(seleccionado);
    }

    internal void cuadriSelect(GameObject unit)
    {


        
            if (unit.CompareTag("Player") && unitsSelected.Contains(unit)==false )
        {
            unitsSelected.Add(unit);
            aquienseleccione(unit, true);
            Puedemover(unit, true);
    }
    }
}
