using System;
using Microsoft.AspNetCore.Identity;

namespace Leelite.Modules.Identity.Models.UserAgg
{
    public class UserIDCard
    {
        /// <summary>
        /// 民族
        /// </summary>
        [PersonalData]
        public string Ethnicity { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [PersonalData]
        public string Address { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [ProtectedPersonalData]
        public string IDNumber { get; set; }

        /// <summary>
        /// 签发机关
        /// </summary>
        public string IssuingAuthority { get; set; }

        /// <summary>
        /// 有效期开始日期
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// 有效期结束日期
        /// </summary>
        public DateTimeOffset EndDate { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        [PersonalData]
        public string Photo { get; set; }

        /// <summary>
        /// 指纹
        /// </summary>
        [PersonalData]
        public string Fingerprint { get; set; }
    }
}
