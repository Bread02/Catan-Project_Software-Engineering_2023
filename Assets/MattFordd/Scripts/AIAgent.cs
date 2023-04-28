using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   This is the main script that runs all of the Ai turns.
*
*   @author Matt
*   @version 1.0, 28/04/23
*/ 

public class AIAgent : MonoBehaviour
{

    // All the scripts that the Ai has to access to play.
    [Header("Scripts")]
    private Robber robber;
    private BoardGraph graph;
    private TurnManager turnManager;
    public PlayerManager playerManager;
    public DiceReader yellowDiceReader;
    public DiceReader redDiceReader;
    public TerrainAssigner terrainAssigner;
    private BankManager bankManager;

    //A random variable to generate ints for random choices.
    private System.Random rnd = new System.Random();

    /*
    * The Start menthod which sets up all of the script variables, finding them from game objects in the scene.
    */
    void Start(){
        FindObjects();
    }

    /*
    * Used for robber movements to find which hexes have player settlments.
    */
    private List<GameObject> getHexOptions(){
       
        List<GameObject> hexesToPlay = new List<GameObject>(); 

        //for every vertex (hex), only add the ones that do not already have the robber on. 
        foreach(BoardVertex vertex in graph.verticies){
            if(robber.occupiedHex != vertex.getHexTile()){
                hexesToPlay.Add(vertex.getHexTile());
            }
        }
        return hexesToPlay;
    }

    /*
    * used to find all the avaliable places the AI can build a road
    */
    private List<GameObject> getRoadBuildingOptions(){
        
        List<GameObject> avaliableRoadSpaces = new List<GameObject>();
        
        //goes through all the road spaces on the board and selects only the ones that are next to a player owned settlment or road and are not breaking the gameplay rules.
        for (int i = 0; i < graph.edges.Count; i++){
            GameObject current = graph.edges[i].getRoad();
            bool r1 = false;
            bool r2 = false;
            if(current.GetComponent<ChooseBorder>().playerNumWhoOwnsThisR != 0){
                //check if an adjacent road is owned by the player
                foreach(GameObject road in current.GetComponent<ChooseBorder>().adjacentRoads){
                    if(road.GetComponent<ChooseBorder>().playerNumWhoOwnsThisR == playerManager.playerNumber){
                        r1 = true;
                        break;
                    }
                }

                //check if an adjacent settlement is owned by the player
                foreach(GameObject settlement in current.GetComponent<ChooseBorder>().adjacentSettlements){
                    if(settlement.GetComponent<ChooseSettlement>().playerNumWhoOwnsThisSt == playerManager.playerNumber){
                        r2 = true;
                        break;
                    }
                }
            }

            //if there is a player-owned road or settlement adjacent to this road, then the road can be built.
            if(r1 == true || r2 == true){
                avaliableRoadSpaces.Add(current);
            }
        }
        return avaliableRoadSpaces;
        
    }

