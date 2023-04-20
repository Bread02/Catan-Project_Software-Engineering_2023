using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewTradeManager : MonoBehaviour
{
    /*
     * This script ensures the correct trade type is carried out, depending on the scr
     */

    [Header("Trade Type HUDS")]
    [SerializeField] private GameObject domesticTradeHUD, maritimeTradeHUD, buildHUD;

    private MaritimeTradeManager maritimeTradeMang;
    private DomesticTradeManager domesticTradeMang;
    private BuildTradeManager buildTradeMang;

    private bool tradeStarted;

    private void Start()
    {
        tradeStarted = false;
        maritimeTradeMang = maritimeTradeHUD.GetComponent<MaritimeTradeManager>();
        domesticTradeMang = domesticTradeHUD.GetComponent<DomesticTradeManager>();
        buildTradeMang = buildHUD.GetComponent<BuildTradeManager>();
    }

    /*
     * The method displays the maritimeTrade window.
     * When the player can 'take' at least one card from the bank, the 'confirm' button is displayed.
     */
    public void MaritimeTradeButtonPressed()
    {
        maritimeTradeMang.InitaliseMaritimeTrade();
    }

    public void DomesticTradeButtonPressed()
    {

    }

    public void BuildTradeButtonPressed()
    {

    }
}
