using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Datatables.Mvc
{
	/// <summary>
	/// Represents a single record with associated DT_RowId DT_RowClass attributes.
	/// </summary>
	public class DataTableRow
	{
		public DataTableRow() { }
		public DataTableRow(IEnumerable<string> data)
		{
			Data = data;
		}
		public DataTableRow(string rowId, IEnumerable<string> data) : this(data)
		{
			RowId = rowId;
		}
		public DataTableRow(string rowId, string rowClass, IEnumerable<string> data) : this(rowId, data)
		{
			RowClass = rowClass;
		}
		/// <summary>
		/// Gets or sets the RowId.
		/// </summary>
		/// <remarks>When turned into JSON becomes the DT_RowId key/value pair.</remarks>
		public string RowId { get; set; }

		/// <summary>
		/// Gets or sets the RowClass.
		/// </summary>
		/// <remarks>>When turned into JSON becomes the DT_RowClass key/value pair.</remarks>
		public string RowClass { get; set; }

		/// <summary>
		/// Gets or sets fields, in ordinal order.
		/// </summary>
		/// <remarks>This data represents a single entry in the aaData construct.</remarks>
		public IEnumerable<string> Data { get; set; }

		internal IDictionary<string,string> ToDictionary()
		{
			const string dtRowIdKey = "DT_RowId";
			const string dtRowClassKey = "DT_RowClass";

			IDictionary<string,string> result = new Dictionary<string, string>();

			if (!string.IsNullOrEmpty(RowId))
			{
				result.Add(dtRowIdKey, RowId);
			}
			if (!string.IsNullOrEmpty(RowClass))
			{
				result.Add(dtRowClassKey, RowClass);
			}

			if (Data == null)
			{
				return result;
			}
			result = IndexEnumerable(Data, result);

			return result;
		}

		public static IDictionary<string,string> IndexEnumerable(IEnumerable<string> list, IDictionary<string,string> dictionary = null)
		{
			if (dictionary == null)
			{
				dictionary = new Dictionary<string, string>();
			}

			var count = 0;
			foreach (var item in list)
			{
				dictionary.Add("" + count, item);
				count++;
			}

			return dictionary;
		} 
	}
}