/*
 * Created by SharpDevelop.
 * User: Pengzhihu
 * Date: 2014-6-5
 * Time: 15:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace UserComponents
{
	/// <summary>
	/// Description of HideOnStartupApplicationContext.
	/// </summary>
	internal class HideOnStartupApplicationContext : ApplicationContext
	{
	    private Form mainFormInternal;
	
	    public HideOnStartupApplicationContext(Form mainForm)
	    {
	        this.mainFormInternal = mainForm;
	        this.mainFormInternal.FormClosed += new FormClosedEventHandler(mainFormInternal_FormClosed);
	    }
	
	    void mainFormInternal_FormClosed(object sender, FormClosedEventArgs e)
	    {
	        Application.Exit();
	    }
	}
}
