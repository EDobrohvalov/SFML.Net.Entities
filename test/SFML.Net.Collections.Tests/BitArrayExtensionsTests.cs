﻿using System.Collections;
using SFML.Net.Entities;
using Xunit;

namespace SFML.Net.Collections.Tests
{
    public class BitArrayExtensionsTests
    {
        [Fact]
        public void BitArrayIsEmpty()
        {
            Assert.True(new BitArray(1).IsEmpty());
            Assert.False(new BitArray(new[] { true }).IsEmpty());
            Assert.True(new BitArray(new[] { false }).IsEmpty());

            var bitArray = new BitArray(new[] { true });
            bitArray.Set(0, false);
            Assert.True(bitArray.IsEmpty());
        }
    }
}