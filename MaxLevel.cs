// Copyright (C)
// See LICENSE file for extended copyright information.
// This file is part of the repository from .

using ModShardLauncher;
using ModShardLauncher.Mods;

namespace VanMaxLevel;
public class VanMaxLevel : Mod
{
    public override string Author => "darkVinci";
    public override string Name => "MaxLevel 100";
    public override string Description => "Increase the level limit to 100";
    public override string Version => "1.0.0.0";
    public override string TargetVersion => "0.9.1.19-vm";

    public override void PatchMod()
    {
        MaxLevel();
    }

    public static void MaxLevel()
    {
        Msl.LoadAssemblyAsString("gml_Object_o_player_Step_0")
            .MatchFrom("pushi.e 30\ncmp.i.v EQ")
            .ReplaceBy("pushi.e 100\ncmp.i.v EQ")
            .Save();

        Msl.LoadGML("gml_Object_o_character_panel_mask_Draw_0")
            .MatchFrom("var _maxLevel = (scr_atr(\"LVL\") == 30)")
            .ReplaceBy("var _maxLevel = (scr_atr(\"LVL\") == 100)")
            .Save();
    }
}


