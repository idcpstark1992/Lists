using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetTournaments : MonoBehaviour, IGetFetchedData
{
    [SerializeField]
    private string ApiKey;
    public ApiData tournamentList;

    public void getTournamentList()
    {
        StartCoroutine(getTournamentListCo());
    }

    IEnumerator getTournamentListCo()
    {
        tournamentList.data.Clear();
        ServiceLocator.Instance.GetService<IModalScreen>().ToggleModalScreen(true);
        UnityWebRequest request = UnityWebRequest.Get("https://api.pubg.com/tournaments");

        request.SetRequestHeader("accept", "application/vnd.api+json");
        request.SetRequestHeader("authorization", ApiKey);

        yield return request.SendWebRequest();
        
        if(request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            tournamentList = JsonUtility.FromJson<ApiData>(response);
            ServiceLocator.Instance.GetService<IModalScreen>().ToggleModalScreen(false);
            ServiceLocator.Instance.GetService<ICompletedTask>().OnCompletedTask();
        }
    }

    public List<Tournament> GetTournamentData()
    {
        return tournamentList.data;
    }
}
