using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Rowles.LeanCorpus.Analysis;

/// <summary>
/// SIMD-accelerated ASCII character classification for 8-character blocks
/// loaded as <see cref="Vector128{T}"/> of <see cref="ushort"/>.
/// Used by tokenisers and filters that scan for alphanumeric or case boundaries
/// in predominantly-ASCII text.
/// </summary>
internal static class AsciiCharInspector
{
    private static readonly Vector128<ushort> Vec_0xFF80 = Vector128.Create((ushort)0xFF80);
    private static readonly Vector128<ushort> VecA = Vector128.Create((ushort)'A');
    private static readonly Vector128<ushort> VecZ = Vector128.Create((ushort)'Z');
    private static readonly Vector128<ushort> Veca = Vector128.Create((ushort)'a');
    private static readonly Vector128<ushort> Vecz = Vector128.Create((ushort)'z');
    private static readonly Vector128<ushort> Vec0 = Vector128.Create((ushort)'0');
    private static readonly Vector128<ushort> Vec9 = Vector128.Create((ushort)'9');

    /// <summary>
    /// Returns true if any character in the vector has a codepoint above 0x7F
    /// (i.e. is non-ASCII).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ContainsNonAscii(Vector128<ushort> chars)
        => (chars & Vec_0xFF80) != Vector128<ushort>.Zero;

    /// <summary>
    /// Returns an 8-bit mask where bit <c>i</c> is set if <c>chars[i]</c>
    /// is an ASCII letter or digit (<c>'A'-'Z'</c>, <c>'a'-'z'</c>, <c>'0'-'9'</c>).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static uint IsAlphanumericMask(Vector128<ushort> chars)
    {
        var isUpper = Vector128.GreaterThanOrEqual(chars, VecA)
                    & Vector128.LessThanOrEqual(chars, VecZ);
        var isLower = Vector128.GreaterThanOrEqual(chars, Veca)
                    & Vector128.LessThanOrEqual(chars, Vecz);
        var isDigit = Vector128.GreaterThanOrEqual(chars, Vec0)
                    & Vector128.LessThanOrEqual(chars, Vec9);
        return (isUpper | isLower | isDigit).ExtractMostSignificantBits();
    }

    /// <summary>
    /// Returns an 8-bit mask where bit <c>i</c> is set if <c>chars[i]</c>
    /// is an ASCII uppercase letter (<c>'A'-'Z'</c>).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static uint IsUppercaseMask(Vector128<ushort> chars)
    {
        var isUpper = Vector128.GreaterThanOrEqual(chars, VecA)
                    & Vector128.LessThanOrEqual(chars, VecZ);
        return isUpper.ExtractMostSignificantBits();
    }
}
