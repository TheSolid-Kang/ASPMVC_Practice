namespace ASPMVC_Practice.Models
{
  public class _TCDiary
  {
        public _TCDiary() { }
        public _TCDiary(_TCDiary _TCDiary) 
        { 
            ChurchSeq = _TCDiary.ChurchSeq;
            DiarySeq = _TCDiary.DiarySeq;
            InDate = _TCDiary.InDate;
            Title = _TCDiary.Title;
            Record = _TCDiary.Record;
            Remark = _TCDiary.Remark;
            LastUserSeq = _TCDiary.LastUserSeq;
            LastDateTime = _TCDiary.LastDateTime;
        }
    public int ChurchSeq { get; set; }
    public int DiarySeq     {get;set;}
    public DateTime InDate       {get;set;}
    public string Title        {get;set;}
    public string Record       {get;set;}
    public string Remark       {get;set;}
    public int LastUserSeq  {get;set;}
    public DateTime LastDateTime {get;set;}
  }
}
