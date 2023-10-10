using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ASPMVC_Practice.Models.MMAS.dboSchema;


namespace ASPMVC_Practice.Models.MMAS.dboSchema
{
    /// <summary>
    /// 사용자마스터
    /// </summary>
    [Table("_TMUser")]
    public partial class _TMUser
    {

        /// <summary>
        /// 사용자코드
        /// </summary>
        [Key]
        public int UserSeq { get; set; }

        /// <summary>
        /// 계정
        /// </summary>
        [StringLength(200)]
        public string? ResidID { get; set; }

        /// <summary>
        /// 사원명
        /// </summary>
        [StringLength(100)]
        public string? UserName { get; set; }

        /// <summary>
        /// 사번
        /// </summary>
        [StringLength(20)]
        public string? Empid { get; set; }

        /// <summary>
        /// 관리자여부(1 == 관리자, 0 == 일반)
        /// </summary>
        [StringLength(1)]
        public string IsAdministrator { get; set; } = null!;

        /// <summary>
        /// 재직여부(1 == 재직자, 0 == 퇴사자)
        /// </summary>
        [StringLength(1)]
        public string IsInner { get; set; } = null!;

        /// <summary>
        /// 최종작업자
        /// </summary>
        public int? LastUserSeq { get; set; }

        /// <summary>
        /// 최종작업일시
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LastDateTime { get; set; }
    }
}

