using System;
using System.Xml.Serialization;

namespace Aop.Api.Response
{
    /// <summary>
    /// AlipayMarketingCdpRecommendQueryResponse.
    /// </summary>
    public class AlipayMarketingCdpRecommendQueryResponse : AopResponse
    {
        /// <summary>
        /// 商家信息列表，最多返回20条，返回json数组
        /// </summary>
        [XmlElement("shop_info")]
        public string ShopInfo { get; set; }
    }
}
