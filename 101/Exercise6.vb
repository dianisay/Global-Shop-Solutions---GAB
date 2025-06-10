Program.Sub.ScreenSU.Start
Gui.F_Calc..Create(BaseForm)
Gui.F_Calc..Caption("Calculations")
Gui.F_Calc..Size(462,113)
Gui.F_Calc..MinX(0)
Gui.F_Calc..MinY(0)
Gui.F_Calc..Position(0,0)
Gui.F_Calc..AlwaysOnTop(False)
Gui.F_Calc..FontName("Tahoma")
Gui.F_Calc..FontSize(8.25)
Gui.F_Calc..ControlBox(True)
Gui.F_Calc..MaxButton(False)
Gui.F_Calc..MinButton(True)
Gui.F_Calc..MousePointer(0)
Gui.F_Calc..Moveable(True)
Gui.F_Calc..Sizeable(False)
Gui.F_Calc..ShowInTaskBar(True)
Gui.F_Calc..TitleBar(True)
Gui.F_Calc..Event(UnLoad,F_Calc_UnLoad)
Gui.F_Calc.txtArea.Create(TextBox,"",True,100,20,0,21,34,True,0,"Tahoma",8.25,,1)
Gui.F_Calc.txtArea.Locked(True)
Gui.F_Calc.lblArea.Create(Label,"Area",True,23,13,0,23,19,True,0,"Tahoma",8.25,,0,0)
Gui.F_Calc.lblArea.BorderStyle(0)

Gui.F_Calc.txtHeight.Create(TextBox,"",True,100,20,0,21,64,True,0,"Tahoma",8.25,,1)
Gui.F_Calc.txtHeight.Locked(False)
Gui.F_Calc.lblHeight.Create(Label,"Height",True,23,53,0,23,19,True,0,"Tahoma",8.25,,0,0)
Gui.F_Calc.lblHeight.BorderStyle(0)

Gui.F_Calc.txtVolume.Create(TextBox,"",True,100,20,0,21,94,True,0,"Tahoma",8.25,,1)
Gui.F_Calc.txtVolume.Locked(True)
Gui.F_Calc.lblVolume.Create(Label,"Volume",True,23,83,0,23,19,True,0,"Tahoma",8.25,,0,0)
Gui.F_Calc.lblVolume.BorderStyle(0)

Program.Sub.ScreenSU.End

Program.Sub.Preflight.Start
Program.Sub.Preflight.End

V.Local.fArea.Declare
V.Local.fVolume.Declare

F.Intrinsic.Control.If(V.Caller.Hook,=,13281)
    ' Read values from screen
    V.Local.Length.Declare
    V.Local.Width.Declare
    V.Local.Height.Declare

    V.Local.Length.Set(V.Screen.Gui.F_Calc.txtArea.Text)
    V.Local.Width.Set(V.Passed.000015)
    V.Local.Height.Set(V.Screen.Gui.F_Calc.txtHeight.Text)

    ' Validate inputs
    F.Intrinsic.Control.If(V.Local.Length,<=,0,or,V.Local.Width,<=,0,or,V.Local.Height,<=,0)
        F.Intrinsic.UI.Msgbox("Length, Width, and Height must be numeric and greater than 0.")
        F.Intrinsic.Control.End
    F.Intrinsic.Control.EndIf

    ' Calculate Area and Volume
    F.Intrinsic.Math.Mult(V.Local.Length, V.Local.Width, V.Local.fArea)
    F.Intrinsic.Math.Mult(V.Local.fArea, V.Local.Height, V.Local.fVolume)

    ' Display results
    Gui.F_Calc.txtArea.Text(V.Local.fArea.String)
    Gui.F_Calc.txtVolume.Text(V.Local.fVolume.String)

    Gui.F_Calc..Show
F.Intrinsic.Control.EndIf





Program.Sub.F_Calc_UnLoad.Start
F.Intrinsic.Control.End
Program.Sub.F_Calc_UnLoad.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250610165638168$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLKSQ/N/eOeSrKot3Mgvr0A9cNIZwJzR7N0=
${$7$}$File Version:1.1.20250610215638.1
Program.Sub.Comments.End
