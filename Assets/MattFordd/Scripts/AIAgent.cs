using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{

    [Header("Scripts")]
    private Robber robber;
    private BoardGraph graph;
    private TurnManager turnManager;
    public PlayerManager playerManager;
    public DiceReader yellowDiceReader;
    public DiceReader redDiceReader;

    private System.Random rnd = new System.Random();


    //private Dictionary<string, int> AIResourceAccessibility = new Dictionary<string, int>();
    List<GameObject> list = new List<GameObject>();


    void Start(){
        FindObjects();
    }

    // used for robber movements to find which hexes have player settlments
    private List<GameObject> getHexOptions(){
       
        
        List<GameObject> hexesToPlay = new List<GameObject>(); 
        
        Dictionary<GameObject, int> hexValues = new Dictionary<GameObject, int>();
        
        int counter = 0;
        // find hex with the most players (+1 for opponent, -1 for yourself)
        foreach(BoardSettlement settlement in graph.settlements){
            Debug.Log(counter);
            counter++;
            if(settlement.getSettlment().GetComponent<ChooseSettlement>().settlementTaken == true){
                foreach(BoardVertex v in settlement.getHexObjects()){
                    if((v != null) && (v.getHexTile() != robber.occupiedHex)){
                        Debug.Log("TEST: " + settlement.getSettlment().GetComponent<ChooseSettlement>());
                        if(settlement.GetComponent<ChooseSettlement>() != null && playerManager.playerNumber != null){
                            Debug.Log("HERE");
                            if(settlement.getSettlment().GetComponent<ChooseSettlement>().playerClaimedBy != playerManager.playerNumber){
                                Debug.Log("PLUS");
                                hexValues[v.getHexTile()] += 1;
                            } else {
                                Debug.Log("MINUS");
                                hexValues[v.getHexTile()] += -1;
                            }
                        }
                    }
                }
            }
            
        }

        foreach(KeyValuePair<GameObject, int> entry in hexValues){
            if(entry.Value > 0){
                hexesToPlay.Add(entry.Key);
            }
        }

        //sort the list for best solution
        
        return hexesToPlay;
    }

    // used to find all the avaliable places the AI can build a road
    private List<GameObject> getRoadBuildingOptions(){
        
        List<GameObject> avaliableRoadSpaces = new List<GameObject>();
        
        if(turnManager.isSetUpPhase){
            
            for (int i = 0; i < turnManager.allRoadBuildSites.Count; i++){
                GameObject current = turnManager.allRoadBuildSites[i];
                bool acceptable = true;
                Debug.Log(current.GetComponent<ChooseBorder>().adjacentSettlements.Count);
                foreach(GameObject s in current.GetComponent<ChooseBorder>().adjacentSettlements){
                    
                    if(s.GetComponent<ChooseSettlement>().playerClaimedBy != 0){
                        acceptable = false;
                        break;
                    }
                }
                
                if(acceptable){
                    avaliableRoadSpaces.Add(current);
                }

            }
        } else {
            for (int i = 0; i < graph.edges.Count; i++){
                GameObject current = graph.edges[i].getRoad();
                bool r1 = false;
                bool r2 = false;
                if(current.GetComponent<ChooseBorder>().playerClaimedBy != 0){
                    //check if an adjacent road is owned by the player
                    foreach(GameObject road in current.GetComponent<ChooseBorder>().adjacentRoads){
                        if(road.GetComponent<ChooseBorder>().playerClaimedBy == playerManager.playerNumber){
                            r1 = true;
                            break;
                        }
                    }

                    //check if an adjacent settlement is owned by the player
                    foreach(GameObject settlement in current.GetComponent<ChooseBorder>().adjacentSettlements){
                        if(settlement.GetComponent<ChooseSettlement>().playerClaimedBy == playerManager.playerNumber){
                            r2 = true;
                            break;
                        }
                    }
                }
                Debug.Log("ROAD BUILDING");
                //if there is a player-owned road or settlement adjacent to this road, then the road can be built.
                if(r1 == true || r2 == true){
                    avaliableRoadSpaces.Add(current);
                }
            }
        }
        return avaliableRoadSpaces;
        
    }

    // used to find all the avaliable places the AI can build a settlment
    private List<GameObject> getSettlmentBuildingOptions(){
        
        List<GameObject> avaliableSettlementSpaces = new List<GameObject>();
        
        for(int i = 0; i < turnManager.allSettlementBuildSites.Count; i++){
            GameObject current = turnManager.allSettlementBuildSites[i];
            if(current.GetComponent<ChooseSettlement>().playerClaimedBy == 0){
                List<GameObject> adjacentSettlements = current.GetComponent<ChooseSettlement>().adjacentSettlements;
                bool acceptable = true;
                foreach(GameObject adjSettlement in adjacentSettlements){
                    if(adjSettlement.GetComponent<ChooseSettlement>().settlementTaken == true){
                        acceptable = false;
                        break;
                    }
                }

                if(acceptable){
                    avaliableSettlementSpaces.Add(current);
                }
            }
        }
        
        return avaliableSettlementSpaces;
    }

    // used to find all the avaliable places the AI can upgrade to a city
    private List<GameObject> getCityBuildingOptions(){
        return playerManager.playerOwnedSettlements;
    }

    private float getPercentageOfActiveSettlments(){
        return 0f;
    }

    // gets all avaliable actions for the AI to choose from
    private List<string> getAvaliableActions(){

        List<string> options = new List<string>();
        // check for road resources
        if((playerManager.pCardQuantities["lumber"] >= 1) && (playerManager.pCardQuantities["brick"] >= 1)){
            if(playerManager.playerOwnedRoads.Count < 15){
                options.Add("road");
            }
            // check for settlement resources
            if((playerManager.pCardQuantities["grain"] >= 1) && (playerManager.pCardQuantities["wool"] >= 1) && (playerManager.playerOwnedSettlements.Count < 5)){
                options.Add("settlement");
            }
        }

        //check for city resources
        if((playerManager.pCardQuantities["grain"] >= 2) && (playerManager.pCardQuantities["ore"] >= 3) && (playerManager.playerOwnedSettlements.Count > 0) && (playerManager.playerOwnedCities.Count < 4)){
            options.Add("city");
        }

        // check for development card resources
        if((playerManager.pCardQuantities["wool"] >= 1) && (playerManager.pCardQuantities["grain"] >= 1) && (playerManager.pCardQuantities["ore"] >= 1)){
            options.Add("buyDevelopmentCard");
        }

        //check if any development cards are avaliable to use

        /*
        * WILL HAVING ALL THE DEVELOPMENT CARDS HAVE A BAD EFFECT ON THE AIs RANDOMNESS?
        */
        //use bool to chjeck if its already played one.


        /*
        *   NOTES:
        *       - check if its possible to do a maritime trade for the cards needed to buy a road / settlement / city / development card
        */

        return options;
    }

    private string chooseDevelopmentCardToPlay(){
        List<string> avaliableCards = new List<string>();

        if(playerManager.pCardQuantities["monopoly"] >= 1){
            avaliableCards.Add("monopoly");
        }

        /*
        * TO ADD: CHECK IF ROBBER AFFECTS THE AI, IF NOT, IT SHOULD NOT MOVE IT.
        */

        if(playerManager.pCardQuantities["knight"] >= 1){
            avaliableCards.Add("knight");
        }

        if(playerManager.pCardQuantities["roadBuilding"] >= 1){
            avaliableCards.Add("roadBuilding");
        }

        if(playerManager.pCardQuantities["yearOfPlenty"] >= 1){
            avaliableCards.Add("yearOfPlenty");
        }

        return avaliableCards[(Random.Range(0, avaliableCards.Count))];
    }

    public void playTurn(){
        //roll dice
        Debug.Log("AI Playing...");

        if(turnManager.isSetUpPhase){
            Debug.Log("AI Setup Building...");

            //Build a settlement
            List<GameObject> settlments = getSettlmentBuildingOptions();
            Debug.Log(settlments.Count);
            GameObject settlmentChosen = settlments[rnd.Next(settlments.Count)];
            settlmentChosen.GetComponent<ChooseSettlement>().AISettlmentPlacment();

            //Build a road
            List<GameObject> roads = settlmentChosen.GetComponent<ChooseSettlement>().adjacentRoads;
            GameObject roadChosen = roads[rnd.Next(roads.Count)];
            roadChosen.GetComponent<ChooseBorder>().AIBorderPlacment();
            Debug.Log("ROAD: " + roadChosen + " | SETTLEMENT: " + settlmentChosen);
            
            //turnManager.EndPlayerTurn();
            
        } else {
            yellowDiceReader.RollDice();
            redDiceReader.RollDice();
        
            List<string> options = getAvaliableActions();
            string chosenOption = options[(Random.Range(0, options.Count))];

            Debug.Log("Option: " + chosenOption);
        
            if(options.Count == 0){
                //end turn?
            } else {
                //selects a random option
                switch (chosenOption){
                    case "road":
                        //build road
                        List<GameObject> roadOptions = getSettlmentBuildingOptions();
                        GameObject roadChosen = roadOptions[rnd.Next(roadOptions.Count)];
                        roadChosen.GetComponent<ChooseBorder>().AIBorderPlacment();
                        break;
                    case "settlement":
                        // build settlement
                        List<GameObject> settlementOptions = getSettlmentBuildingOptions();
                        GameObject settlmentChosen = settlementOptions[rnd.Next(settlementOptions.Count)];
                        settlmentChosen.GetComponent<ChooseSettlement>().AISettlmentPlacment();
                        break;
                    case "city":
                        List<GameObject> cityOptions;
                        cityOptions = getCityBuildingOptions();
                        GameObject cityChoice = cityOptions[Random.Range(0, cityOptions.Count -1)];
                        cityChoice.GetComponent<ChooseSettlement>().ChangeToCity();
                        playerManager.IncOrDecValue("grain", -2);
                        playerManager.IncOrDecValue("ore", -3);
                        break;
                    case "buyDevelopmentCard":
                        // buy development card
                    case "playDevelopmentCard":
                        //play specific card
                        switch (chooseDevelopmentCardToPlay()){
                            case "monopoly":
                                //play monopoly
                                break;
                            case "knight":
                                //play knight card
                                robber.TriggerRobberMovementKnight();
                                playerManager.IncrementKnightCardUsage();
                                playerManager.IncOrDecValue("knight", -1);
                                break;
                            case "roadBuilding":
                                //play road building
                                break;
                            case "yearOfPlenty":
                                //play year of plenty
                                break;
                        }
                        break;
                    default:
                        break;
                }

            }
        }
        
        
        /*
        * GIVES A 33% CHANCE THAT THE AI WILL PERFORM ANOTHER ACTION BEFORE ENDING THE TURN (could adjust throughout?)
        */ 
        
    }

    private void FindObjects(){
        robber = GameObject.Find("Robber").GetComponent<Robber>();
        graph = GameObject.Find("AI_BoardGraph").GetComponent<BoardGraph>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        yellowDiceReader = GameObject.Find("YellowDice").GetComponent<DiceReader>();
        redDiceReader = GameObject.Find("RedDice").GetComponent<DiceReader>();
    }
}
