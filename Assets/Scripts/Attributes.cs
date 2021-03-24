using System;

[Serializable]
public class Attributes
{
    public string createdAt;
    public DateTime _CreatedAtDT
    {
        get
        {
            return DateTime.Parse(createdAt);
        }
    }
}
