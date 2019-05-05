/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2013-8-28
 * Time: 14:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace UserComponents.P2SPService
{
	/// <summary>
	/// Description of IDataCell.
	/// </summary>
	public interface IDataCell
	{
		byte[] ToBuffer();
		void FromBuffer(byte[] buffer);
	}
}
