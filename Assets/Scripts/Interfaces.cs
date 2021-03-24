public interface IGetFetchedData
{
    System.Collections.Generic.List<Tournament> GetTournamentData();
}
public interface IModalScreen
{
    void ToggleModalScreen(bool _toggle);
}
public interface ICompletedTask
{
    void OnCompletedTask();
}