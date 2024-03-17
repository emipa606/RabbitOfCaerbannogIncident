using RimWorld;
using Verse;

namespace KillerRabbits;

[DefOf]
public static class KillerRabbitsDefOf
{
    public static PawnKindDef Rabbit_of_Caerbannog;

    static KillerRabbitsDefOf()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(KillerRabbitsDefOf));
    }
}