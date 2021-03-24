using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
public class GUIPrint_TournametsData : MonoBehaviour
{
    public delegate void Delegate_DeactivateItems();
    public static Delegate_DeactivateItems Listener_DeactivateItems;

    [SerializeField]
    private List<GUI_TournamentItem> DataItemPool;
    [SerializeField]
    private TMPro.TextMeshProUGUI    PrintAMountOf;

    [SerializeField]
    private Button Btn_First;
    [SerializeField]
    private Button Btn_Last;
    [SerializeField]
    private Button Btn_Prev;
    [SerializeField]
    private Button Btn_Next;

    [SerializeField]
    private int IndexStartCountAmount;
    [SerializeField]
    private int IndexFinishCountAmount;
    [SerializeField]
    private int IndexPage;
    [SerializeField]
    private int Sectors;

    private List<Tournament> ToPrintDataList;

    private void Start()
    {
        Btn_Last.onClick.AddListener(UI_Last);
        Btn_First.onClick.AddListener(UI_First);
        Btn_Prev.onClick.AddListener(UI_Prev);
        Btn_Next.onClick.AddListener(UI_Next);
    }
    private void PrintInnerData(int _indexStart)
    {
        Listener_DeactivateItems?.Invoke();
        for (int i = 0; i < DataItemPool.Count; i++)
        {
            if(i+_indexStart<ToPrintDataList.Count)
            {
                DataItemPool[i].gameObject.SetActive(true);
                DataItemPool[i].InitData(ToPrintDataList[i + _indexStart].id, ToPrintDataList[i + _indexStart].attributes.createdAt, i);
            }
        }
    }
    
    public void UI_CallPrintData()
    {

        ToPrintDataList = ServiceLocator.Instance.GetService<IGetFetchedData>().GetTournamentData();
        if (ToPrintDataList.Count > 0)
        {
            IndexStartCountAmount = 0;
            IndexFinishCountAmount = DataItemPool.Count;
            PrintInnerData(IndexStartCountAmount);

            IndexPage = 1;
            Sectors = Mathf.RoundToInt(ToPrintDataList.Count / DataItemPool.Count);
            Btn_First.interactable = false;
            Btn_Next.interactable = true;
            Btn_Prev.interactable = false;
            Btn_Last.interactable = true;
            UpdateUI();
        }
    }
    
    public void UI_Next()
    {
        IndexPage++;

        IndexStartCountAmount = ((IndexPage * DataItemPool.Count) - DataItemPool.Count);

        int mtemporalFinalIndex = IndexPage * DataItemPool.Count;

        if (mtemporalFinalIndex >= ToPrintDataList.Count)
        {
            int mFinalIndex         = (mtemporalFinalIndex - ToPrintDataList.Count);
            IndexFinishCountAmount  = (mtemporalFinalIndex - mFinalIndex);
        }
        else
        {
            IndexFinishCountAmount = mtemporalFinalIndex;
        }

        PrintInnerData(IndexStartCountAmount);

        Btn_First.interactable = true;
        Btn_Prev.interactable = true;

        if (IndexPage > Sectors)
        {
            Btn_Next.interactable = false;
            Btn_Last.interactable = false;
        }

        UpdateUI();

    }
    public void UI_Prev()
    {

        IndexPage--;

        IndexFinishCountAmount  = IndexStartCountAmount;
        IndexStartCountAmount   = IndexFinishCountAmount - DataItemPool.Count;

        if (IndexPage <= 1)
        {
            IndexPage = 1;
            IndexStartCountAmount = 0;
            Btn_Prev.interactable = false;
            Btn_First.interactable = false;
            IndexFinishCountAmount = DataItemPool.Count;
        }

        Btn_Next.interactable = true;
        Btn_Last.interactable = true;

        PrintInnerData(IndexStartCountAmount);

        
        UpdateUI();
    }
    public void UI_Last()
    {
        int mSectors =      Mathf.RoundToInt(ToPrintDataList.Count / DataItemPool.Count);
        int mDataBlocks =   mSectors * DataItemPool.Count;
        int mFinalIndex =   ToPrintDataList.Count - mDataBlocks;

        if (mFinalIndex > 0)
        {
            IndexStartCountAmount   =  mDataBlocks;
            IndexFinishCountAmount  = IndexStartCountAmount + mFinalIndex;
        }
        else
        {
            IndexFinishCountAmount  = mDataBlocks;
            IndexStartCountAmount   = mDataBlocks - DataItemPool.Count;
        }

        PrintInnerData(IndexStartCountAmount);

        Btn_Last.interactable = false;
        Btn_Next.interactable = false;
        Btn_Prev.interactable = true;
        Btn_First.interactable = true;

        IndexPage = Sectors+1;
        UpdateUI();
    }
    public void UI_First()
    {
        IndexStartCountAmount = 0;
        IndexFinishCountAmount = DataItemPool.Count;

        PrintInnerData(IndexStartCountAmount);


        Btn_First.interactable  = false;
        Btn_Prev.interactable   = false;
        Btn_Last.interactable   = true;
        Btn_Next.interactable   = true;


        IndexPage = 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        PrintAMountOf.text = string.Concat("Page : ", IndexPage , "  Of  ", Sectors +1 );
    }
}
