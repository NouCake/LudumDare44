using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatMatrixController : MonoBehaviour {

    public CharController ToDisplay;

    private TextMeshProUGUI PhysAtk;
    private TextMeshProUGUI PoisAtk;
    private TextMeshProUGUI FireAtk;
    private TextMeshProUGUI PhyDef;
    private TextMeshProUGUI PoisDef;
    private TextMeshProUGUI FireDef;

    void Start() {

        GameObject line = transform.Find("Matrix").Find("MatrixContent").Find("Line 1").gameObject;
        PhysAtk = line.transform.Find("1x1").GetComponentInChildren<TextMeshProUGUI>();
        PoisAtk = line.transform.Find("2x1").GetComponentInChildren<TextMeshProUGUI>();
        FireAtk = line.transform.Find("3x1").GetComponentInChildren<TextMeshProUGUI>();

        line = transform.Find("Matrix").Find("MatrixContent").Find("Line 2").gameObject;
        PhyDef = line.transform.Find("1x1").GetComponentInChildren<TextMeshProUGUI>();
        PoisDef = line.transform.Find("2x1").GetComponentInChildren<TextMeshProUGUI>();
        FireDef = line.transform.Find("3x1").GetComponentInChildren<TextMeshProUGUI>();

        updateStats();
    }

    public void updateStats() {
        PhysAtk.text = ""+ToDisplay.TotalStats.physicalStrength;
        PoisAtk.text = "" + ToDisplay.TotalStats.poisonStrength;
        FireAtk.text = "" + ToDisplay.TotalStats.fireStrength;

        PhyDef.text = "" + ToDisplay.TotalStats.physicalResistance;
        PoisDef.text = "" + ToDisplay.TotalStats.poisonResistance;
        FireDef.text = "" + ToDisplay.TotalStats.fireResistance;
    }

    // Update is called once per frame
    void Update()
    {
        updateStats();

    }

}
