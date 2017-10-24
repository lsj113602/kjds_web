using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Enums
{/// <summary>
    /// 接口函数枚举
    /// </summary>
    public enum FunctionCodeEnum
    {
        /// <summary>
        /// 自检结果通知
        /// </summary>
        F01,

        /// <summary>
        /// 发送检测数据
        /// </summary>
        F02,

        /// <summary>
        /// 关闭设备
        /// </summary>
        F03,

        /// <summary>
        /// 初始化设备
        /// </summary>
        F04,

        /// <summary>
        /// 故障报告发送
        /// </summary>
        F05,

        /// <summary>
        /// 版本监测【可选】
        /// </summary>
        F06,

        /// <summary>
        /// 更新程序下载【可选】
        /// </summary>
        F07
    }
    /// <summary>
    /// 接口调用状态枚举
    /// </summary>
    public enum ImportStatusEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        T,
        /// <summary>
        /// 失败
        /// </summary>
        F,
        /// <summary>
        /// 内容
        /// </summary>
        C
    }
    /// <summary>
    /// 错误码描述
    /// </summary>
    public enum ErrorEnum
    {
        //[EnumDescription("无法解密，可能为恶意调用")]
        E001,
        //[EnumDescription("接口序号参数g不存在")]
        E002,
        //[EnumDescription("接口序号参数a不存在")]
        E003,
        //[EnumDescription("接口序号参数s不存在")]
        E004,
        //[EnumDescription("接口序号对应的内容参数不完整")]
        E005,
        //[EnumDescription("设备的唯一标识参数e不能为空")]
        E006,
        //[EnumDescription("服务器端出错")]
        E007
    }
}
