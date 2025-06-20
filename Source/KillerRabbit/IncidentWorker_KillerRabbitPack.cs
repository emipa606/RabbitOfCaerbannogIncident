using RimWorld;
using UnityEngine;
using Verse;

namespace KillerRabbits;

public class IncidentWorker_KillerRabbitPack : IncidentWorker
{
    protected override bool TryExecuteWorker(IncidentParms parms)
    {
        var map = (Map)parms.target;
        if (!RCellFinder.TryFindRandomPawnEntryCell(out var intVec, map, CellFinder.EdgeRoadChance_Animal))
        {
            return false;
        }

        var num = Rand.RangeInclusive(2, 6);
        for (var i = 0; i < num; i++)
        {
            var intVec2 = CellFinder.RandomClosewalkCellNear(intVec, map, 10);
            var pawn = PawnGenerator.GeneratePawn(KillerRabbitsDefOf.Rabbit_of_Caerbannog);
            var percentageThreshUrgentlyHungry = pawn.needs.food.PercentageThreshUrgentlyHungry;
            var percentageThreshHungry = pawn.needs.food.PercentageThreshHungry;
            var curLevelPercentage = Random.Range(percentageThreshUrgentlyHungry, percentageThreshHungry);
            pawn.needs.food.CurLevelPercentage = curLevelPercentage;
            GenSpawn.Spawn(pawn, intVec2, map);
        }

        Find.LetterStack.ReceiveLetter("LetterLabelKillerRabbitPackArrived".Translate(),
            "KillerRabbitPackArrived".Translate(), LetterDefOf.ThreatSmall, new TargetInfo(intVec, map));
        return true;
    }
}