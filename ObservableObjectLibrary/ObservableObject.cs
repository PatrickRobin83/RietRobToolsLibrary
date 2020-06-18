/*
 * -----------------------------------------------------------------------------
 *	 
 *   Filename		:   ObservableObject.cs
 *   Date			:   2020-06-18 13:04:54
 *   All rights reserved
 * 
 * -----------------------------------------------------------------------------
 * @author     Patrick Robin <support@rietrob.de>
 * @Version      1.0.0
 */

using JetBrains.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ObservableObjectLibrary
{

    /// <summary>
    /// this implements the interface INotifypropertychanged
    /// Models or ViewModels can inherit the ObservableObject
    /// </summary>
    public class ObserveableObject : INotifyPropertyChanged
    {


        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Constructor

        #endregion

        #region Methods

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// To Use this on a Property use it like
        /// OnPropertyChanged(ref <fieldName>, value)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// 
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] 
                                                    string propertyName = "")
        {
            property = value;
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}