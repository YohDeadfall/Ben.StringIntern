// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;

namespace System
{
    internal static class ThrowHelper
    {
        private static ArgumentOutOfRangeException GetArgumentArrayPlusOffTooSmall()
        {
            return new ArgumentOutOfRangeException("count plus offset is larger than array length");
        }

        [DoesNotReturn]
        internal static void ThrowArgumentException_ArrayPlusOffTooSmall()
        {
            throw GetArgumentArrayPlusOffTooSmall();
        }

        private static ArgumentNullException GetArgumentNullException(ExceptionArgument argument)
        {
            return new ArgumentNullException(GetArgumentName(argument));
        }

        [DoesNotReturn]
        internal static void ThrowArgumentNullException(ExceptionArgument argument)
        {
            throw GetArgumentNullException(argument);
        }

        [DoesNotReturn]
        internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument)
        {
            throw new ArgumentOutOfRangeException(GetArgumentName(argument));
        }

        [DoesNotReturn]
        internal static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion()
        {
            throw new InvalidOperationException("Enum Failed Version");
        }

        [DoesNotReturn]
        internal static void ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen()
        {
            throw new InvalidOperationException("Enum Operation Cannot Happen");
        }

        [DoesNotReturn]
        internal static void ThrowInvalidOperationException_ConcurrentOperationsNotSupported()
        {
            throw new InvalidOperationException("Concurrent Operations Not Supported");
        }

        private static string GetArgumentName(ExceptionArgument argument)
        {
            return argument switch
            {
                ExceptionArgument.capacity => "capacity",
                ExceptionArgument.collection => "collection",
                ExceptionArgument.array => "array",
                ExceptionArgument.match => "match",
                ExceptionArgument.other => "other",
                _ => "(unknown)"
            };
        }
    }

    //
    // The convention for this enum is using the argument name as the enum name
    //
    internal enum ExceptionArgument
    {
        capacity,
        collection,
        array,
        match,
        other,
        maxSize
    }

    //
    // The convention for this enum is using the resource name as the enum name
    //
    internal enum ExceptionResource
    {
        Arg_ArrayPlusOffTooSmall
    }
}
