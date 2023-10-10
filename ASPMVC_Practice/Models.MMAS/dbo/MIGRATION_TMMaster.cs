using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ASPMVC_Practice.Models.MMAS.dboSchema;


namespace ASPMVC_Practice.Models.MMAS.dboSchema
{
    /// <summary>
    /// 	마이그레이션용_자재데이터
    /// </summary>
    [Table("MIGRATION_TMMaster")]
    public partial class MIGRATION_TMMaster
    {

        /// <summary>
        /// 	자재코드	
        /// </summary>
        [Key]
        public int MaterialSeq { get; set; }

        /// <summary>
        /// 	재고수량	
        /// </summary>
        public int StockQty { get; set; }

        /// <summary>
        /// 	상태	
        /// </summary>
        [StringLength(200)]
        public string OrderStatus { get; set; } = null!;

        /// <summary>
        /// 	영업부서	
        /// </summary>
        [StringLength(200)]
        public string SalesDept { get; set; } = null!;

        /// <summary>
        /// 	자재군구분	
        /// </summary>
        [StringLength(200)]
        public string ItemType { get; set; } = null!;

        /// <summary>
        /// 	ITEM구분	
        /// </summary>
        [StringLength(200)]
        public string MaterialType { get; set; } = null!;

        /// <summary>
        /// 	고객명	
        /// </summary>
        [StringLength(200)]
        public string CustName { get; set; } = null!;

        /// <summary>
        /// 	제품명	
        /// </summary>
        [StringLength(400)]
        public string ProductName { get; set; } = null!;

        /// <summary>
        /// 	외주구분	
        /// </summary>
        [StringLength(200)]
        public string IsOutsourcing { get; set; } = null!;

        /// <summary>
        /// 	위치	
        /// </summary>
        [StringLength(200)]
        public string WHName { get; set; } = null!;

        /// <summary>
        /// 	수주번호	
        /// </summary>
        [StringLength(40)]
        public string OrderNo { get; set; } = null!;

        /// <summary>
        /// 	품번	
        /// </summary>
        [StringLength(200)]
        public string ItemNo { get; set; } = null!;

        /// <summary>
        /// 	품명	
        /// </summary>
        [StringLength(400)]
        public string ItemName { get; set; } = null!;

        /// <summary>
        /// 	수량	
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// 	단가	
        /// </summary>
        [Column(TypeName = "decimal(19, 5)")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 	박스당수량	
        /// </summary>
        [StringLength(200)]
        public string QtyPerBox { get; set; } = null!;

        /// <summary>
        /// 	자재성격	
        /// </summary>
        [StringLength(200)]
        public string MaterialSpec { get; set; } = null!;

        /// <summary>
        /// 	소분류	
        /// </summary>
        [StringLength(200)]
        public string SubCategory { get; set; } = null!;

        /// <summary>
        /// 	발생요인	
        /// </summary>
        [StringLength(200)]
        public string StockOccurCause { get; set; } = null!;

        /// <summary>
        /// 	재고발생장소	
        /// </summary>
        [StringLength(200)]
        public string StockOccurPosition { get; set; } = null!;

        /// <summary>
        /// 	원인상세설명(6하원칙)	
        /// </summary>
        [StringLength(2000)]
        public string StockOccurCauseDetail { get; set; } = null!;

        /// <summary>
        /// 	귀책부서(요인기준)	
        /// </summary>
        [StringLength(200)]
        public string StockOccurDept { get; set; } = null!;

        /// <summary>
        /// 	증빙유형(기안, 메일, 기타)	
        /// </summary>
        [StringLength(400)]
        public string? StockOccurProof { get; set; }

        /// <summary>
        /// 	재고 발생일	
        /// </summary>
        [StringLength(200)]
        public string StockOccurDate { get; set; } = null!;

        /// <summary>
        /// 	자재 입고일	
        /// </summary>
        [StringLength(200)]
        public string InDate { get; set; } = null!;

        /// <summary>
        /// 	보관 기한	
        /// </summary>
        [StringLength(200)]
        public string? ExpirationPeriod { get; set; }

        /// <summary>
        /// 	장기재고 재검사일	
        /// </summary>
        [StringLength(200)]
        public string? ReInspectionDate { get; set; }

        /// <summary>
        /// 	재고사용 수주번호	
        /// </summary>
        [StringLength(40)]
        public string? InOutNo { get; set; }

        /// <summary>
        /// 	재고사용 수량	
        /// </summary>
        public int? UsedStockQty { get; set; }

        /// <summary>
        /// 	재고사용금액	
        /// </summary>
        [Column(TypeName = "decimal(19, 5)")]
        public decimal? StockPrice { get; set; }

        /// <summary>
        /// 	LOT 대체일	
        /// </summary>
        [StringLength(200)]
        public string? InOutDate { get; set; }

        /// <summary>
        /// 	품목자산분류	
        /// </summary>
        [StringLength(200)]
        public string AssetName { get; set; } = null!;

        /// <summary>
        /// 	처리방안	
        /// </summary>
        [StringLength(200)]
        public string ActionPlan { get; set; } = null!;

        /// <summary>
        /// 	비고	
        /// </summary>
        [StringLength(2000)]
        public string? Remark { get; set; }

        /// <summary>
        /// 	최종변경자	
        /// </summary>
        [StringLength(200)]
        public string LastUserName { get; set; } = null!;

        /// <summary>
        /// 	최종변경일	
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime LastDateTime { get; set; }
    }
}

