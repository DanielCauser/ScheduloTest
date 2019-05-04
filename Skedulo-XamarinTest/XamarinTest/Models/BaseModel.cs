﻿using System;
using System.ComponentModel;

namespace XamarinTest
{
	public class BaseModel : INotifyPropertyChanged
	{
		public BaseModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
