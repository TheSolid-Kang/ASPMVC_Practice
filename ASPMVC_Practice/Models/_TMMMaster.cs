using Microsoft.EntityFrameworkCore;

namespace ASPMVC_Practice.Models
{
    [Keyless]
    public class _TMMMaster
    {
        public string KeyValue                {get;set;}
        public int MaterialSeq             {get;set;}
        public int StockQty                {get;set;}
        public string OrderStatus             {get;set;}
        public string SalesDept               {get;set;}
        public string ItemType                {get;set;}
        public string MaterialType            {get;set;}
        public string CustName                {get;set;}
        public string ProductName             {get;set;}
        public string IsOutsourcing           {get;set;}
        public string WHName                  {get;set;}
        public string OrderNo                 {get;set;}
        public string ItemNo                  {get;set;}
        public string ItemName                {get;set;}
        public int Qty                     {get;set;}
        public decimal UnitPrice               {get;set;}
        public string QtyPerBox               {get;set;}
        public string MaterialSpec            {get;set;}
        public string SubCategory             {get;set;}
        public string StockOccurCause         {get;set;}
        public string StockOccurPosition      {get;set;}
        public string StockOccurCauseDetail   {get;set;}
        public string StockOccurDept          {get;set;}
        public string StockOccurProof         {get;set;}
        public string StockOccurDate          {get;set;}
        public string InDate                  {get;set;}
        public string ExpirationPeriod        {get;set;}
        public string ReInspectionDate        {get;set;}
        public string InOutNo                 {get;set;}
        public int UsedStockQty            {get;set;}
        public decimal StockPrice              {get;set;}
        public string InOutDate               {get;set;}
        public string AssetName               {get;set;}
        public string ActionPlan              {get;set;}
        public string Remark                  {get;set;}
        public string LastUserName            {get;set;}
        public DateTime LastDateTime { get; set; }
    }
}
