﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewLife.Xml;

namespace UEditor
{
    /// <summary>UEditor配置</summary>
    [DisplayName("UEditor配置")]
    [XmlConfigFile(@"Config\UEditor.config", 15000)]
    public class Setting : XmlConfig<Setting>
    {
        #region 上传配置
        /// <summary>文件命名规则</summary>
        public String PathFormat { get; set; }

        /// <summary>上传表单域名称</summary>
        public String UploadFieldName { get; set; }

        /// <summary>上传大小限制</summary>
        public Int32 SizeLimit { get; set; }

        /// <summary>上传允许的文件格式</summary>
        public String[] AllowExtensions { get; set; }

        /// <summary>文件是否以 Base64 的形式上传</summary>
        public Boolean Base64 { get; set; }

        /// <summary>Base64 字符串所表示的文件名</summary>
        public String Base64Filename { get; set; }
        #endregion

        #region 上传图片配置项
        /// <summary>执行上传图片的action名称</summary>
        [Description("执行上传图片的action名称")]
        public String ImageActionName { get; set; } = "uploadimage";

        /// <summary>执行上传图片的action名称</summary>
        [Description("执行上传图片的action名称")]
        public String ImageFieldName { get; set; } = "uploadimage";

        /// <summary>上传大小限制，单位B</summary>
        [Description("上传大小限制，单位B")]
        public Int32 ImageMaxSize { get; set; } = 2048000;
        #endregion

        #region 涂鸦图片上传配置项
        /// <summary>执行上传涂鸦的action名称</summary>
        [Description("执行上传涂鸦的action名称")]
        public String ScrawlActionName { get; set; } = "uploadscrawl";

        /// <summary>提交的图片表单名称</summary>
        [Description("提交的图片表单名称")]
        public String ScrawlFieldName { get; set; } = "upfile";

        /// <summary>上传保存路径,可以自定义保存路径和文件名格式</summary>
        [Description("上传保存路径,可以自定义保存路径和文件名格式")]
        public String ScrawlPathFormat { get; set; } = "/upload/image/{yyyy}{mm}{dd}/{time}{rand:6}";

        /// <summary>上传大小限制，单位B</summary>
        [Description("上传大小限制，单位B")]
        public Int32 ScrawlMaxSize { get; set; } = 2048000;
        #endregion
    }
}