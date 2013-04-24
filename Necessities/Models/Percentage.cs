using System;
using System.Globalization;

namespace Necessities.Models
{
    public class Percentage : IEquatable<Percentage>
    {
        private readonly decimal _value;

        public Percentage(decimal value)
        {
            _value = value;
        }

        public static implicit operator Percentage(decimal value)
        {
            return new Percentage(value);
        }

        public static implicit operator decimal(Percentage value)
        {
            return value._value;
        }

        public override string ToString()
        {
            return _value.ToString("#0.000 %");
        }

        public bool Equals(Percentage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Percentage) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(Percentage left, Percentage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Percentage left, Percentage right)
        {
            return !Equals(left, right);
        }
    }
}