﻿/*
 * XCoder v6.4.5644.19959
 * 作者：Stone/X2
 * 时间：2015-06-23 21:53:36
 * 版权：版权所有 (C) 新生命开发团队 2002~2015
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using NewLife.Data;
using NewLife.Log;
using XCode;
using XCode.Membership;

namespace NewLife.CMX
{
    /// <summary>来源</summary>
    public partial class Source : Entity<Source>
    {
        #region 对象操作
        static Source()
        {
            Meta.Modules.Add<UserModule>();
            Meta.Modules.Add<TimeModule>();
            Meta.Modules.Add<IPModule>();
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew"></param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
            base.Valid(isNew);
        }

        /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void InitData()
        {
            base.InitData();

            // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
            // Meta.Count是快速取得表记录数
            if (Meta.Count > 0) return;

            // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}[{1}]数据……", typeof(Source).Name, Meta.Table.DataTable.DisplayName);

            var entity = new Source()
            {
                Name = "本地",
                Url = "/",
                Enable = true
            };
            entity.Insert();

            entity = new Source()
            {
                Name = "网络",
                Url = "/",
                Enable = true
            };
            entity.Insert();

            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}[{1}]数据！", typeof(Source).Name, Meta.Table.DataTable.DisplayName);
        }
        #endregion

        #region 扩展属性
        #endregion

        #region 扩展查询
        /// <summary>根据ID查询</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Source FindByID(Int32 id)
        {
            if (id <= 0) return null;

            if (Meta.Count >= 1000)
                return Meta.SingleCache[id];
            else
                return Meta.Cache.Find(e => e.ID == id);
        }
        #endregion

        #region 高级查询
        /// <summary>查找所有可见</summary>
        /// <returns></returns>
        public static IList<Source> FindAllVisible()
        {
            var data = Meta.Cache.Entities.Where(e => e.Enable).OrderBy(e => e.Sort);
            return new List<Source>(data);
        }
        #endregion

        #region 扩展操作
        #endregion

        #region 业务
        #endregion
    }
}