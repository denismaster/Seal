﻿using System;


namespace Seal
{
    /// <summary>
    /// Root class of figures and animation hierarchy
    /// </summary>
    public abstract class Object
    {
        
        private string _name;
        /// <summary>
        /// Name of the object
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }
    }
}