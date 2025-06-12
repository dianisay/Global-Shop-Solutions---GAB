Program.Sub.Preflight.Start
' Declare error variable and initialize the 450000 datatable
V.Global.s450000Error.Declare(String)
F.Data.DataTable.Create("450000", True)
F.Data.DataTable.AddColumn("450000", "Mode", "String")
F.Data.DataTable.AddColumn("450000", "WONum", "String")
F.Data.DataTable.AddColumn("450000", "WOSuffix", "String")
F.Data.DataTable.AddColumn("450000", "ActOrHist", "String")
Program.Sub.Preflight.End

Program.Sub.Main.Start
Function.Intrinsic.UI.UsePixels

' Add a row to the 450000 datatable to show a specific work order
F.Data.DataTable.AddRow("450000", "Mode", 7, "WONum", "001112", "WOSuffix", "001", "ActOrHist", "A")



' Call the synchronous wrapper to process the datatable
F.Intrinsic.Control.CallSub(450000Sync)

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250611205435880$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLLFc0RSESKYHL4adAbwNFAiqyABiA0Vs7I=
${$7$}$File Version:1.1.20250612015435.1
Program.Sub.Comments.End
