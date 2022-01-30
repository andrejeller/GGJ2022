using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayGamesScript: MonoBehaviour {

    void Start() {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
    }


    void SignIn() {
        Social.localUser.Authenticate(success => { });
    }


    #region Achievement

    public static void UnlockAchievement(string id) {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void IncrementAchievement(string id, int stepsToIncrement) {
        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });
    }

    public static void ShowAchievementUI() {
        Social.ShowAchievementsUI();
    }

    #endregion

    #region Leaderboard

    public static void AddScoreToLeaderboard(string leaderboard, long score) {
        Social.ReportScore(score, leaderboard, success => { });
    }

    public static void ShowLeaderboardUI() {
        Social.ShowLeaderboardUI();
    }
    #endregion

}
