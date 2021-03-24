using UnityEngine;
using TMPro;

public class GUI_TournamentItem :MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Print_TournamentId;
    [SerializeField]
    private TextMeshProUGUI Print_TournamentDate;
    [SerializeField]
    private int IndexOf;
    public void InitData(string _id , string _Date, int _index)
    {
        Print_TournamentId.text = _id;
        Print_TournamentDate.text = _Date;
        IndexOf = _index;
    }
}
