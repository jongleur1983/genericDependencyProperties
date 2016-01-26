using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GenericDependencyProperties.GenericCallback
{
    public delegate TProperty GenericCoerceValueCallback<in TOwner, TProperty>(
        TOwner d,
        TProperty baseValue)
        where TOwner : DependencyObject;
}
