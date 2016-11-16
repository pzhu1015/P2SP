/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2014-2-26
 * Time: 23:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Weather
{
	/// <summary>
	/// Description of WeatherApi.
	/// </summary>
	public class WeatherApi
	{
		private WeatherWebService.WeatherWebService weatherService = new WeatherWebService.WeatherWebService();
		
		public WeatherApi()
		{
		}
		
		public string[] GetWeatherByCityName(string city)
		{
			return this.weatherService.getWeatherbyCityName(city);
		}
		
		public string[] GetSupportCity(string province)
		{
			return this.weatherService.getSupportCity(province);
		}
	}
}
