using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyPayment
{
    /// <summary>
    /// AnyPayment付款生成接口对象IAnyPay
    /// </summary>
    public interface IAnyPay : IEnumerable, IDisposable
    {
        /// <summary>
        /// 定义一个AnyPayment支持的IAnyPayConfigure对象,该对象表示某种支付方式的参数配置实体对象
        /// </summary>
        IAnyPayConfigure AnyPayConfigure { get; }

        /// <summary>
        /// 定义一个(添加/修改)请求参数键值对方法
        /// </summary>
        /// <param name="key">参数键名</param>
        /// <param name="value">参数具体值</param>
        /// <returns></returns>
        IAnyPay Add(string key, object value);


        /// <summary>
        /// 定义一个获取已经添加请求参数键值对方法
        /// </summary>
        /// <param name="key">参数键名</param>
        /// <returns></returns>
        object Get(string key);


        /// <summary>
        /// 定义一个函数,该函数表示对请求参数执行排序操作
        /// </summary>
        /// <param name="sortEventHandler">排序事件调用函数</param>
        //void Sort(Func<string, IComparer<string>> sortEventHandler);
        void Sort();

        /// <summary>
        /// 定义一个函数,该函数表示对请求参数执行编码操作
        /// </summary>
        /// <param name="encodingEventHandler">编码调用事件，只需要返回对值的编码处理结果即可,禁止返回key=value的格式</param>
        //void Encode(Func<string, object, string> encodingEventHandler);
        void Encode();

        /// <summary>
        /// 定义一个获取已经添加请求参数键值对方法
        /// </summary>
        /// <param name="key">参数键名</param>
        /// <returns></returns>
        Dictionary<string, object> GetAll();

        /// <summary>
        /// 定义一个通过参数key获取已经添加请求参数值,转为TValue并返回
        /// </summary>
        /// <param name="key">参数键名</param>
        /// <returns></returns>
        TValue Get<TValue>(string key) where TValue : class;

        /// <summary>
        /// 定义一个移除请求参数键值对方法
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        IAnyPay Remove(string key);

        /// <summary>
        /// 定义一个移除所有请求参数键值对方法
        /// </summary>
        /// <returns></returns>
        IAnyPay RemoveAll();
    }
}