    /*
    * used to find all the avaliable places the AI can build a settlment.
    */
    private List<GameObject> getSettlmentBuildingOptions(){
        
        List<GameObject> avaliableSettlementSpaces = new List<GameObject>();
        
        //gets every avaliable settlment place which are not adjacent to any other settlment (abiding by the rules).
        for(int i = 0; i < turnManager.allSettlementBuildSites.Count; i++){
            GameObject current = turnManager.allSettlementBuildSites[i];
            if(current.GetComponent<ChooseSettlement>().playerNumWhoOwnsThisSt == 0){
                List<GameObject> adjacentSettlements = current.GetComponent<ChooseSettlement>().adjacentSettlements;
                bool acceptable = true;
                //if any of the adjacent settlment spaces are owned, the space is not added.
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

    /*
    * used to find all the avaliable places the AI can upgrade to a city (which are any player owned settlments)
    */ 
    private List<GameObject> getCityBuildingOptions(){
        return playerManager.playerOwnedSettlements;
    }

    /*
    *   gets all avaliable actions for the AI to choose from
    */
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

        //check if the AI has any development cards to use, and if it has already used one
        if(turnManager.hasUsedDevCardThisTurn == false){
            if((playerManager.pCardQuantities["knight"] >= 1) || (playerManager.pCardQuantities["monopoly"] >= 1) || (playerManager.pCardQuantities["roadBuilding"] >= 1) || (playerManager.pCardQuantities["yearOfPlenty"] >= 1)){
                options.Add("playDevelopmentCard");
            }
        }

        return options;
    }

    /*
    *   chooses a development card at random to play.
    */
    private string chooseDevelopmentCardToPlay(){
        List<string> avaliableCards = new List<string>();

        if(playerManager.pCardQuantities["monopoly"] >= 1){
            avaliableCards.Add("monopoly");
        }

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

    /*
    *   the main AI turn method
    */
    public void playTurn(){
        //if in the setup phase it will know to go straight to building.
        if(turnManager.isSetUpPhase){
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
            
        } else {
            //if not, it will roll the dice and start its moves
            StartCoroutine(waitUntilDiceRollDone());
        }
        
    }

    /*
    *   Finds all of the script objects in the scene, called in the Start() method
    */
    private void FindObjects(){
        robber = GameObject.Find("Robber").GetComponent<Robber>();
        graph = GameObject.Find("AI_BoardGraph").GetComponent<BoardGraph>();
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        yellowDiceReader = GameObject.Find("YellowDice").GetComponent<DiceReader>();
        redDiceReader = GameObject.Find("RedDice").GetComponent<DiceReader>();
        bankManager = GameObject.Find("THE_BANK").GetComponent<BankManager>();
    }

    /*
    * Waits until the dice are rolled, then plays the move selected at random.
    */
    IEnumerator waitUntilDiceRollDone(){
        //rolling the dice
        yellowDiceReader.RollDice();
        redDiceReader.RollDice();

        //waiting for a result
        yield return new WaitUntil(() => (yellowDiceReader.finishRollingResult == true && redDiceReader.finishRollingResult == true));

        // a safety check to make sure no dice is still moving
        if(yellowDiceReader.finishRollingResult == true && redDiceReader.finishRollingResult == true){
            
            //checking for the robber activation, if it does happen, it will be moved automatically to a new hex using getHexOptions()
            if(yellowDiceReader.RollResult() + redDiceReader.RollResult() == 7){
                List<GameObject> hexOptions = getHexOptions();
                GameObject hexChosen = hexOptions[rnd.Next(hexOptions.Count)]; 
                robber.MoveRobber(hexChosen);
                robber.robberPositionSelected = true;
                robber.TriggerRobberMovementEnd();
            }

            //the list of avaliable actions, initialised using the corresponding method
            List<string> options = getAvaliableActions();            
            
            //if there are no options, it will end the turn, otherwise it plays
            if(options.Count == 0){
                turnManager.EndPlayerTurn();
            } else {
                //selects a random option from the ones given in the options list
                string chosenOption = options[(Random.Range(0, options.Count))];
                
                // reacts differently depending on the option picked.
                switch (chosenOption){
                    case "road":
                        //build road and decrease the materials in the AI hand
                        turnManager.tradeManager.inTradeMode = true;
                        turnManager.isTrading = true;
                        turnManager.makeTrade.SetRoadBought(true);
                        List<GameObject> roadOptions1 = getRoadBuildingOptions();
                        Debug.Log("AVALIABLE ROADS:" + roadOptions1.Count);
                        GameObject roadChosen1 = roadOptions1[rnd.Next(roadOptions1.Count)];
                        roadChosen1.GetComponent<ChooseBorder>().AIBorderPlacment();
                        playerManager.IncOrDecValue("lumber", -1);
                        playerManager.IncOrDecValue("brick", -1);
                        break;
                    case "settlement":
                        // build settlement and decrease the materials in the AI hand
                        turnManager.tradeManager.inTradeMode = true;
                        turnManager.isTrading = true;
                        turnManager.makeTrade.SetSettlementBought(true);
                        List<GameObject> settlementOptions1 = getSettlmentBuildingOptions();
                        GameObject settlmentChosen1 = settlementOptions1[rnd.Next(settlementOptions1.Count)];
                        settlmentChosen1.GetComponent<ChooseSettlement>().AISettlmentPlacment();
                        playerManager.IncOrDecValue("grain", -1);
                        playerManager.IncOrDecValue("wool", -1);
                        playerManager.IncOrDecValue("lumber", -1);
                        playerManager.IncOrDecValue("brick", -1);
                        break;
                    case "city":
                    // upgrade to a city and decrease the materials in the AI hand
                        turnManager.tradeManager.inTradeMode = true;
                        turnManager.isTrading = true;
                        turnManager.makeTrade.SetCityBought(true);
                        List<GameObject> cityOptions = getCityBuildingOptions();
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
                                //play the monopoly card, selecting a random resource to steal
                                bankManager.MonopolyDevCardPlayed();
                                playerManager.IncOrDecValue("monopoly", -1);
                                int chosenMaterial = rnd.Next(5);
                                switch(chosenMaterial){
                                    case 1:
                                        bankManager.StealGrainButtonPressed();
                                        break;
                                    case 2:
                                        bankManager.StealBrickButtonPressed();
                                        break;
                                    case 3:
                                        bankManager.StealLumberButtonPressed();
                                        break;
                                    case 4:
                                        bankManager.StealOreButtonPressed();
                                        break; 
                                    case 5:
                                        bankManager.StealWoolButtonPressed();
                                        break;
                                }
                                break;

                            case "knight":
                                //play knight card, triggering the robber.
                                robber.TriggerRobberMovementKnight();
                                playerManager.IncrementKnightCardUsage();
                                playerManager.IncOrDecValue("knight", -1);
                                break;
                            case "roadBuilding":
                                //play road building... selects and builds 2 roads
                                for(int i = 0; i < 2; i++){
                                    List<GameObject> roadOptions = getSettlmentBuildingOptions();
                                    GameObject roadChosen = roadOptions[rnd.Next(roadOptions.Count)];
                                    roadChosen.GetComponent<ChooseBorder>().AIBorderPlacment();
                                }
                                break;
                            case "yearOfPlenty":
                                //play year of plenty, starting the coroutine in the bank manager
                                StartCoroutine(bankManager.YearOfPlentyDevCardPlayed());
                                break;
                        }
                        break;
                    default:
                        break;
                }

            }

        }
        //returns and ends the coroutine
        yield return null;
    }
}
