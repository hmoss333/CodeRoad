using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {   

    //Latest Score
    public static void setLatestScore(int playerIndex, int score)
    {
        if (playerIndex == 0) { PlayerPrefs.SetInt("PlayerScore0", score); }
        if (playerIndex == 1) { PlayerPrefs.SetInt("PlayerScore1", score); }
        if (playerIndex == 2) { PlayerPrefs.SetInt("PlayerScore2", score); }
        if (playerIndex == 3) { PlayerPrefs.SetInt("PlayerScore3", score); }
        if (playerIndex == 4) { PlayerPrefs.SetInt("PlayerScore4", score); }
        if (playerIndex == 5) { PlayerPrefs.SetInt("PlayerScore5", score); }
        if (playerIndex == 6) { PlayerPrefs.SetInt("PlayerScore6", score); }
        if (playerIndex == 7) { PlayerPrefs.SetInt("PlayerScore7", score); }
        if (playerIndex == 8) { PlayerPrefs.SetInt("PlayerScore8", score); }
        if (playerIndex == 9) { PlayerPrefs.SetInt("PlayerScore9", score); }
    }

    public static int getLatestScore(int playerIndex)
    {
        int answer = 0;

        if (playerIndex == 0) { answer = PlayerPrefs.GetInt("PlayerScore0"); }
        if (playerIndex == 1) { answer = PlayerPrefs.GetInt("PlayerScore1"); }
        if (playerIndex == 2) { answer = PlayerPrefs.GetInt("PlayerScore2"); }
        if (playerIndex == 3) { answer = PlayerPrefs.GetInt("PlayerScore3"); }
        if (playerIndex == 4) { answer = PlayerPrefs.GetInt("PlayerScore4"); }
        if (playerIndex == 5) { answer = PlayerPrefs.GetInt("PlayerScore5"); }
        if (playerIndex == 6) { answer = PlayerPrefs.GetInt("PlayerScore6"); }
        if (playerIndex == 7) { answer = PlayerPrefs.GetInt("PlayerScore7"); }
        if (playerIndex == 8) { answer = PlayerPrefs.GetInt("PlayerScore8"); }
        if (playerIndex == 9) { answer = PlayerPrefs.GetInt("PlayerScore9"); }

        return answer;
    }

    //Longest Streak
    public static void setLongestStreak(int playerIndex, int score)
    {
        if (playerIndex == 0) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak0", score); } }
        if (playerIndex == 1) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak1", score); } }
        if (playerIndex == 2) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak2", score); } }
        if (playerIndex == 3) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak3", score); } }
        if (playerIndex == 4) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak4", score); } }
        if (playerIndex == 5) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak5", score); } }
        if (playerIndex == 6) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak6", score); } }
        if (playerIndex == 7) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak7", score); } }
        if (playerIndex == 8) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak8", score); } }
        if (playerIndex == 9) { if (score > getLongestStreak(playerIndex)) { PlayerPrefs.SetInt("PlayerStreak9", score); } }
    }

    public static int getLongestStreak(int playerIndex)
    {
        int answer = 0;

        if (playerIndex == 0) { answer = PlayerPrefs.GetInt("PlayerStreak0"); }
        if (playerIndex == 1) { answer = PlayerPrefs.GetInt("PlayerStreak1"); }
        if (playerIndex == 2) { answer = PlayerPrefs.GetInt("PlayerStreak2"); }
        if (playerIndex == 3) { answer = PlayerPrefs.GetInt("PlayerStreak3"); }
        if (playerIndex == 4) { answer = PlayerPrefs.GetInt("PlayerStreak4"); }
        if (playerIndex == 5) { answer = PlayerPrefs.GetInt("PlayerStreak5"); }
        if (playerIndex == 6) { answer = PlayerPrefs.GetInt("PlayerStreak6"); }
        if (playerIndex == 7) { answer = PlayerPrefs.GetInt("PlayerStreak7"); }
        if (playerIndex == 8) { answer = PlayerPrefs.GetInt("PlayerStreak8"); }
        if (playerIndex == 9) { answer = PlayerPrefs.GetInt("PlayerStreak9"); }

        return answer;
    }

    public static void setPerformance(int playerIndex, int correct, int incorrect, string time)
    {
        if (playerIndex == 0) { set0(correct, incorrect, time); }
        if (playerIndex == 1) { set1(correct, incorrect, time); }
        if (playerIndex == 2) { set2(correct, incorrect, time); }
        if (playerIndex == 3) { set3(correct, incorrect, time); }
        if (playerIndex == 4) { set4(correct, incorrect, time); }
        if (playerIndex == 5) { set5(correct, incorrect, time); }
        if (playerIndex == 6) { set6(correct, incorrect, time); }
        if (playerIndex == 7) { set7(correct, incorrect, time); }
        if (playerIndex == 8) { set8(correct, incorrect, time); }
        if (playerIndex == 9) { set9(correct, incorrect, time); }
    }

    public static void set0(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter0") == 0) { PlayerPrefs.SetInt("PlayerPerformance0",  correct); PlayerPrefs.SetInt("PlayerPerformance0B", incorrect);  PlayerPrefs.SetString("Player0Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter0") == 1) { PlayerPrefs.SetInt("PlayerPerformance01", correct); PlayerPrefs.SetInt("PlayerPerformance01B", incorrect); PlayerPrefs.SetString("Player01Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter0") == 2) { PlayerPrefs.SetInt("PlayerPerformance02", correct); PlayerPrefs.SetInt("PlayerPerformance02B", incorrect); PlayerPrefs.SetString("Player02Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter0") == 3) { PlayerPrefs.SetInt("PlayerPerformance03", correct); PlayerPrefs.SetInt("PlayerPerformance03B", incorrect); PlayerPrefs.SetString("Player03Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter0") == 4) { PlayerPrefs.SetInt("PlayerPerformance04", correct); PlayerPrefs.SetInt("PlayerPerformance04B", incorrect); PlayerPrefs.SetString("Player04Time", time); }

        PlayerPrefs.SetInt("PlayerCounter0", PlayerPrefs.GetInt("PlayerCounter0") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter0") > 4) { PlayerPrefs.SetInt("PlayerCounter0", 0); }   
    }
    

    public static void set1(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter1") == 0) { PlayerPrefs.SetInt("PlayerPerformance1", correct); PlayerPrefs.SetInt("PlayerPerformance1B", incorrect);   PlayerPrefs.SetString("Player1Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter1") == 1) { PlayerPrefs.SetInt("PlayerPerformance11", correct); PlayerPrefs.SetInt("PlayerPerformance11B", incorrect); PlayerPrefs.SetString("Player11Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter1") == 2) { PlayerPrefs.SetInt("PlayerPerformance12", correct); PlayerPrefs.SetInt("PlayerPerformance12B", incorrect); PlayerPrefs.SetString("Player12Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter1") == 3) { PlayerPrefs.SetInt("PlayerPerformance13", correct); PlayerPrefs.SetInt("PlayerPerformance13B", incorrect); PlayerPrefs.SetString("Player13Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter1") == 4) { PlayerPrefs.SetInt("PlayerPerformance14", correct); PlayerPrefs.SetInt("PlayerPerformance14B", incorrect); PlayerPrefs.SetString("Player14Time", time); }

        PlayerPrefs.SetInt("PlayerCounter1", PlayerPrefs.GetInt("PlayerCounter1") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter1") > 4) { PlayerPrefs.SetInt("PlayerCounter1", 0); }
    }

    public static void set2(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter2") == 0) { PlayerPrefs.SetInt("PlayerPerformance2", correct); PlayerPrefs.SetInt("PlayerPerformance2B", incorrect);   PlayerPrefs.SetString("Player2Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter2") == 1) { PlayerPrefs.SetInt("PlayerPerformance21", correct); PlayerPrefs.SetInt("PlayerPerformance21B", incorrect); PlayerPrefs.SetString("Player21Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter2") == 2) { PlayerPrefs.SetInt("PlayerPerformance22", correct); PlayerPrefs.SetInt("PlayerPerformance22B", incorrect); PlayerPrefs.SetString("Player22Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter2") == 3) { PlayerPrefs.SetInt("PlayerPerformance23", correct); PlayerPrefs.SetInt("PlayerPerformance23B", incorrect); PlayerPrefs.SetString("Player23Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter2") == 4) { PlayerPrefs.SetInt("PlayerPerformance24", correct); PlayerPrefs.SetInt("PlayerPerformance24B", incorrect); PlayerPrefs.SetString("Player24Time", time); }

        PlayerPrefs.SetInt("PlayerCounter2", PlayerPrefs.GetInt("PlayerCounter2") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter2") > 4) { PlayerPrefs.SetInt("PlayerCounter2", 0); }
    }

    public static void set3(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter3") == 0) { PlayerPrefs.SetInt("PlayerPerformance3", correct); PlayerPrefs.SetInt("PlayerPerformance3B", incorrect);   PlayerPrefs.SetString("Player3Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter3") == 1) { PlayerPrefs.SetInt("PlayerPerformance31", correct); PlayerPrefs.SetInt("PlayerPerformance31B", incorrect); PlayerPrefs.SetString("Player31Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter3") == 2) { PlayerPrefs.SetInt("PlayerPerformance32", correct); PlayerPrefs.SetInt("PlayerPerformance32B", incorrect); PlayerPrefs.SetString("Player32Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter3") == 3) { PlayerPrefs.SetInt("PlayerPerformance33", correct); PlayerPrefs.SetInt("PlayerPerformance33B", incorrect); PlayerPrefs.SetString("Player33Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter3") == 4) { PlayerPrefs.SetInt("PlayerPerformance34", correct); PlayerPrefs.SetInt("PlayerPerformance34B", incorrect); PlayerPrefs.SetString("Player34Time", time); }

        PlayerPrefs.SetInt("PlayerCounter3", PlayerPrefs.GetInt("PlayerCounter3") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter3") > 4) { PlayerPrefs.SetInt("PlayerCounter3", 0); }
    }

    public static void set4(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter4") == 0) { PlayerPrefs.SetInt("PlayerPerformance4", correct); PlayerPrefs.SetInt("PlayerPerformance4B", incorrect);   PlayerPrefs.SetString("Player4Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter4") == 1) { PlayerPrefs.SetInt("PlayerPerformance41", correct); PlayerPrefs.SetInt("PlayerPerformance41B", incorrect); PlayerPrefs.SetString("Player41Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter4") == 2) { PlayerPrefs.SetInt("PlayerPerformance42", correct); PlayerPrefs.SetInt("PlayerPerformance42B", incorrect); PlayerPrefs.SetString("Player42Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter4") == 3) { PlayerPrefs.SetInt("PlayerPerformance43", correct); PlayerPrefs.SetInt("PlayerPerformance43B", incorrect); PlayerPrefs.SetString("Player43Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter4") == 4) { PlayerPrefs.SetInt("PlayerPerformance44", correct); PlayerPrefs.SetInt("PlayerPerformance44B", incorrect); PlayerPrefs.SetString("Player44Time", time); }

        PlayerPrefs.SetInt("PlayerCounter4", PlayerPrefs.GetInt("PlayerCounter4") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter4") > 4) { PlayerPrefs.SetInt("PlayerCounter4", 0); }
    }

    public static void set5(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter5") == 0) { PlayerPrefs.SetInt("PlayerPerformance5", correct); PlayerPrefs.SetInt("PlayerPerformance5B", incorrect);   PlayerPrefs.SetString("Player5Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter5") == 1) { PlayerPrefs.SetInt("PlayerPerformance51", correct); PlayerPrefs.SetInt("PlayerPerformance51B", incorrect); PlayerPrefs.SetString("Player51Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter5") == 2) { PlayerPrefs.SetInt("PlayerPerformance52", correct); PlayerPrefs.SetInt("PlayerPerformance52B", incorrect); PlayerPrefs.SetString("Player52Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter5") == 3) { PlayerPrefs.SetInt("PlayerPerformance53", correct); PlayerPrefs.SetInt("PlayerPerformance53B", incorrect); PlayerPrefs.SetString("Player53Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter5") == 4) { PlayerPrefs.SetInt("PlayerPerformance54", correct); PlayerPrefs.SetInt("PlayerPerformance54B", incorrect); PlayerPrefs.SetString("Player54Time", time); }

        PlayerPrefs.SetInt("PlayerCounter5", PlayerPrefs.GetInt("PlayerCounter5") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter5") > 4) { PlayerPrefs.SetInt("PlayerCounter5", 0); }
    }

    public static void set6(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter6") == 0) { PlayerPrefs.SetInt("PlayerPerformance6", correct); PlayerPrefs.SetInt("PlayerPerformance6B", incorrect);   PlayerPrefs.SetString("Player6Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter6") == 1) { PlayerPrefs.SetInt("PlayerPerformance61", correct); PlayerPrefs.SetInt("PlayerPerformance61B", incorrect); PlayerPrefs.SetString("Player61Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter6") == 2) { PlayerPrefs.SetInt("PlayerPerformance62", correct); PlayerPrefs.SetInt("PlayerPerformance62B", incorrect); PlayerPrefs.SetString("Player62Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter6") == 3) { PlayerPrefs.SetInt("PlayerPerformance63", correct); PlayerPrefs.SetInt("PlayerPerformance63B", incorrect); PlayerPrefs.SetString("Player63Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter6") == 4) { PlayerPrefs.SetInt("PlayerPerformance64", correct); PlayerPrefs.SetInt("PlayerPerformance64B", incorrect); PlayerPrefs.SetString("Player64Time", time); }

        PlayerPrefs.SetInt("PlayerCounter6", PlayerPrefs.GetInt("PlayerCounter6") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter6") > 4) { PlayerPrefs.SetInt("PlayerCounter6", 0); }
    }

    public static void set7(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter7") == 0) { PlayerPrefs.SetInt("PlayerPerformance7", correct); PlayerPrefs.SetInt("PlayerPerformance7B", incorrect);   PlayerPrefs.SetString("Player7Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter7") == 1) { PlayerPrefs.SetInt("PlayerPerformance71", correct); PlayerPrefs.SetInt("PlayerPerformance71B", incorrect); PlayerPrefs.SetString("Player71Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter7") == 2) { PlayerPrefs.SetInt("PlayerPerformance72", correct); PlayerPrefs.SetInt("PlayerPerformance72B", incorrect); PlayerPrefs.SetString("Player72Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter7") == 3) { PlayerPrefs.SetInt("PlayerPerformance73", correct); PlayerPrefs.SetInt("PlayerPerformance73B", incorrect); PlayerPrefs.SetString("Player73Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter7") == 4) { PlayerPrefs.SetInt("PlayerPerformance74", correct); PlayerPrefs.SetInt("PlayerPerformance74B", incorrect); PlayerPrefs.SetString("Player74Time", time); }

        PlayerPrefs.SetInt("PlayerCounter7", PlayerPrefs.GetInt("PlayerCounter7") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter7") > 4) { PlayerPrefs.SetInt("PlayerCounter7", 0); }
    }

    public static void set8(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter8") == 0) { PlayerPrefs.SetInt("PlayerPerformance8", correct); PlayerPrefs.SetInt("PlayerPerformance8B", incorrect);   PlayerPrefs.SetString("Player8Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter8") == 1) { PlayerPrefs.SetInt("PlayerPerformance81", correct); PlayerPrefs.SetInt("PlayerPerformance81B", incorrect); PlayerPrefs.SetString("Player81Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter8") == 2) { PlayerPrefs.SetInt("PlayerPerformance82", correct); PlayerPrefs.SetInt("PlayerPerformance82B", incorrect); PlayerPrefs.SetString("Player82Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter8") == 3) { PlayerPrefs.SetInt("PlayerPerformance83", correct); PlayerPrefs.SetInt("PlayerPerformance83B", incorrect); PlayerPrefs.SetString("Player83Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter8") == 4) { PlayerPrefs.SetInt("PlayerPerformance84", correct); PlayerPrefs.SetInt("PlayerPerformance84B", incorrect); PlayerPrefs.SetString("Player84Time", time); }

        PlayerPrefs.SetInt("PlayerCounter8", PlayerPrefs.GetInt("PlayerCounter8") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter8") > 4) { PlayerPrefs.SetInt("PlayerCounter8", 0); }
    }

    public static void set9(int correct, int incorrect, string time)
    {
        if (PlayerPrefs.GetInt("PlayerCounter9") == 0) { PlayerPrefs.SetInt("PlayerPerformance9", correct); PlayerPrefs.SetInt("PlayerPerformance9B", incorrect);   PlayerPrefs.SetString("Player9Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter9") == 1) { PlayerPrefs.SetInt("PlayerPerformance91", correct); PlayerPrefs.SetInt("PlayerPerformance91B", incorrect); PlayerPrefs.SetString("Player91Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter9") == 2) { PlayerPrefs.SetInt("PlayerPerformance92", correct); PlayerPrefs.SetInt("PlayerPerformance92B", incorrect); PlayerPrefs.SetString("Player92Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter9") == 3) { PlayerPrefs.SetInt("PlayerPerformance93", correct); PlayerPrefs.SetInt("PlayerPerformance93B", incorrect); PlayerPrefs.SetString("Player93Time", time); }
        if (PlayerPrefs.GetInt("PlayerCounter9") == 4) { PlayerPrefs.SetInt("PlayerPerformance94", correct); PlayerPrefs.SetInt("PlayerPerformance94B", incorrect); PlayerPrefs.SetString("Player94Time", time); }

        PlayerPrefs.SetInt("PlayerCounter9", PlayerPrefs.GetInt("PlayerCounter9") + 1);

        if (PlayerPrefs.GetInt("PlayerCounter9") > 4) { PlayerPrefs.SetInt("PlayerCounter9", 0); }
    }

    //Clears all of the player performance data so that it can be loaded 
    //from the database
    public static void clearPerformanceData()
    {
        //Clears performance data
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                if(j == 0)
                {
                    PlayerPrefs.SetInt("PlayerPerformance" + i.ToString(), 0);
                    PlayerPrefs.SetInt("PlayerPerformance" + i.ToString() + "B", 0);
                    PlayerPrefs.SetString("Player" + i.ToString() + "Time", ""); 
                } else {
                    PlayerPrefs.SetInt("PlayerPerformance" + i.ToString() + j.ToString(), 0);
                    PlayerPrefs.SetInt("PlayerPerformance" + i.ToString() + j.ToString() + "B", 0);
                    PlayerPrefs.SetString("Player" + i.ToString() + j.ToString() + "Time", "");
                }
            }

        }

        //Used to remove the high scores of the currently logged in user
        PlayerPrefs.SetInt("firstPlace", 0);
        PlayerPrefs.SetInt("secondPlace", 0);
        PlayerPrefs.SetInt("thirdPlace", 0);
        PlayerPrefs.SetInt("fourthPlace", 0);
        PlayerPrefs.SetInt("fifthPlace", 0);
        PlayerPrefs.SetInt("sixthPlace", 0);
        PlayerPrefs.SetInt("seventhPlace", 0);
        PlayerPrefs.SetInt("eighthPlace", 0);
        PlayerPrefs.SetInt("ninthPlace", 0);
        PlayerPrefs.SetInt("tenthPlace", 0);

        PlayerPrefs.SetString("firstName", "");
        PlayerPrefs.SetString("secondName", "");
        PlayerPrefs.SetString("thirdName", "");
        PlayerPrefs.SetString("fourthName", "");
        PlayerPrefs.SetString("fifthName", "");
        PlayerPrefs.SetString("sixthName", "");
        PlayerPrefs.SetString("seventhName", "");
        PlayerPrefs.SetString("eighthName", "");
        PlayerPrefs.SetString("ninethName", "");
        PlayerPrefs.SetString("tenthName", "");
    }

    /*
    //Time Played
    public static void setTimePlayed(int playerIndex, int score)
    {
        if (playerIndex == 0) { PlayerPrefs.SetInt("PlayerTime0", score + PlayerPrefs.GetInt("PlayerTime0")); }
        if (playerIndex == 1) { PlayerPrefs.SetInt("PlayerTime1", score + PlayerPrefs.GetInt("PlayerTime1")); }
        if (playerIndex == 2) { PlayerPrefs.SetInt("PlayerTime2", score + PlayerPrefs.GetInt("PlayerTime2")); }
        if (playerIndex == 3) { PlayerPrefs.SetInt("PlayerTime3", score + PlayerPrefs.GetInt("PlayerTime3")); }
        if (playerIndex == 4) { PlayerPrefs.SetInt("PlayerTime4", score + PlayerPrefs.GetInt("PlayerTime4")); }
        if (playerIndex == 5) { PlayerPrefs.SetInt("PlayerTime5", score + PlayerPrefs.GetInt("PlayerTime5")); }
        if (playerIndex == 6) { PlayerPrefs.SetInt("PlayerTime6", score + PlayerPrefs.GetInt("PlayerTime6")); }
        if (playerIndex == 7) { PlayerPrefs.SetInt("PlayerTime7", score + PlayerPrefs.GetInt("PlayerTime7")); }
        if (playerIndex == 8) { PlayerPrefs.SetInt("PlayerTime8", score + PlayerPrefs.GetInt("PlayerTime8")); }
        if (playerIndex == 9) { PlayerPrefs.SetInt("PlayerTime9", score + PlayerPrefs.GetInt("PlayerTime9")); }
    }

    public static int getTimePlayed(int playerIndex)
    {
        int answer = 0;

        if (playerIndex == 0) { answer = PlayerPrefs.GetInt("PlayerTime0"); }
        if (playerIndex == 1) { answer = PlayerPrefs.GetInt("PlayerTime1"); }
        if (playerIndex == 2) { answer = PlayerPrefs.GetInt("PlayerTime2"); }
        if (playerIndex == 3) { answer = PlayerPrefs.GetInt("PlayerTime3"); }
        if (playerIndex == 4) { answer = PlayerPrefs.GetInt("PlayerTime4"); }
        if (playerIndex == 5) { answer = PlayerPrefs.GetInt("PlayerTime5"); }
        if (playerIndex == 6) { answer = PlayerPrefs.GetInt("PlayerTime6"); }
        if (playerIndex == 7) { answer = PlayerPrefs.GetInt("PlayerTime7"); }
        if (playerIndex == 8) { answer = PlayerPrefs.GetInt("PlayerTime8"); }
        if (playerIndex == 9) { answer = PlayerPrefs.GetInt("PlayerTime9"); }

        return answer;
    }

    //Percent Correct
    public static void setPercentCorrect(int playerIndex, int score)
    {
        if (playerIndex == 0) { PlayerPrefs.SetInt("PlayerCorrect0", score); setPercentIncorrect(playerIndex, score); }
        if (playerIndex == 1) { PlayerPrefs.SetInt("PlayerCorrect1", score); }
        if (playerIndex == 2) { PlayerPrefs.SetInt("PlayerCorrect2", score); }
        if (playerIndex == 3) { PlayerPrefs.SetInt("PlayerCorrect3", score); }
        if (playerIndex == 4) { PlayerPrefs.SetInt("PlayerCorrect4", score); }
        if (playerIndex == 5) { PlayerPrefs.SetInt("PlayerCorrect5", score); }
        if (playerIndex == 6) { PlayerPrefs.SetInt("PlayerCorrect6", score); }
        if (playerIndex == 7) { PlayerPrefs.SetInt("PlayerCorrect7", score); }
        if (playerIndex == 8) { PlayerPrefs.SetInt("PlayerCorrect8", score); }
        if (playerIndex == 9) { PlayerPrefs.SetInt("PlayerCorrect9", score); }
    }

    public static int getPercentCorrect(int playerIndex)
    {
        int answer = 0;

        if (playerIndex == 0) { answer = PlayerPrefs.GetInt("PlayerCorrect0"); }
        if (playerIndex == 1) { answer = PlayerPrefs.GetInt("PlayerCorrect1"); }
        if (playerIndex == 2) { answer = PlayerPrefs.GetInt("PlayerCorrect2"); }
        if (playerIndex == 3) { answer = PlayerPrefs.GetInt("PlayerCorrect3"); }
        if (playerIndex == 4) { answer = PlayerPrefs.GetInt("PlayerCorrect4"); }
        if (playerIndex == 5) { answer = PlayerPrefs.GetInt("PlayerCorrect5"); }
        if (playerIndex == 6) { answer = PlayerPrefs.GetInt("PlayerCorrect6"); }
        if (playerIndex == 7) { answer = PlayerPrefs.GetInt("PlayerCorrect7"); }
        if (playerIndex == 8) { answer = PlayerPrefs.GetInt("PlayerCorrect8"); }
        if (playerIndex == 9) { answer = PlayerPrefs.GetInt("PlayerCorrect9"); }

        return answer;
    }

    //Percent Incorrect
    public static void setPercentIncorrect(int playerIndex, int score)
    {
        if (playerIndex == 0) { PlayerPrefs.SetInt("PlayerIncorrect0", (100 - score)); }
        if (playerIndex == 1) { PlayerPrefs.SetInt("PlayerIncorrect1", (100 - score)); }
        if (playerIndex == 2) { PlayerPrefs.SetInt("PlayerIncorrect2", (100 - score)); }
        if (playerIndex == 3) { PlayerPrefs.SetInt("PlayerIncorrect3", (100 - score)); }
        if (playerIndex == 4) { PlayerPrefs.SetInt("PlayerIncorrect4", (100 - score)); }
        if (playerIndex == 5) { PlayerPrefs.SetInt("PlayerIncorrect5", (100 - score)); }
        if (playerIndex == 6) { PlayerPrefs.SetInt("PlayerIncorrect6", (100 - score)); }
        if (playerIndex == 7) { PlayerPrefs.SetInt("PlayerIncorrect7", (100 - score)); }
        if (playerIndex == 8) { PlayerPrefs.SetInt("PlayerIncorrect8", (100 - score)); }
        if (playerIndex == 9) { PlayerPrefs.SetInt("PlayerIncorrect9", (100 - score)); }
    }

    public static int getPercentIncorrect(int playerIndex)
    {
        int answer = 0;

        if (playerIndex == 0) { answer = PlayerPrefs.GetInt("PlayerIncorrect0"); }
        if (playerIndex == 1) { answer = PlayerPrefs.GetInt("PlayerIncorrect1"); }
        if (playerIndex == 2) { answer = PlayerPrefs.GetInt("PlayerIncorrect2"); }
        if (playerIndex == 3) { answer = PlayerPrefs.GetInt("PlayerIncorrect3"); }
        if (playerIndex == 4) { answer = PlayerPrefs.GetInt("PlayerIncorrect4"); }
        if (playerIndex == 5) { answer = PlayerPrefs.GetInt("PlayerIncorrect5"); }
        if (playerIndex == 6) { answer = PlayerPrefs.GetInt("PlayerIncorrect6"); }
        if (playerIndex == 7) { answer = PlayerPrefs.GetInt("PlayerIncorrect7"); }
        if (playerIndex == 8) { answer = PlayerPrefs.GetInt("PlayerIncorrect8"); }
        if (playerIndex == 9) { answer = PlayerPrefs.GetInt("PlayerIncorrect9"); }

        return answer;
    }

    //Number Correct
    public static void setNumberCorrect(int playerIndex)
    {
        if (playerIndex == 0) { PlayerPrefs.SetInt("PlayerNumberCorrect0", PlayerPrefs.GetInt("PlayerNumberCorrect0") + 1); }
        if (playerIndex == 1) { PlayerPrefs.SetInt("PlayerNumberCorrect1", PlayerPrefs.GetInt("PlayerNumberCorrect1") + 1); }
        if (playerIndex == 2) { PlayerPrefs.SetInt("PlayerNumberCorrect2", PlayerPrefs.GetInt("PlayerNumberCorrect2") + 1); }
        if (playerIndex == 3) { PlayerPrefs.SetInt("PlayerNumberCorrect3", PlayerPrefs.GetInt("PlayerNumberCorrect3") + 1); }
        if (playerIndex == 4) { PlayerPrefs.SetInt("PlayerNumberCorrect4", PlayerPrefs.GetInt("PlayerNumberCorrect4") + 1); }
        if (playerIndex == 5) { PlayerPrefs.SetInt("PlayerNumberCorrect5", PlayerPrefs.GetInt("PlayerNumberCorrect5") + 1); }
        if (playerIndex == 6) { PlayerPrefs.SetInt("PlayerNumberCorrect6", PlayerPrefs.GetInt("PlayerNumberCorrect6") + 1); }
        if (playerIndex == 7) { PlayerPrefs.SetInt("PlayerNumberCorrect7", PlayerPrefs.GetInt("PlayerNumberCorrect7") + 1); }
        if (playerIndex == 8) { PlayerPrefs.SetInt("PlayerNumberCorrect8", PlayerPrefs.GetInt("PlayerNumberCorrect8") + 1); }
        if (playerIndex == 9) { PlayerPrefs.SetInt("PlayerNumberCorrect9", PlayerPrefs.GetInt("PlayerNumberCorrect9") + 1); }
    }

    public static int getNumberCorrect(int playerIndex)
    {
        int answer = 0;

        if (playerIndex == 0) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect0"); }
        if (playerIndex == 1) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect1"); }
        if (playerIndex == 2) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect2"); }
        if (playerIndex == 3) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect3"); }
        if (playerIndex == 4) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect4"); }
        if (playerIndex == 5) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect5"); }
        if (playerIndex == 6) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect6"); }
        if (playerIndex == 7) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect7"); }
        if (playerIndex == 8) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect8"); }
        if (playerIndex == 9) { answer = PlayerPrefs.GetInt("PlayerNumberCorrect9"); }

        return answer;
    }

    //Number Incorrect
    public static void setNumberIncorrect(int playerIndex)
    {
        if (playerIndex == 0) { PlayerPrefs.SetInt("PlayerNumberIncorrect0", PlayerPrefs.GetInt("PlayerNumberIncorrect0") + 1); }
        if (playerIndex == 1) { PlayerPrefs.SetInt("PlayerNumberIncorrect1", PlayerPrefs.GetInt("PlayerNumberIncorrect1") + 1); }
        if (playerIndex == 2) { PlayerPrefs.SetInt("PlayerNumberIncorrect2", PlayerPrefs.GetInt("PlayerNumberIncorrect2") + 1); }
        if (playerIndex == 3) { PlayerPrefs.SetInt("PlayerNumberIncorrect3", PlayerPrefs.GetInt("PlayerNumberIncorrect3") + 1); }
        if (playerIndex == 4) { PlayerPrefs.SetInt("PlayerNumberIncorrect4", PlayerPrefs.GetInt("PlayerNumberIncorrect4") + 1); }
        if (playerIndex == 5) { PlayerPrefs.SetInt("PlayerNumberIncorrect5", PlayerPrefs.GetInt("PlayerNumberIncorrect5") + 1); }
        if (playerIndex == 6) { PlayerPrefs.SetInt("PlayerNumberIncorrect6", PlayerPrefs.GetInt("PlayerNumberIncorrect6") + 1); }
        if (playerIndex == 7) { PlayerPrefs.SetInt("PlayerNumberIncorrect7", PlayerPrefs.GetInt("PlayerNumberIncorrect7") + 1); }
        if (playerIndex == 8) { PlayerPrefs.SetInt("PlayerNumberIncorrect8", PlayerPrefs.GetInt("PlayerNumberIncorrect8") + 1); }
        if (playerIndex == 9) { PlayerPrefs.SetInt("PlayerNumberIncorrect9", PlayerPrefs.GetInt("PlayerNumberIncorrect9") + 1); }
    }

    public static int getNumberIncorrect(int playerIndex)
    {
        int answer = 0;

        if (playerIndex == 0) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect0"); }
        if (playerIndex == 1) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect1"); }
        if (playerIndex == 2) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect2"); }
        if (playerIndex == 3) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect3"); }
        if (playerIndex == 4) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect4"); }
        if (playerIndex == 5) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect5"); }
        if (playerIndex == 6) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect6"); }
        if (playerIndex == 7) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect7"); }
        if (playerIndex == 8) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect8"); }
        if (playerIndex == 9) { answer = PlayerPrefs.GetInt("PlayerNumberIncorrect9"); }

        return answer;
    }
    */
}
