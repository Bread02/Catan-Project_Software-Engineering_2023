using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : PlayerManager
{

    private Dictionary<string, int> AIResourceAccessibility = new Dictionary<string, int>();

    public Robber robber;
    public TurnManager turnManager;

    // used for robber movements to find which hexes have player settlments
    private List<GameObject> getHexOptions(){
        List<GameObject> hexesToPlay = new List<GameObject>();

        // find hex with the most players (+1 for opponent, -1 for yourself)

        return hexesToPlay;
    }

    // used to find all the avaliable places the AI can build a road
    private List<GameObject> getRoadBuildingOptions(){
        List<GameObject> avaliableRoadSpaces = new List<GameObject>();



        return avaliableRoadSpaces;
    }

    // used to find all the avaliable places the AI can build a settlment
    private List<GameObject> getSettlmentBuildingOptions(){
        List<GameObject> avaliableSettlementSpaces = new List<GameObject>();

        return avaliableSettlementSpaces;
    }

    // used to find all the avaliable places the AI can upgrade to a city
    private List<GameObject> getCityBuildingOptions(){
        return playerOwnedSettlements;
    }

    private float getPercentageOfActiveSettlments(){
        return 0f;
    }

    // gets all avaliable actions for the AI to choose from
    private List<string> getAvaliableActions(){

        List<string> options = new List<string>();

        // check for road resources
        if((pCardQuantities["lumber"] >= 1) && (pCardQuantities["brick"] >= 1)){
            if(playerOwnedRoads.Count < 15){
                options.Add("road");
            }
            // check for settlement resources
            if((pCardQuantities["grain"] >= 1) && (pCardQuantities["wool"] >= 1) && (playerOwnedSettlements.Count < 5)){
                options.Add("settlement");
            }
        }

        //check for city resources
        if((pCardQuantities["grain"] >= 2) && (pCardQuantities["ore"] >= 3) && (playerOwnedSettlements.Count > 0) && (playerOwnedCities.Count < 4)){
            options.Add("city");
        }

        // check for development card resources
        if((pCardQuantities["wool"] >= 1) && (pCardQuantities["grain"] >= 1) && (pCardQuantities["ore"] >= 1)){
            options.Add("buyDevelopmentCard");
        }

        //check if any development cards are avaliable to use

        /*
        * WILL HAVING ALL THE DEVELOPMENT CARDS HAVE A BAD EFFECT ON THE AIs RANDOMNESS?
        */
        if(pCardQuantities["monopoly"] >= 1 || pCardQuantities["knight"] >= 1 || pCardQuantities["roadBuilding"] >= 1 || pCardQuantities["yearOfPlenty"] >= 1){
            options.Add("playDevelopmentCard");
        }


        /*
        *   NOTES:
        *       - check if its possible to do a maritime trade for the cards needed to buy a road / settlement / city / development card
        */

        return options;
    }

    private string chooseDevelopmentCardToPlay(){
        List<string> avaliableCards = new List<string>();
        
        if(pCardQuantities["monopoly"] >= 1){
            avaliableCards.Add("monopoly");
        }

        /*
        * TO ADD: CHECK IF ROBBER AFFECTS THE AI, IF NOT, IT SHOULD NOT MOVE IT.
        */
        if(pCardQuantities["knight"] >= 1){
            avaliableCards.Add("knight");
        }

        if(pCardQuantities["roadBuilding"] >= 1){
            avaliableCards.Add("roadBuilding");
        }

        if(pCardQuantities["yearOfPlenty"] >= 1){
            avaliableCards.Add("yearOfPlenty");
        }

        return avaliableCards[(Random.Range(0, avaliableCards.Count))];
    }

    public void playTurn(){
        //roll dice
        List<string> options = getAvaliableActions();
        
        if(options.Count == 0){
            //end turn?
        } else {
            //selects a random option
            string chosenOption = options[(Random.Range(0, options.Count))];

            switch (chosenOption){
                case "road":
                    //build road
                    break;
                case "settlement":
                    // build settlement
                    break;
                case "city":
                    // build city
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
                            IncrementKnightCardUsage();
                            IncOrDecValue("knight", -1);
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

        /*
        * GIVES A 33% CHANCE THAT THE AI WILL PERFORM ANOTHER ACTION BEFORE ENDING THE TURN (could adjust throughout?)
        */ 
        
    }
}
