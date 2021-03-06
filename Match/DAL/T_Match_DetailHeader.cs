﻿/**  版本信息模板在安装目录下，可自行修改。
* T_Match_DetailHeader.cs
*
* 功 能： N/A
* 类 名： T_Match_DetailHeader
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/9 14:23:24   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Match.DAL
{
	/// <summary>
	/// 数据访问类:T_Match_DetailHeader
	/// </summary>
	public partial class T_Match_DetailHeader
	{
		public T_Match_DetailHeader()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "T_Match_DetailHeader"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Match_DetailHeader");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Match.Model.T_Match_DetailHeader model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Match_DetailHeader(");
			strSql.Append("Name,People,Time,Address,Num,Size,Comments)");
			strSql.Append(" values (");
			strSql.Append("@Name,@People,@Time,@Address,@Num,@Size,@Comments)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@People", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Comments", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.People;
			parameters[2].Value = model.Time;
			parameters[3].Value = model.Address;
			parameters[4].Value = model.Num;
			parameters[5].Value = model.Size;
			parameters[6].Value = model.Comments;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Match.Model.T_Match_DetailHeader model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Match_DetailHeader set ");
			strSql.Append("Name=@Name,");
			strSql.Append("People=@People,");
			strSql.Append("Time=@Time,");
			strSql.Append("Address=@Address,");
			strSql.Append("Num=@Num,");
			strSql.Append("Size=@Size,");
			strSql.Append("Comments=@Comments");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@People", SqlDbType.Int,4),
					new SqlParameter("@Time", SqlDbType.DateTime),
					new SqlParameter("@Address", SqlDbType.NVarChar,50),
					new SqlParameter("@Num", SqlDbType.Int,4),
					new SqlParameter("@Size", SqlDbType.NVarChar,50),
					new SqlParameter("@Comments", SqlDbType.NVarChar,100),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.People;
			parameters[2].Value = model.Time;
			parameters[3].Value = model.Address;
			parameters[4].Value = model.Num;
			parameters[5].Value = model.Size;
			parameters[6].Value = model.Comments;
			parameters[7].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_DetailHeader ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Match_DetailHeader ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Match.Model.T_Match_DetailHeader GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,People,Time,Address,Num,Size,Comments from T_Match_DetailHeader ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Match.Model.T_Match_DetailHeader model=new Match.Model.T_Match_DetailHeader();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Match.Model.T_Match_DetailHeader DataRowToModel(DataRow row)
		{
			Match.Model.T_Match_DetailHeader model=new Match.Model.T_Match_DetailHeader();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["People"]!=null && row["People"].ToString()!="")
				{
					model.People=int.Parse(row["People"].ToString());
				}
				if(row["Time"]!=null && row["Time"].ToString()!="")
				{
					model.Time=DateTime.Parse(row["Time"].ToString());
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Num"]!=null && row["Num"].ToString()!="")
				{
					model.Num=int.Parse(row["Num"].ToString());
				}
				if(row["Size"]!=null)
				{
					model.Size=row["Size"].ToString();
				}
				if(row["Comments"]!=null)
				{
					model.Comments=row["Comments"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Name,People,Time,Address,Num,Size,Comments ");
			strSql.Append(" FROM T_Match_DetailHeader ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Name,People,Time,Address,Num,Size,Comments ");
			strSql.Append(" FROM T_Match_DetailHeader ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Match_DetailHeader ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Match_DetailHeader T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Match_DetailHeader";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

