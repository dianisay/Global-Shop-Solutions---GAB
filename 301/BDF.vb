Program.Sub.Preflight.Start
' No setup or validation needed before main logic.
Program.Sub.Preflight.End

Program.Sub.Main.Start

Function.Intrinsic.UI.UsePixels ' Set UI units to pixels instead of twips (older unit)

' Declare local variables
V.Local.iRowCount.Declare      ' Will hold the number of rows in the BDF
V.Local.iCnt.Declare           ' Loop counter
V.Local.sRow.Declare           ' Holds a single row of data (delimited text)

' --- COMMENTED OUT BLOCK: Grid transformation logic for SupplyGrid ---

' Load the BDF grid passed into the program
'F.Intrinsic.BDF.Load("SupplyGrid",V.Passed.GRID-SUPPLY,True)

' Clone the grid so we can make changes without affecting the original
'F.Intrinsic.BDF.CLone("SupplyGrid","NewSupplyGrid")

' Get the number of rows in the grid
'F.Intrinsic.BDF.ReadRowCount("SupplyGrid",V.Local.iRowCount)
' Adjust to 0-based index
'F.Intrinsic.Math.Sub(V.Local.iRowCount,1,V.Local.iRowCount)

' Loop through all rows in the SupplyGrid
'F.Intrinsic.Control.For(V.Local.iCnt,V.Local.iRowCount)
'    Read the row into a string
'    F.Intrinsic.BDF.ReadRow("SupplyGrid",V.Local.iCnt,V.Local.sRow)

'    Split the row using |~| delimiter into an array
'    F.Intrinsic.String.Split(V.Local.sRow,"|~|",V.Local.sRow)

'    If the second column is "PO", change it to "PurchOrd"
'    F.Intrinsic.Control.If(V.Local.sRow(1).Trim,=,"PO")
'        V.Local.sRow(1).Set("PurchOrd")
'    F.Intrinsic.Control.EndIf

'    Apply background color to third column based on numeric value
'    If < 1000, set to light green
'    F.Intrinsic.Control.If(V.Local.sRow(2).Float,<,1000)
'        F.Intrinsic.String.Build("{0}]=[BC::{1}",V.Local.sRow(2),V.Color.LtGreen,V.Local.sRow(2))
'    Else if = 1000, set to yellow
'    F.Intrinsic.Control.ElseIf(V.Local.sRow(2).Float,=,1000)
'        F.Intrinsic.String.Build("{0}]=[BC::{1}",V.Local.sRow(2),V.Color.Yellow,V.Local.sRow(2))
'    Else set to pink
'    F.Intrinsic.Control.Else
'        F.Intrinsic.String.Build("{0}]=[BC::{1}",V.Local.sRow(2),V.Color.Pink,V.Local.sRow(2))
'    F.Intrinsic.Control.EndIf

'    Join the array back into a string row
'    F.Intrinsic.String.Join(V.Local.sRow,"|~|",V.Local.sRow)

'    Write the modified row to the new grid
'    F.Intrinsic.BDF.WriteRow("NewSupplyGrid",V.Local.sRow)

'F.Intrinsic.Control.Next(V.Local.iCnt)

' Save the updated grid to overwrite the original
'F.Intrinsic.BDF.Save("NewSupplyGrid",V.Passed.GRID-SUPPLY)


' --- ACTIVE BLOCK: Update button labels in Supply and Demand UI menu ---

' Load the existing accordion control BDF
F.Intrinsic.BDF.Load("SnDButtons","SupplyAndDemand-AccordionControlNavigation-bdf",True)

' Clone it so we can modify it safely
F.Intrinsic.BDF.Clone("SnDButtons","NewSnDButtons")

' Get row count of original BDF
F.Intrinsic.BDF.ReadRowCount("SnDButtons",V.Local.iRowCount)
F.Intrinsic.Math.Sub(V.Local.iRowCount,1,V.Local.iRowCount) ' Adjust for 0-based

' Loop through all rows
F.Intrinsic.Control.For(V.Local.iCnt,V.Local.iRowCount)

    ' Read each row from original BDF
    F.Intrinsic.BDF.ReadRow("SnDButtons",V.Local.iCnt,V.Local.sRow)

    ' Split the row into fields using the |~| delimiter
    F.Intrinsic.String.Split(V.Local.sRow,"|~|",V.Local.sRow)

    ' If the first column is "AccordionControlElementScript1"
    ' then change the second column to say "Custom GAB Script"
    F.Intrinsic.Control.If(V.Local.sRow(0).Trim,=,"AccordionControlElementScript1")
        V.Local.sRow(1).Set("Custom GAB Script")
    F.Intrinsic.Control.EndIf

    ' Re-join the row into a delimited string
    F.Intrinsic.String.Join(V.Local.sRow,"|~|",V.Local.sRow)

    ' Write the modified row into the cloned BDF
    F.Intrinsic.BDF.WriteRow("NewSnDButtons",V.Local.sRow)

F.Intrinsic.Control.Next(V.Local.iCnt)

' Save the modified version over the original file
F.Intrinsic.BDF.Save("NewSnDButtons","SupplyAndDemand-AccordionControlNavigation-bdf")

Program.Sub.Main.End


Program.Sub.Comments.Start
' Metadata for version control and auditing
${$5$}$20.1.9194.26336$}$1
${$6$}$tsmith$}$20250312103018269$}$xqPbj9atw05FglvzeFsZ9cqXP+qvG6tXBpEKNTgypcAd33WuS+D//N7yrRSx1s3MHml3LpTpZ34=
${$7$}$File Version:1.1.20250312153018.0
Program.Sub.Comments.End
