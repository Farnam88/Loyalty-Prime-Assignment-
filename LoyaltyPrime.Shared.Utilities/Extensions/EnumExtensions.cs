﻿using System;

namespace LoyaltyPrime.Shared.Utilities.Extensions
{
    public static class EnumExtensions
    {
        public static TEnum StringToEnum<TEnum>(this string enumValue) where TEnum : struct,Enum
        {
            if (Enum.TryParse(enumValue, true, out TEnum enumObject))
            {
                return enumObject;
            }

            return default;
        }
    }
}